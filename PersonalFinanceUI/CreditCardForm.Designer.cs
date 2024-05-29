namespace PersonalFinanceUI
{
    partial class CreditCardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreditCardForm));
            AddCardButton = new Button();
            nameLabel = new Label();
            CreditCardTitle = new Label();
            creditCardNameValue = new TextBox();
            creditCardLabel = new Label();
            viewAllPurchasesLink = new LinkLabel();
            RemoveCardButton = new Button();
            creditCardDropdown = new ComboBox();
            dashboardLink = new LinkLabel();
            newCardGroup = new GroupBox();
            removeCardBox = new GroupBox();
            cardPaymentBox = new GroupBox();
            paymentAmountValue = new TextBox();
            paymentAmountLabel = new Label();
            paymentButton = new Button();
            paymentDropdown = new ComboBox();
            paymentCardLabel = new Label();
            createPurchaseLink = new LinkLabel();
            refundCardBox = new GroupBox();
            refundAmountValue = new TextBox();
            refundAmountLabel = new Label();
            addRefundButton = new Button();
            refundDropdown = new ComboBox();
            refundCardLabel = new Label();
            newCardGroup.SuspendLayout();
            removeCardBox.SuspendLayout();
            cardPaymentBox.SuspendLayout();
            refundCardBox.SuspendLayout();
            SuspendLayout();
            // 
            // AddCardButton
            // 
            AddCardButton.BackColor = Color.Lime;
            AddCardButton.FlatAppearance.BorderColor = Color.Black;
            AddCardButton.FlatAppearance.MouseDownBackColor = Color.Green;
            AddCardButton.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            AddCardButton.FlatStyle = FlatStyle.Flat;
            AddCardButton.ForeColor = Color.Black;
            AddCardButton.Location = new Point(143, 93);
            AddCardButton.Name = "AddCardButton";
            AddCardButton.Size = new Size(133, 36);
            AddCardButton.TabIndex = 17;
            AddCardButton.Text = "Add Card";
            AddCardButton.UseVisualStyleBackColor = false;
            AddCardButton.Click += AddCardButton_Click;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Microsoft JhengHei UI", 20.25F);
            nameLabel.ForeColor = Color.White;
            nameLabel.Location = new Point(22, 39);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(92, 35);
            nameLabel.TabIndex = 16;
            nameLabel.Text = "Name";
            // 
            // CreditCardTitle
            // 
            CreditCardTitle.AutoSize = true;
            CreditCardTitle.Font = new Font("Microsoft JhengHei UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CreditCardTitle.ForeColor = Color.White;
            CreditCardTitle.Location = new Point(352, 23);
            CreditCardTitle.Name = "CreditCardTitle";
            CreditCardTitle.Size = new Size(211, 44);
            CreditCardTitle.TabIndex = 15;
            CreditCardTitle.Text = "Credit Card";
            // 
            // creditCardNameValue
            // 
            creditCardNameValue.BackColor = Color.FromArgb(65, 65, 65);
            creditCardNameValue.BorderStyle = BorderStyle.None;
            creditCardNameValue.Font = new Font("Microsoft JhengHei UI", 20.25F);
            creditCardNameValue.ForeColor = Color.White;
            creditCardNameValue.Location = new Point(178, 39);
            creditCardNameValue.Margin = new Padding(5);
            creditCardNameValue.Name = "creditCardNameValue";
            creditCardNameValue.Size = new Size(218, 35);
            creditCardNameValue.TabIndex = 14;
            // 
            // creditCardLabel
            // 
            creditCardLabel.AutoSize = true;
            creditCardLabel.Font = new Font("Microsoft JhengHei UI", 20.25F);
            creditCardLabel.ForeColor = Color.White;
            creditCardLabel.Location = new Point(14, 44);
            creditCardLabel.Name = "creditCardLabel";
            creditCardLabel.Size = new Size(159, 35);
            creditCardLabel.TabIndex = 20;
            creditCardLabel.Text = "Credit Card";
            // 
            // viewAllPurchasesLink
            // 
            viewAllPurchasesLink.ActiveLinkColor = Color.ForestGreen;
            viewAllPurchasesLink.AutoSize = true;
            viewAllPurchasesLink.LinkColor = Color.Lime;
            viewAllPurchasesLink.Location = new Point(383, 522);
            viewAllPurchasesLink.Name = "viewAllPurchasesLink";
            viewAllPurchasesLink.Size = new Size(202, 28);
            viewAllPurchasesLink.TabIndex = 18;
            viewAllPurchasesLink.TabStop = true;
            viewAllPurchasesLink.Text = "View All Purchases";
            viewAllPurchasesLink.LinkClicked += viewAllPurchasesLink_LinkClicked;
            // 
            // RemoveCardButton
            // 
            RemoveCardButton.BackColor = Color.Lime;
            RemoveCardButton.FlatAppearance.BorderColor = Color.Black;
            RemoveCardButton.FlatAppearance.MouseDownBackColor = Color.Green;
            RemoveCardButton.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            RemoveCardButton.FlatStyle = FlatStyle.Flat;
            RemoveCardButton.ForeColor = Color.Black;
            RemoveCardButton.Location = new Point(125, 94);
            RemoveCardButton.Name = "RemoveCardButton";
            RemoveCardButton.Size = new Size(169, 36);
            RemoveCardButton.TabIndex = 21;
            RemoveCardButton.Text = "Remove Card";
            RemoveCardButton.UseVisualStyleBackColor = false;
            RemoveCardButton.Click += RemoveCardButton_Click;
            // 
            // creditCardDropdown
            // 
            creditCardDropdown.BackColor = Color.FromArgb(65, 65, 65);
            creditCardDropdown.FlatStyle = FlatStyle.Flat;
            creditCardDropdown.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            creditCardDropdown.ForeColor = Color.White;
            creditCardDropdown.FormattingEnabled = true;
            creditCardDropdown.Location = new Point(186, 43);
            creditCardDropdown.Name = "creditCardDropdown";
            creditCardDropdown.Size = new Size(218, 34);
            creditCardDropdown.TabIndex = 22;
            creditCardDropdown.SelectedIndexChanged += creditCardDropdown_SelectedIndexChanged;
            // 
            // dashboardLink
            // 
            dashboardLink.ActiveLinkColor = Color.ForestGreen;
            dashboardLink.AutoSize = true;
            dashboardLink.LinkColor = Color.Lime;
            dashboardLink.Location = new Point(710, 522);
            dashboardLink.Name = "dashboardLink";
            dashboardLink.Size = new Size(122, 28);
            dashboardLink.TabIndex = 24;
            dashboardLink.TabStop = true;
            dashboardLink.Text = "Dashboard";
            dashboardLink.LinkClicked += dashboardLink_LinkClicked;
            // 
            // newCardGroup
            // 
            newCardGroup.Controls.Add(AddCardButton);
            newCardGroup.Controls.Add(creditCardNameValue);
            newCardGroup.Controls.Add(nameLabel);
            newCardGroup.FlatStyle = FlatStyle.Flat;
            newCardGroup.ForeColor = Color.ForestGreen;
            newCardGroup.Location = new Point(24, 80);
            newCardGroup.Name = "newCardGroup";
            newCardGroup.Size = new Size(418, 147);
            newCardGroup.TabIndex = 25;
            newCardGroup.TabStop = false;
            newCardGroup.Text = "Add Card";
            // 
            // removeCardBox
            // 
            removeCardBox.Controls.Add(RemoveCardButton);
            removeCardBox.Controls.Add(creditCardDropdown);
            removeCardBox.Controls.Add(creditCardLabel);
            removeCardBox.FlatStyle = FlatStyle.Flat;
            removeCardBox.ForeColor = Color.ForestGreen;
            removeCardBox.Location = new Point(472, 80);
            removeCardBox.Name = "removeCardBox";
            removeCardBox.Size = new Size(418, 148);
            removeCardBox.TabIndex = 26;
            removeCardBox.TabStop = false;
            removeCardBox.Text = "Remove Card";
            // 
            // cardPaymentBox
            // 
            cardPaymentBox.Controls.Add(paymentAmountValue);
            cardPaymentBox.Controls.Add(paymentAmountLabel);
            cardPaymentBox.Controls.Add(paymentButton);
            cardPaymentBox.Controls.Add(paymentDropdown);
            cardPaymentBox.Controls.Add(paymentCardLabel);
            cardPaymentBox.ForeColor = Color.ForestGreen;
            cardPaymentBox.Location = new Point(24, 266);
            cardPaymentBox.Name = "cardPaymentBox";
            cardPaymentBox.Size = new Size(418, 214);
            cardPaymentBox.TabIndex = 27;
            cardPaymentBox.TabStop = false;
            cardPaymentBox.Text = "Card Payment";
            // 
            // paymentAmountValue
            // 
            paymentAmountValue.BackColor = Color.FromArgb(65, 65, 65);
            paymentAmountValue.BorderStyle = BorderStyle.None;
            paymentAmountValue.Font = new Font("Microsoft JhengHei UI", 20.25F);
            paymentAmountValue.ForeColor = Color.White;
            paymentAmountValue.Location = new Point(185, 94);
            paymentAmountValue.Margin = new Padding(5);
            paymentAmountValue.Name = "paymentAmountValue";
            paymentAmountValue.Size = new Size(218, 35);
            paymentAmountValue.TabIndex = 26;
            // 
            // paymentAmountLabel
            // 
            paymentAmountLabel.AutoSize = true;
            paymentAmountLabel.Font = new Font("Microsoft JhengHei UI", 20.25F);
            paymentAmountLabel.ForeColor = Color.White;
            paymentAmountLabel.Location = new Point(14, 94);
            paymentAmountLabel.Name = "paymentAmountLabel";
            paymentAmountLabel.Size = new Size(118, 35);
            paymentAmountLabel.TabIndex = 27;
            paymentAmountLabel.Text = "Amount";
            // 
            // paymentButton
            // 
            paymentButton.BackColor = Color.Lime;
            paymentButton.FlatAppearance.BorderColor = Color.Black;
            paymentButton.FlatAppearance.MouseDownBackColor = Color.Green;
            paymentButton.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            paymentButton.FlatStyle = FlatStyle.Flat;
            paymentButton.ForeColor = Color.Black;
            paymentButton.Location = new Point(125, 158);
            paymentButton.Name = "paymentButton";
            paymentButton.Size = new Size(169, 36);
            paymentButton.TabIndex = 24;
            paymentButton.Text = "Add Payment";
            paymentButton.UseVisualStyleBackColor = false;
            paymentButton.Click += paymentButton_Click;
            // 
            // paymentDropdown
            // 
            paymentDropdown.BackColor = Color.FromArgb(65, 65, 65);
            paymentDropdown.FlatStyle = FlatStyle.Flat;
            paymentDropdown.ForeColor = Color.White;
            paymentDropdown.FormattingEnabled = true;
            paymentDropdown.Location = new Point(186, 42);
            paymentDropdown.Name = "paymentDropdown";
            paymentDropdown.Size = new Size(218, 36);
            paymentDropdown.TabIndex = 25;
            paymentDropdown.SelectedIndexChanged += paymentDropdown_SelectedIndexChanged;
            // 
            // paymentCardLabel
            // 
            paymentCardLabel.AutoSize = true;
            paymentCardLabel.Font = new Font("Microsoft JhengHei UI", 20.25F);
            paymentCardLabel.ForeColor = Color.White;
            paymentCardLabel.Location = new Point(14, 43);
            paymentCardLabel.Name = "paymentCardLabel";
            paymentCardLabel.Size = new Size(159, 35);
            paymentCardLabel.TabIndex = 23;
            paymentCardLabel.Text = "Credit Card";
            // 
            // createPurchaseLink
            // 
            createPurchaseLink.ActiveLinkColor = Color.ForestGreen;
            createPurchaseLink.AutoSize = true;
            createPurchaseLink.LinkColor = Color.Lime;
            createPurchaseLink.Location = new Point(82, 522);
            createPurchaseLink.Name = "createPurchaseLink";
            createPurchaseLink.Size = new Size(176, 28);
            createPurchaseLink.TabIndex = 28;
            createPurchaseLink.TabStop = true;
            createPurchaseLink.Text = "Create Purchase";
            createPurchaseLink.LinkClicked += createPurchaseLink_LinkClicked;
            // 
            // refundCardBox
            // 
            refundCardBox.Controls.Add(refundAmountValue);
            refundCardBox.Controls.Add(refundAmountLabel);
            refundCardBox.Controls.Add(addRefundButton);
            refundCardBox.Controls.Add(refundDropdown);
            refundCardBox.Controls.Add(refundCardLabel);
            refundCardBox.ForeColor = Color.ForestGreen;
            refundCardBox.Location = new Point(472, 266);
            refundCardBox.Name = "refundCardBox";
            refundCardBox.Size = new Size(418, 214);
            refundCardBox.TabIndex = 28;
            refundCardBox.TabStop = false;
            refundCardBox.Text = "Card Refund";
            // 
            // refundAmountValue
            // 
            refundAmountValue.BackColor = Color.FromArgb(65, 65, 65);
            refundAmountValue.BorderStyle = BorderStyle.None;
            refundAmountValue.Font = new Font("Microsoft JhengHei UI", 20.25F);
            refundAmountValue.ForeColor = Color.White;
            refundAmountValue.Location = new Point(185, 94);
            refundAmountValue.Margin = new Padding(5);
            refundAmountValue.Name = "refundAmountValue";
            refundAmountValue.Size = new Size(218, 35);
            refundAmountValue.TabIndex = 26;
            // 
            // refundAmountLabel
            // 
            refundAmountLabel.AutoSize = true;
            refundAmountLabel.Font = new Font("Microsoft JhengHei UI", 20.25F);
            refundAmountLabel.ForeColor = Color.White;
            refundAmountLabel.Location = new Point(14, 94);
            refundAmountLabel.Name = "refundAmountLabel";
            refundAmountLabel.Size = new Size(118, 35);
            refundAmountLabel.TabIndex = 27;
            refundAmountLabel.Text = "Amount";
            // 
            // addRefundButton
            // 
            addRefundButton.BackColor = Color.Lime;
            addRefundButton.FlatAppearance.BorderColor = Color.Black;
            addRefundButton.FlatAppearance.MouseDownBackColor = Color.Green;
            addRefundButton.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            addRefundButton.FlatStyle = FlatStyle.Flat;
            addRefundButton.ForeColor = Color.Black;
            addRefundButton.Location = new Point(125, 158);
            addRefundButton.Name = "addRefundButton";
            addRefundButton.Size = new Size(169, 36);
            addRefundButton.TabIndex = 24;
            addRefundButton.Text = "Add Refund";
            addRefundButton.UseVisualStyleBackColor = false;
            addRefundButton.Click += addRefundButton_Click;
            // 
            // refundDropdown
            // 
            refundDropdown.BackColor = Color.FromArgb(65, 65, 65);
            refundDropdown.FlatStyle = FlatStyle.Flat;
            refundDropdown.ForeColor = Color.White;
            refundDropdown.FormattingEnabled = true;
            refundDropdown.Location = new Point(186, 42);
            refundDropdown.Name = "refundDropdown";
            refundDropdown.Size = new Size(218, 36);
            refundDropdown.TabIndex = 25;
            refundDropdown.SelectedIndexChanged += refundCardDropdown_SelectedIndexChanged;
            // 
            // refundCardLabel
            // 
            refundCardLabel.AutoSize = true;
            refundCardLabel.Font = new Font("Microsoft JhengHei UI", 20.25F);
            refundCardLabel.ForeColor = Color.White;
            refundCardLabel.Location = new Point(14, 43);
            refundCardLabel.Name = "refundCardLabel";
            refundCardLabel.Size = new Size(159, 35);
            refundCardLabel.TabIndex = 23;
            refundCardLabel.Text = "Credit Card";
            // 
            // CreditCardForm
            // 
            AutoScaleDimensions = new SizeF(13F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 35, 35);
            ClientSize = new Size(915, 587);
            Controls.Add(refundCardBox);
            Controls.Add(createPurchaseLink);
            Controls.Add(cardPaymentBox);
            Controls.Add(removeCardBox);
            Controls.Add(newCardGroup);
            Controls.Add(dashboardLink);
            Controls.Add(viewAllPurchasesLink);
            Controls.Add(CreditCardTitle);
            Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(6);
            Name = "CreditCardForm";
            Text = "Credit Card Form";
            newCardGroup.ResumeLayout(false);
            newCardGroup.PerformLayout();
            removeCardBox.ResumeLayout(false);
            removeCardBox.PerformLayout();
            cardPaymentBox.ResumeLayout(false);
            cardPaymentBox.PerformLayout();
            refundCardBox.ResumeLayout(false);
            refundCardBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddCardButton;
        private Label nameLabel;
        private Label CreditCardTitle;
        private TextBox creditCardNameValue;
        private Label creditCardLabel;
        private LinkLabel viewAllPurchasesLink;
        private Button RemoveCardButton;
        private ComboBox creditCardDropdown;
        private LinkLabel dashboardLink;
        private GroupBox newCardGroup;
        private GroupBox removeCardBox;
        private GroupBox cardPaymentBox;
        private TextBox paymentAmountValue;
        private Label paymentAmountLabel;
        private Button paymentButton;
        private ComboBox paymentDropdown;
        private Label paymentCardLabel;
        private LinkLabel createPurchaseLink;
        private GroupBox refundCardBox;
        private TextBox refundAmountValue;
        private Label refundAmountLabel;
        private Button addRefundButton;
        private ComboBox refundDropdown;
        private Label refundCardLabel;
    }
}