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
    public partial class CreditCardForm : Form
    {
        List<CreditCardModel> creditCards = [];
        CreditCardModel selectedCard = new();

        public CreditCardForm()
        {
            InitializeComponent();

            PopulateCreditCardList();
        }

        private async void PopulateCreditCardList()
        {
            creditCards = [.. await(GlobalConfig.Connection!.CreditCards_GetAll())];

            if (creditCards.Count == 0)
            {
                IsVisible(false);
                return;
            }

            IsVisible(true);
            creditCards = [.. creditCards.OrderBy(card => card.Id)];
            creditCardDropdown.DataSource = null;
            creditCardDropdown.DataSource = new List<CreditCardModel>(creditCards);
            creditCardDropdown.DisplayMember = "CardName";
            creditCardDropdown.ValueMember = "Id";
            creditCardDropdown.SelectedValue = selectedCard;

            paymentDropdown.DataSource = null;
            paymentDropdown.DataSource = new List<CreditCardModel>(creditCards);
            paymentDropdown.DisplayMember = "CardName";
            paymentDropdown.ValueMember = "Id";
            paymentDropdown.SelectedValue = selectedCard;
            
            refundDropdown.DataSource = null;
            refundDropdown.DataSource = new List<CreditCardModel>(creditCards);
            refundDropdown.DisplayMember = "CardName";
            refundDropdown.ValueMember = "Id";
            refundDropdown.SelectedValue = selectedCard;
        }

        private void IsVisible(bool isVisible)
        {
            removeCardBox.Visible = isVisible;
            cardPaymentBox.Visible = isVisible;
        }

        private async void AddCardButton_Click(object sender, EventArgs e)
        {
            if (creditCardNameValue.Text.Length == 0)
            {
                MessageBox.Show("Please enter a valid Name for the credit card.");
                return;
            }

            CreditCardModel card = new()
            {
                CardName = creditCardNameValue.Text
            };

            await GlobalConfig.Connection!.CreateCreditCard(card);

            MessageBox.Show($"New Credit Card {creditCardNameValue.Text} added!");

            creditCardNameValue.Text = "";

            PopulateCreditCardList();
        }

        private async void RemoveCardButton_Click(object sender, EventArgs e)
        {
            if (creditCardDropdown.SelectedValue == null)
            {
                MessageBox.Show("Please select a Credit Card to remove.");
                return;
            }

            int selectedCardId = (int)creditCardDropdown.SelectedValue;

            CreditCardModel card = new()
            {
                Id = selectedCardId
            };

            var confirmResult = MessageBox.Show("Are you sure you want to delete this credit card?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                await GlobalConfig.Connection!.DeleteCreditCard(card);
                PopulateCreditCardList();
            }
        }

        private void creditCardDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCard = (CreditCardModel)creditCardDropdown.SelectedItem;
        }

        private void dashboardLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FinanceDashboard dashboard = new();
            dashboard.Show();
            this.Close();
        }

        private void viewAllPurchasesLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PurchasesViewer viewer = new();
            viewer.Show();
            this.Close();
        }

        private void createPurchaseLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PurchaseForm purchaseForm = new();
            purchaseForm.Show();
            this.Close();
        }

        private void paymentDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCard = (CreditCardModel)paymentDropdown.SelectedItem;
        }

        private async void paymentButton_Click(object sender, EventArgs e)
        {
            if (paymentDropdown == null)
            {
                MessageBox.Show("Please select a valid credit card for the Payment.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool amountValid = decimal.TryParse(paymentAmountValue.Text, out decimal amount);

            if (!amountValid)
            {
                MessageBox.Show("Please enter a valid Amount for the current Payment. Ex: 15.75", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PurchaseModel payment = new()
            {
                Name = "Credit Card Payment",
                CategoryId = 5,
                Amount = amount,
                CreditCardId = selectedCard.Id
            };

            await GlobalConfig.Connection!.CreatePurchase(payment);

            MessageBox.Show($"Payment was created for {selectedCard.CardName}.", "Payment Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void addRefundButton_Click(object sender, EventArgs e)
        {
            if (refundDropdown == null || refundDropdown.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a valid credit card for the Refund.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool amountValid = decimal.TryParse(refundAmountValue.Text, out decimal amount);

            if (!amountValid)
            {
                MessageBox.Show("Please enter a valid Amount for the current Refund. Ex: 15.75", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PurchaseModel payment = new()
            {
                Name = "Credit Card Refund",
                CategoryId = 6,
                Amount = amount,
                CreditCardId = selectedCard.Id
            };

            await GlobalConfig.Connection!.CreatePurchase(payment);

            MessageBox.Show($"Refund was created for {selectedCard.CardName}.", "Payment Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void refundCardDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCard = (CreditCardModel)refundDropdown.SelectedItem;
        }
    }
}
