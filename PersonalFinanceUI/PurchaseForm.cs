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
    public partial class PurchaseForm : Form
    {
        List<CreditCardModel> creditCards = [];
        List<CategoryModel> categories = [];
        CreditCardModel selectedCard = new();
        CategoryModel selectedCategory = new();

        public PurchaseForm()
        {
            InitializeComponent();

            PopulateCreditCardList();

            PopulateCategoryList();
        }

        private void PopulateCategoryList()
        {
            categories.Add(new CategoryModel { Id = 1, Name = "Gas" });
            categories.Add(new CategoryModel { Id = 2, Name = "Groceries" });
            categories.Add(new CategoryModel { Id = 3, Name = "Other" });
            categories.Add(new CategoryModel { Id = 4, Name = "Update Card Balance" });

            categories = [.. categories.OrderBy(category => category.Name)];

            purchaseCategoryDropdown.DataSource = null;
            purchaseCategoryDropdown.DataSource = categories;
            purchaseCategoryDropdown.DisplayMember = "Name";
            purchaseCategoryDropdown.ValueMember = "Id";
        }

        private void PopulateCreditCardList()
        {
            creditCards = [.. GlobalConfig.Connection?.CreditCards_GetAll()];

            creditCards = [.. creditCards.OrderByDescending(card => card.Id)];
            creditCardDropdown.DataSource = null;
            creditCardDropdown.DataSource = creditCards;
            creditCardDropdown.DisplayMember = "CardName";
            creditCardDropdown.ValueMember = "Id";
            creditCardDropdown.SelectedValue = creditCards.First().Id;
        }

        private void creditCardDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCard = (CreditCardModel)creditCardDropdown.SelectedItem;
        }

        private void purchaseCategoryDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCategory = (CategoryModel)purchaseCategoryDropdown.SelectedItem;
        }

        private void createPurchaseButton_Click(object sender, EventArgs e)
        {
            if (purchaseNameValue.Text.Length == 0)
            {
                MessageBox.Show("Please enter a valid Name for the current purchase");
                return;
            }

            if (creditCardDropdown == null)
            {
                MessageBox.Show("Please select a valid credit card.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selectedCategory == null || selectedCategory.Id == 0)
            {
                MessageBox.Show("Please select a valid category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool amountValid = decimal.TryParse(purchaseAmountValue.Text, out decimal amount);

            if (!amountValid)
            {
                MessageBox.Show("Please enter a valid Amount for the current purchase. Ex: 15.75", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PurchaseModel purchase = new()
            {
                Name = purchaseNameValue.Text,
                CategoryId = selectedCategory.Id,
                Amount = amount,
                CreditCardId = selectedCard.Id
            };

            GlobalConfig.Connection?.CreatePurchase(purchase);

            FinanceDashboard dashboard = new();
            dashboard.Show();
            this.Close();
        }

        private void creditCardFormLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreditCardForm credit = new();
            credit.Show();
            this.Close();
        }

        private void viewAllPurchasesLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PurchasesViewer purchasesViewer = new();
            purchasesViewer.Show();
            this.Close();
        }
    }
}
