using ClosedXML.Excel;
using OfficeOpenXml;
using P_Finance.Core.Models;
using System;
using System.Configuration;

namespace P_Finance.Core.DataAccess
{
    internal static class ExcelProcessor
    {
        public static string FullFilePath(this string fileName)
        {
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}";
        }

        public static BillsModel ConvertToBillsModel(this string filePath)
        {
            BillsModel bills = new();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(new System.IO.FileInfo(filePath)))
            {
                var workbook = package.Workbook;
                var worksheet = workbook.Worksheets["Sheet2"];

                if (worksheet != null)
                {
                    workbook.Calculate();

                    var billsTotalCell = worksheet.Cells["C21"];
                    var amountFromCheckCell = worksheet.Cells["C35"];

                    if (billsTotalCell != null)
                    {
                        if (decimal.TryParse(billsTotalCell.Text, out decimal billsTotal))
                        {
                            bills.BillsTotal = billsTotal;
                        }
                    }

                    if (amountFromCheckCell != null)
                    {
                        if (decimal.TryParse(amountFromCheckCell.Text, out decimal amountFromCheck))
                        {
                            bills.AmountFromCheck = amountFromCheck;
                        }
                    }
                }
            }

            return bills;
        }
    }
}
