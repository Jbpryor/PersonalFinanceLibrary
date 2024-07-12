using PersonalFinanceLibrary;
using PersonalFinanceLibrary.Models;

namespace PersonalFinanceUI
{
    public partial class DepositForm : Form
    {
        private List<CategoryModel> categories = [];
        private CategoryModel selectedCategory = new();

        public DepositForm()
        {
            InitializeComponent();

            PopulateCategories();
        }

        private void PopulateCategories()
        {
            categories.Add(new CategoryModel { Id = 1, Name = "Cash" });
            categories.Add(new CategoryModel { Id = 2, Name = "PayCheck" });
            categories.Add(new CategoryModel { Id = 3, Name = "Bonus" });
            categories.Add(new CategoryModel { Id = 4, Name = "ExtraCheck" });
            categories.Add(new CategoryModel { Id = 5, Name = "Other" });

            categories = [.. categories.OrderBy(category => category.Name)];

            depositCategoryDropdown.DataSource = null;
            depositCategoryDropdown.DataSource = categories;
            depositCategoryDropdown.DisplayMember = "Name";
            depositCategoryDropdown.ValueMember = "Id";
        }

        private async void createDepositButton_Click(object sender, EventArgs e)
        {

            if (depositNameValue.Text.Length == 0)
            {
                MessageBox.Show("Please enter a valid Name for the current deposit");
                return;
            }

            bool amountValid = decimal.TryParse(depositAmountValue.Text, out decimal amount);

            if (!amountValid)
            {
                MessageBox.Show("Please enter a valid Amount for the current deposit. Ex: 15.75", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selectedCategory == null || selectedCategory.Id == 0)
            {
                MessageBox.Show("Please select a valid category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DepositModel deposit = new()
            {
                Name = depositNameValue.Text,
                CategoryId = selectedCategory.Id,
                Amount = amount
            };

            await GlobalConfig.Connection!.CreateDeposit(deposit);

            FinanceDashboard dashboard = new();
            dashboard.Show();
            this.Close();
        }

        private void depositCategoryDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCategory = (CategoryModel)depositCategoryDropdown.SelectedItem;
        }

        private void dashboardLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FinanceDashboard dashboard = new();
            dashboard.Show();
            this.Close();
        }
    }
}
