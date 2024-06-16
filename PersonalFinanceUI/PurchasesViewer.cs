using PersonalFinanceLibrary;
using PersonalFinanceLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalFinanceUI
{
    public partial class PurchasesViewer : Form
    {
        List<CreditCardModel> creditCards = [];
        CreditCardModel selectedCard = new();
        public PurchasesViewer()
        {
            InitializeComponent();

            PopulateCreditCardList();

            PopulateTotal();

            PopulateTable();
        }

        private void PopulateCreditCardList()
        {
            creditCards = [.. GlobalConfig.Connection?.CreditCards_GetAll().OrderByDescending(card => card.Id)];

            creditCardDropdown.DataSource = null;
            creditCardDropdown.DataSource = creditCards;
            creditCardDropdown.DisplayMember = "CardName";
            creditCardDropdown.ValueMember = "Id";

            if (creditCards.Count > 0)
            {
                selectedCard = creditCards[0];
                purchasesGridView.DataSource = selectedCard.Purchases;
            }
        }

        private void PopulateTable()
        {
            purchasesGridView.AutoGenerateColumns = true;
        }

        private void PopulateTotal()
        {

            if (selectedCard != null && selectedCard.Purchases != null)
            {
                balanceValue.Text = FinanceLogic.GetBalance(selectedCard).ToString("0.00");
            }
        }

        private void creditCardDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCard = (CreditCardModel)creditCardDropdown.SelectedItem;
            purchasesGridView.DataSource = selectedCard?.Purchases;
            PopulateTotal();
        }

        private void creditCardFormLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreditCardForm credit = new();
            credit.Show();
            this.Close();
        }

        private void createPurchaseLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PurchaseForm purchase = new();
            purchase.Show();
            this.Close();
        }

        private void dashboardLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FinanceDashboard dashboard = new();
            dashboard.Show();
            this.Close();
        }
    }
}
