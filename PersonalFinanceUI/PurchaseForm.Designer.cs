namespace PersonalFinanceUI
{
    partial class PurchaseForm
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
            creditCardDropdown = new ComboBox();
            creditCardLabel = new Label();
            purchaseFormTitle = new Label();
            creditCardFormLink = new LinkLabel();
            purchaseNameLabel = new Label();
            purchaseNameValue = new TextBox();
            purchaseAmountLabel = new Label();
            purchaseAmountValue = new TextBox();
            viewAllPurchasesLink = new LinkLabel();
            createPurchaseButton = new Button();
            purchaseCategoryDropdown = new ComboBox();
            purchaseCategoryLabel = new Label();
            SuspendLayout();
            // 
            // creditCardDropdown
            // 
            creditCardDropdown.BackColor = Color.FromArgb(65, 65, 65);
            creditCardDropdown.FlatStyle = FlatStyle.Flat;
            creditCardDropdown.ForeColor = Color.White;
            creditCardDropdown.FormattingEnabled = true;
            creditCardDropdown.Location = new Point(260, 136);
            creditCardDropdown.Name = "creditCardDropdown";
            creditCardDropdown.Size = new Size(218, 34);
            creditCardDropdown.TabIndex = 0;
            creditCardDropdown.SelectedIndexChanged += creditCardDropdown_SelectedIndexChanged;
            // 
            // creditCardLabel
            // 
            creditCardLabel.AutoSize = true;
            creditCardLabel.Font = new Font("Microsoft JhengHei UI", 20.25F);
            creditCardLabel.ForeColor = Color.White;
            creditCardLabel.Location = new Point(73, 136);
            creditCardLabel.Name = "creditCardLabel";
            creditCardLabel.Size = new Size(159, 35);
            creditCardLabel.TabIndex = 14;
            creditCardLabel.Text = "Credit Card";
            // 
            // purchaseFormTitle
            // 
            purchaseFormTitle.AutoSize = true;
            purchaseFormTitle.Font = new Font("Microsoft JhengHei UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            purchaseFormTitle.ForeColor = Color.White;
            purchaseFormTitle.Location = new Point(188, 32);
            purchaseFormTitle.Name = "purchaseFormTitle";
            purchaseFormTitle.Size = new Size(174, 44);
            purchaseFormTitle.TabIndex = 13;
            purchaseFormTitle.Text = "Purchase";
            // 
            // creditCardFormLink
            // 
            creditCardFormLink.ActiveLinkColor = Color.ForestGreen;
            creditCardFormLink.AutoSize = true;
            creditCardFormLink.LinkColor = Color.Lime;
            creditCardFormLink.Location = new Point(185, 201);
            creditCardFormLink.Name = "creditCardFormLink";
            creditCardFormLink.Size = new Size(180, 26);
            creditCardFormLink.TabIndex = 15;
            creditCardFormLink.TabStop = true;
            creditCardFormLink.Text = "Credit Card Form";
            creditCardFormLink.LinkClicked += creditCardFormLink_LinkClicked;
            // 
            // purchaseNameLabel
            // 
            purchaseNameLabel.AutoSize = true;
            purchaseNameLabel.Font = new Font("Microsoft JhengHei UI", 20.25F);
            purchaseNameLabel.ForeColor = Color.White;
            purchaseNameLabel.Location = new Point(73, 257);
            purchaseNameLabel.Name = "purchaseNameLabel";
            purchaseNameLabel.Size = new Size(92, 35);
            purchaseNameLabel.TabIndex = 17;
            purchaseNameLabel.Text = "Name";
            // 
            // purchaseNameValue
            // 
            purchaseNameValue.BackColor = Color.FromArgb(65, 65, 65);
            purchaseNameValue.BorderStyle = BorderStyle.None;
            purchaseNameValue.Font = new Font("Microsoft JhengHei UI", 20.25F);
            purchaseNameValue.ForeColor = Color.White;
            purchaseNameValue.Location = new Point(260, 257);
            purchaseNameValue.Margin = new Padding(5);
            purchaseNameValue.Name = "purchaseNameValue";
            purchaseNameValue.Size = new Size(218, 35);
            purchaseNameValue.TabIndex = 16;
            // 
            // purchaseAmountLabel
            // 
            purchaseAmountLabel.AutoSize = true;
            purchaseAmountLabel.Font = new Font("Microsoft JhengHei UI", 20.25F);
            purchaseAmountLabel.ForeColor = Color.White;
            purchaseAmountLabel.Location = new Point(73, 383);
            purchaseAmountLabel.Name = "purchaseAmountLabel";
            purchaseAmountLabel.Size = new Size(118, 35);
            purchaseAmountLabel.TabIndex = 20;
            purchaseAmountLabel.Text = "Amount";
            // 
            // purchaseAmountValue
            // 
            purchaseAmountValue.BackColor = Color.FromArgb(65, 65, 65);
            purchaseAmountValue.BorderStyle = BorderStyle.None;
            purchaseAmountValue.Font = new Font("Microsoft JhengHei UI", 20.25F);
            purchaseAmountValue.ForeColor = Color.White;
            purchaseAmountValue.Location = new Point(260, 383);
            purchaseAmountValue.Margin = new Padding(5);
            purchaseAmountValue.Name = "purchaseAmountValue";
            purchaseAmountValue.Size = new Size(218, 35);
            purchaseAmountValue.TabIndex = 19;
            // 
            // viewAllPurchasesLink
            // 
            viewAllPurchasesLink.ActiveLinkColor = Color.ForestGreen;
            viewAllPurchasesLink.AutoSize = true;
            viewAllPurchasesLink.LinkColor = Color.Lime;
            viewAllPurchasesLink.Location = new Point(178, 448);
            viewAllPurchasesLink.Name = "viewAllPurchasesLink";
            viewAllPurchasesLink.Size = new Size(195, 26);
            viewAllPurchasesLink.TabIndex = 23;
            viewAllPurchasesLink.TabStop = true;
            viewAllPurchasesLink.Text = "View All Purchases";
            viewAllPurchasesLink.LinkClicked += viewAllPurchasesLink_LinkClicked;
            // 
            // createPurchaseButton
            // 
            createPurchaseButton.BackColor = Color.Lime;
            createPurchaseButton.FlatAppearance.BorderColor = Color.Black;
            createPurchaseButton.FlatAppearance.MouseDownBackColor = Color.Green;
            createPurchaseButton.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            createPurchaseButton.FlatStyle = FlatStyle.Flat;
            createPurchaseButton.Location = new Point(182, 505);
            createPurchaseButton.Name = "createPurchaseButton";
            createPurchaseButton.Size = new Size(186, 36);
            createPurchaseButton.TabIndex = 26;
            createPurchaseButton.Text = "Create Purchase";
            createPurchaseButton.UseVisualStyleBackColor = false;
            createPurchaseButton.Click += createPurchaseButton_Click;
            // 
            // purchaseCategoryDropdown
            // 
            purchaseCategoryDropdown.BackColor = Color.FromArgb(65, 65, 65);
            purchaseCategoryDropdown.FlatStyle = FlatStyle.Flat;
            purchaseCategoryDropdown.ForeColor = Color.White;
            purchaseCategoryDropdown.FormattingEnabled = true;
            purchaseCategoryDropdown.Location = new Point(260, 317);
            purchaseCategoryDropdown.Name = "purchaseCategoryDropdown";
            purchaseCategoryDropdown.Size = new Size(218, 34);
            purchaseCategoryDropdown.TabIndex = 28;
            purchaseCategoryDropdown.SelectedIndexChanged += purchaseCategoryDropdown_SelectedIndexChanged;
            // 
            // purchaseCategoryLabel
            // 
            purchaseCategoryLabel.AutoSize = true;
            purchaseCategoryLabel.Font = new Font("Microsoft JhengHei UI", 20.25F);
            purchaseCategoryLabel.ForeColor = Color.White;
            purchaseCategoryLabel.Location = new Point(73, 317);
            purchaseCategoryLabel.Name = "purchaseCategoryLabel";
            purchaseCategoryLabel.Size = new Size(131, 35);
            purchaseCategoryLabel.TabIndex = 27;
            purchaseCategoryLabel.Text = "Category";
            // 
            // PurchaseForm
            // 
            AutoScaleDimensions = new SizeF(12F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 35, 35);
            ClientSize = new Size(551, 568);
            Controls.Add(purchaseCategoryDropdown);
            Controls.Add(purchaseCategoryLabel);
            Controls.Add(createPurchaseButton);
            Controls.Add(viewAllPurchasesLink);
            Controls.Add(purchaseAmountLabel);
            Controls.Add(purchaseAmountValue);
            Controls.Add(purchaseNameLabel);
            Controls.Add(purchaseNameValue);
            Controls.Add(creditCardFormLink);
            Controls.Add(creditCardLabel);
            Controls.Add(purchaseFormTitle);
            Controls.Add(creditCardDropdown);
            Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5);
            Name = "PurchaseForm";
            Text = "Purchase Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox creditCardDropdown;
        private Label creditCardLabel;
        private Label purchaseFormTitle;
        private LinkLabel creditCardFormLink;
        private Label purchaseNameLabel;
        private TextBox purchaseNameValue;
        private Label purchaseAmountLabel;
        private TextBox purchaseAmountValue;
        private LinkLabel viewAllPurchasesLink;
        private Button createPurchaseButton;
        private ComboBox purchaseCategoryDropdown;
        private Label purchaseCategoryLabel;
    }
}