namespace PersonalFinanceUI
{
    partial class DepositForm
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
            depositAmountLabel = new Label();
            depositFormTitle = new Label();
            createDepositButton = new Button();
            depositNameLabel = new Label();
            depositCategoryLabel = new Label();
            depositAmountValue = new TextBox();
            depositNameValue = new TextBox();
            depositCategoryDropdown = new ComboBox();
            dashboardLink = new LinkLabel();
            SuspendLayout();
            // 
            // depositAmountLabel
            // 
            depositAmountLabel.AutoSize = true;
            depositAmountLabel.Font = new Font("Microsoft JhengHei UI", 20.25F);
            depositAmountLabel.ForeColor = Color.White;
            depositAmountLabel.Location = new Point(36, 174);
            depositAmountLabel.Name = "depositAmountLabel";
            depositAmountLabel.Size = new Size(118, 35);
            depositAmountLabel.TabIndex = 12;
            depositAmountLabel.Text = "Amount";
            // 
            // depositFormTitle
            // 
            depositFormTitle.AutoSize = true;
            depositFormTitle.Font = new Font("Microsoft JhengHei UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            depositFormTitle.ForeColor = Color.White;
            depositFormTitle.Location = new Point(98, 24);
            depositFormTitle.Name = "depositFormTitle";
            depositFormTitle.Size = new Size(248, 44);
            depositFormTitle.TabIndex = 11;
            depositFormTitle.Text = "Deposit Form";
            // 
            // createDepositButton
            // 
            createDepositButton.BackColor = Color.Lime;
            createDepositButton.FlatAppearance.BorderColor = Color.Black;
            createDepositButton.FlatAppearance.MouseDownBackColor = Color.Green;
            createDepositButton.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            createDepositButton.FlatStyle = FlatStyle.Flat;
            createDepositButton.Location = new Point(156, 316);
            createDepositButton.Name = "createDepositButton";
            createDepositButton.Size = new Size(133, 36);
            createDepositButton.TabIndex = 13;
            createDepositButton.Text = "Deposit";
            createDepositButton.UseVisualStyleBackColor = false;
            createDepositButton.Click += createDepositButton_Click;
            // 
            // depositNameLabel
            // 
            depositNameLabel.AutoSize = true;
            depositNameLabel.Font = new Font("Microsoft JhengHei UI", 20.25F);
            depositNameLabel.ForeColor = Color.White;
            depositNameLabel.Location = new Point(36, 110);
            depositNameLabel.Name = "depositNameLabel";
            depositNameLabel.Size = new Size(92, 35);
            depositNameLabel.TabIndex = 19;
            depositNameLabel.Text = "Name";
            // 
            // depositCategoryLabel
            // 
            depositCategoryLabel.AutoSize = true;
            depositCategoryLabel.Font = new Font("Microsoft JhengHei UI", 20.25F);
            depositCategoryLabel.ForeColor = Color.White;
            depositCategoryLabel.Location = new Point(36, 239);
            depositCategoryLabel.Name = "depositCategoryLabel";
            depositCategoryLabel.Size = new Size(131, 35);
            depositCategoryLabel.TabIndex = 21;
            depositCategoryLabel.Text = "Category";
            // 
            // depositAmountValue
            // 
            depositAmountValue.BackColor = Color.FromArgb(65, 65, 65);
            depositAmountValue.BorderStyle = BorderStyle.None;
            depositAmountValue.Font = new Font("Microsoft JhengHei UI", 20.25F);
            depositAmountValue.ForeColor = Color.White;
            depositAmountValue.Location = new Point(190, 174);
            depositAmountValue.Margin = new Padding(5);
            depositAmountValue.Name = "depositAmountValue";
            depositAmountValue.Size = new Size(218, 35);
            depositAmountValue.TabIndex = 10;
            // 
            // depositNameValue
            // 
            depositNameValue.BackColor = Color.FromArgb(65, 65, 65);
            depositNameValue.BorderStyle = BorderStyle.None;
            depositNameValue.Font = new Font("Microsoft JhengHei UI", 20.25F);
            depositNameValue.ForeColor = Color.White;
            depositNameValue.Location = new Point(190, 110);
            depositNameValue.Margin = new Padding(5);
            depositNameValue.Name = "depositNameValue";
            depositNameValue.Size = new Size(218, 35);
            depositNameValue.TabIndex = 18;
            // 
            // depositCategoryDropdown
            // 
            depositCategoryDropdown.BackColor = Color.FromArgb(65, 65, 65);
            depositCategoryDropdown.FlatStyle = FlatStyle.Flat;
            depositCategoryDropdown.ForeColor = Color.White;
            depositCategoryDropdown.FormattingEnabled = true;
            depositCategoryDropdown.Location = new Point(190, 239);
            depositCategoryDropdown.Name = "depositCategoryDropdown";
            depositCategoryDropdown.Size = new Size(218, 34);
            depositCategoryDropdown.TabIndex = 22;
            depositCategoryDropdown.SelectedIndexChanged += depositCategoryDropdown_SelectedIndexChanged;
            // 
            // dashboardLink
            // 
            dashboardLink.ActiveLinkColor = Color.ForestGreen;
            dashboardLink.AutoSize = true;
            dashboardLink.LinkColor = Color.Lime;
            dashboardLink.Location = new Point(161, 382);
            dashboardLink.Name = "dashboardLink";
            dashboardLink.Size = new Size(122, 26);
            dashboardLink.TabIndex = 26;
            dashboardLink.TabStop = true;
            dashboardLink.Text = "Dashboard";
            dashboardLink.LinkClicked += dashboardLink_LinkClicked;
            // 
            // DepositForm
            // 
            AutoScaleDimensions = new SizeF(12F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 35, 35);
            ClientSize = new Size(445, 431);
            Controls.Add(dashboardLink);
            Controls.Add(depositCategoryDropdown);
            Controls.Add(depositCategoryLabel);
            Controls.Add(depositNameLabel);
            Controls.Add(depositNameValue);
            Controls.Add(createDepositButton);
            Controls.Add(depositAmountLabel);
            Controls.Add(depositFormTitle);
            Controls.Add(depositAmountValue);
            Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5);
            Name = "DepositForm";
            Text = "Deposit Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label depositAmountLabel;
        private Label depositFormTitle;
        private Button createDepositButton;
        private Label depositNameLabel;
        private Label depositCategoryLabel;
        private TextBox depositAmountValue;
        private TextBox depositNameValue;
        private ComboBox depositCategoryDropdown;
        private LinkLabel dashboardLink;
    }
}