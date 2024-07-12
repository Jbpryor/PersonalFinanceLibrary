using PersonalFinanceLibrary.Models;
using PersonalFinanceLibrary;

namespace PersonalFinanceUI
{
    public partial class FinanceDashboard : Form
    {        
        public FinanceDashboard()
        {
            InitializeComponent();

            PopulateData();
        }

        private async void PopulateData()
        {
            DashboardModel dashboard = await GlobalConfig.Connection!.DashboardData_Get();

            dateUpdatedValue.Text = dashboard.DateUpdated.ToString("MM/dd/yyyy");
            TotalSpendingPowerValue.Text = dashboard.TotalBalance.ToString("0.00");
            GasSpendingPowerValue.Text = dashboard.GasBalance.ToString("0.00");
            GroceriesSpendingPowerValue.Text = dashboard.GroceriesBalance.ToString("0.00");
            TotalBillsPerMonthValue.Text = dashboard.BillsTotal.ToString("0.00");
        }

        private void DepositCheckButton_Click(object sender, EventArgs e)
        {
            DepositForm depositForm = new();
            depositForm.Show();
            this.Hide();
        }

        private async void InputPurchasesButton_Click(object sender, EventArgs e)
        {
            List<CreditCardModel> creditCards = [.. await(GlobalConfig.Connection!.CreditCards_GetAll())];

            if (creditCards.Count == 0)
            {
                CreditCardForm creditCardForm = new CreditCardForm();
                creditCardForm.Show();
                this.Hide();
            }
            else
            {
                PurchaseForm purchaseForm = new();
                purchaseForm.Show();
                this.Hide();
            }

        }
    }
}
