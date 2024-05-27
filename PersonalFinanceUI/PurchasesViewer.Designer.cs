namespace PersonalFinanceUI
{
    partial class PurchasesViewer
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            CreditCardLabel = new Label();
            PurchasesFormTitle = new Label();
            creditCardDropdown = new ComboBox();
            purchasesGridView = new DataGridView();
            BalanceLabel = new Label();
            balanceValue = new TextBox();
            creditCardFormLink = new LinkLabel();
            createPurchaseLink = new LinkLabel();
            dashboardLink = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)purchasesGridView).BeginInit();
            SuspendLayout();
            // 
            // CreditCardLabel
            // 
            CreditCardLabel.AutoSize = true;
            CreditCardLabel.Font = new Font("Microsoft JhengHei UI", 20.25F);
            CreditCardLabel.ForeColor = Color.White;
            CreditCardLabel.Location = new Point(51, 124);
            CreditCardLabel.Name = "CreditCardLabel";
            CreditCardLabel.Size = new Size(159, 35);
            CreditCardLabel.TabIndex = 17;
            CreditCardLabel.Text = "Credit Card";
            // 
            // PurchasesFormTitle
            // 
            PurchasesFormTitle.AutoSize = true;
            PurchasesFormTitle.Font = new Font("Microsoft JhengHei UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PurchasesFormTitle.ForeColor = Color.White;
            PurchasesFormTitle.Location = new Point(414, 20);
            PurchasesFormTitle.Name = "PurchasesFormTitle";
            PurchasesFormTitle.Size = new Size(191, 44);
            PurchasesFormTitle.TabIndex = 16;
            PurchasesFormTitle.Text = "Purchases";
            // 
            // creditCardDropdown
            // 
            creditCardDropdown.BackColor = Color.FromArgb(65, 65, 65);
            creditCardDropdown.FlatStyle = FlatStyle.Flat;
            creditCardDropdown.ForeColor = Color.White;
            creditCardDropdown.FormattingEnabled = true;
            creditCardDropdown.Location = new Point(238, 124);
            creditCardDropdown.Name = "creditCardDropdown";
            creditCardDropdown.Size = new Size(218, 34);
            creditCardDropdown.TabIndex = 15;
            creditCardDropdown.SelectedIndexChanged += creditCardDropdown_SelectedIndexChanged;
            // 
            // purchasesGridView
            // 
            purchasesGridView.Anchor = AnchorStyles.Top;
            purchasesGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            purchasesGridView.BackgroundColor = Color.FromArgb(35, 35, 35);
            purchasesGridView.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(35, 35, 35);
            dataGridViewCellStyle4.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = Color.Lime;
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            purchasesGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            purchasesGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            purchasesGridView.ColumnHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(35, 35, 35);
            dataGridViewCellStyle5.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = Color.Lime;
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            purchasesGridView.DefaultCellStyle = dataGridViewCellStyle5;
            purchasesGridView.Location = new Point(56, 253);
            purchasesGridView.Name = "purchasesGridView";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(35, 35, 35);
            dataGridViewCellStyle6.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = Color.Lime;
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            purchasesGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            purchasesGridView.RowHeadersVisible = false;
            purchasesGridView.Size = new Size(907, 220);
            purchasesGridView.TabIndex = 18;
            // 
            // BalanceLabel
            // 
            BalanceLabel.AutoSize = true;
            BalanceLabel.Font = new Font("Microsoft JhengHei UI", 20.25F);
            BalanceLabel.ForeColor = Color.White;
            BalanceLabel.Location = new Point(553, 124);
            BalanceLabel.Name = "BalanceLabel";
            BalanceLabel.Size = new Size(113, 35);
            BalanceLabel.TabIndex = 22;
            BalanceLabel.Text = "Balance";
            // 
            // balanceValue
            // 
            balanceValue.BackColor = Color.FromArgb(65, 65, 65);
            balanceValue.BorderStyle = BorderStyle.None;
            balanceValue.Font = new Font("Microsoft JhengHei UI", 20.25F);
            balanceValue.ForeColor = Color.White;
            balanceValue.Location = new Point(740, 124);
            balanceValue.Margin = new Padding(5);
            balanceValue.Name = "balanceValue";
            balanceValue.Size = new Size(218, 35);
            balanceValue.TabIndex = 21;
            // 
            // creditCardFormLink
            // 
            creditCardFormLink.ActiveLinkColor = Color.ForestGreen;
            creditCardFormLink.AutoSize = true;
            creditCardFormLink.LinkColor = Color.Lime;
            creditCardFormLink.Location = new Point(51, 500);
            creditCardFormLink.Name = "creditCardFormLink";
            creditCardFormLink.Size = new Size(180, 26);
            creditCardFormLink.TabIndex = 23;
            creditCardFormLink.TabStop = true;
            creditCardFormLink.Text = "Credit Card Form";
            creditCardFormLink.LinkClicked += creditCardFormLink_LinkClicked;
            // 
            // createPurchaseLink
            // 
            createPurchaseLink.ActiveLinkColor = Color.ForestGreen;
            createPurchaseLink.AutoSize = true;
            createPurchaseLink.LinkColor = Color.Lime;
            createPurchaseLink.Location = new Point(422, 500);
            createPurchaseLink.Name = "createPurchaseLink";
            createPurchaseLink.Size = new Size(174, 26);
            createPurchaseLink.TabIndex = 24;
            createPurchaseLink.TabStop = true;
            createPurchaseLink.Text = "Create Purchase";
            createPurchaseLink.LinkClicked += createPurchaseLink_LinkClicked;
            // 
            // dashboardLink
            // 
            dashboardLink.ActiveLinkColor = Color.ForestGreen;
            dashboardLink.AutoSize = true;
            dashboardLink.LinkColor = Color.Lime;
            dashboardLink.Location = new Point(846, 500);
            dashboardLink.Name = "dashboardLink";
            dashboardLink.Size = new Size(122, 26);
            dashboardLink.TabIndex = 25;
            dashboardLink.TabStop = true;
            dashboardLink.Text = "Dashboard";
            dashboardLink.LinkClicked += dashboardLink_LinkClicked;
            // 
            // PurchasesViewer
            // 
            AutoScaleDimensions = new SizeF(12F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 35, 35);
            ClientSize = new Size(1019, 559);
            Controls.Add(dashboardLink);
            Controls.Add(createPurchaseLink);
            Controls.Add(creditCardFormLink);
            Controls.Add(BalanceLabel);
            Controls.Add(balanceValue);
            Controls.Add(purchasesGridView);
            Controls.Add(CreditCardLabel);
            Controls.Add(PurchasesFormTitle);
            Controls.Add(creditCardDropdown);
            Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5);
            Name = "PurchasesViewer";
            Text = "Purchases Viewer";
            ((System.ComponentModel.ISupportInitialize)purchasesGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CreditCardLabel;
        private Label PurchasesFormTitle;
        private ComboBox creditCardDropdown;
        private DataGridView purchasesGridView;
        private Label BalanceLabel;
        private TextBox balanceValue;
        private LinkLabel creditCardFormLink;
        private LinkLabel createPurchaseLink;
        private LinkLabel dashboardLink;
    }
}