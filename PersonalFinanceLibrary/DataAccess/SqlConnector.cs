﻿using ClosedXML.Excel;
using Dapper;
using DocumentFormat.OpenXml.Drawing.Charts;
using PersonalFinanceLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        private const string db = "PersonalFinances";

        private static IDbConnection OpenConnection()
        {
            return new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectorString(db));
        }
        public void CreateCreditCard(CreditCardModel model)
        {
            using IDbConnection connection = OpenConnection();

            var card = new DynamicParameters();

            card.Add("@CardName", model.CardName);
            card.Add("@id", 0, DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("dbo.spCreditCards_Insert", card, commandType: CommandType.StoredProcedure);

            model.Id = card.Get<int>("@id");
        }

        public void CreateDashboard(DashboardModel model)
        {
            using IDbConnection connection = OpenConnection();

            BillsModel bills = ExcelProcessor.ConvertToBillsModel(ExcelProcessor.FullFilePath(GlobalConfig.ExcelFile));

            var dashboard = new DynamicParameters();

            dashboard.Add("@DateUpdated", model.DateUpdated);
            dashboard.Add("@TotalBalance", model.TotalBalance);
            dashboard.Add("@GasBalance", model.GasBalance);
            dashboard.Add("@GroceriesBalance", model.GroceriesBalance);
            dashboard.Add("@BillsTotal", bills.BillsTotal);
            dashboard.Add("@id", 0, DbType.Int32, ParameterDirection.Output);

            connection.Execute("dbo.spDashboardData_Insert", dashboard, commandType: CommandType.StoredProcedure);

            model.Id = dashboard.Get<int>("@id");
        }

        public void CreateDeposit(DepositModel model)
        {
            using IDbConnection connection = OpenConnection();

            var deposit = new DynamicParameters();

            deposit.Add("@Date", DateTime.Now);
            deposit.Add("@Name", model.Name);
            deposit.Add("@CategoryId", model.CategoryId);
            deposit.Add("@Amount", model.Amount);
            deposit.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("dbo.spDeposits_Insert", deposit, commandType: CommandType.StoredProcedure);

            model.Id = deposit.Get<int>("@id");

            UpdateDashboardData.HandleDeposit(model);
        }

        public void CreatePurchase(PurchaseModel model)
        {
            using IDbConnection connection = OpenConnection();

            var purchase = new DynamicParameters();

            purchase.Add("@Date", DateTime.Now);
            purchase.Add("@Name", model.Name);
            purchase.Add("@CategoryId", model.CategoryId);
            purchase.Add("@Amount", model.Amount);
            purchase.Add("@CreditCardId", model.CreditCardId);
            purchase.Add("@id", 0, DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("dbo.spPurchases_Insert", purchase, commandType: CommandType.StoredProcedure);

            model.Id = purchase.Get<int>("@id");

            UpdateDashboardData.HandlePurchase(model);
        }

        public List<CreditCardModel> CreditCards_GetAll()
        {
            List<CreditCardModel> output;

            using IDbConnection connection = OpenConnection();

            output = connection.Query<CreditCardModel>("dbo.spCreditCards_GetAll").ToList();

            foreach (CreditCardModel card in output)
            {
                var cards = new DynamicParameters();

                cards.Add("@CreditCardId", card.Id);

                card.Purchases = connection.Query<PurchaseModel>("dbo.spPurchases_GetByCreditCard", cards, commandType: CommandType.StoredProcedure).ToList();
            }

            return output;
        }

        public DashboardModel DashboardData_Get()
        {
            using IDbConnection connection = OpenConnection();

            DashboardModel dashboard = connection.QuerySingleOrDefault<DashboardModel>("dbo.spDashboardData_Get");

            if (dashboard == null)
            {
                dashboard = new DashboardModel
                {
                    DateUpdated = DateTime.Now,
                    TotalBalance = 0,
                    GasBalance = 0,
                    GroceriesBalance = 0,
                    BillsTotal = 0
                };

                CreateDashboard(dashboard);
            }

            return dashboard;
        }

        public void DeleteCreditCard(CreditCardModel model)
        {
            using IDbConnection connection = OpenConnection();

            var card = new DynamicParameters();

            card.Add("@CreditCardId", model.Id);

            connection.Execute("dbo.spCreditCard_Delete", card, commandType: CommandType.StoredProcedure);
        }

        public void UpdateDashboard(DashboardModel model)
        {
            using IDbConnection connection = OpenConnection();

            var dashboard = new DynamicParameters();

            dashboard.Add("@DateUpdated", DateTime.Now);
            dashboard.Add("@TotalBalance", model.TotalBalance);
            dashboard.Add("@GasBalance", model.GasBalance);
            dashboard.Add("@GroceriesBalance", model.GroceriesBalance);
            dashboard.Add("@BillsTotal", model.BillsTotal);
            dashboard.Add("@id", model.Id);

            connection.Execute("dbo.spDashboardData_Update", dashboard, commandType: CommandType.StoredProcedure);
        }
    }
}
