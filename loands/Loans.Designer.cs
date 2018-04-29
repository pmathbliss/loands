namespace loands
{
    partial class Loans
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbAnalysis = new System.Windows.Forms.GroupBox();
            this.tcAnalysis = new System.Windows.Forms.TabControl();
            this.tpLoans = new System.Windows.Forms.TabPage();
            this.dgvLoans = new System.Windows.Forms.DataGridView();
            this.tpPayments = new System.Windows.Forms.TabPage();
            this.dgvPayments = new System.Windows.Forms.DataGridView();
            this.tpSchedule = new System.Windows.Forms.TabPage();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.gbAddLoan = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudMonths = new System.Windows.Forms.NumericUpDown();
            this.txtMonthlyPayment = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblMonthlyPayment = new System.Windows.Forms.Label();
            this.btnAddLoan = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gbStatistic = new System.Windows.Forms.GroupBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblTotalLoans = new System.Windows.Forms.Label();
            this.lblTotalInterest = new System.Windows.Forms.Label();
            this.txtTotalLoans = new System.Windows.Forms.TextBox();
            this.txtTotalInterest = new System.Windows.Forms.TextBox();
            this.txtAmountLeft = new System.Windows.Forms.TextBox();
            this.lblAmountLeft = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Minimum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountLeft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastPaymentAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InterestPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinimumPayoff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.gbAnalysis.SuspendLayout();
            this.tcAnalysis.SuspendLayout();
            this.tpLoans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).BeginInit();
            this.tpPayments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).BeginInit();
            this.tpSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.gbAddLoan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonths)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbStatistic.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(913, 499);
            this.panel1.TabIndex = 0;
            // 
            // gbAnalysis
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gbAnalysis, 2);
            this.gbAnalysis.Controls.Add(this.tcAnalysis);
            this.gbAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAnalysis.Location = new System.Drawing.Point(3, 109);
            this.gbAnalysis.Name = "gbAnalysis";
            this.gbAnalysis.Size = new System.Drawing.Size(907, 387);
            this.gbAnalysis.TabIndex = 0;
            this.gbAnalysis.TabStop = false;
            this.gbAnalysis.Text = "Analysis";
            // 
            // tcAnalysis
            // 
            this.tcAnalysis.Controls.Add(this.tpLoans);
            this.tcAnalysis.Controls.Add(this.tpPayments);
            this.tcAnalysis.Controls.Add(this.tpSchedule);
            this.tcAnalysis.Controls.Add(this.tabPage1);
            this.tcAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcAnalysis.Location = new System.Drawing.Point(3, 16);
            this.tcAnalysis.Name = "tcAnalysis";
            this.tcAnalysis.SelectedIndex = 0;
            this.tcAnalysis.Size = new System.Drawing.Size(901, 368);
            this.tcAnalysis.TabIndex = 0;
            // 
            // tpLoans
            // 
            this.tpLoans.Controls.Add(this.dgvLoans);
            this.tpLoans.Location = new System.Drawing.Point(4, 22);
            this.tpLoans.Name = "tpLoans";
            this.tpLoans.Padding = new System.Windows.Forms.Padding(3);
            this.tpLoans.Size = new System.Drawing.Size(893, 342);
            this.tpLoans.TabIndex = 0;
            this.tpLoans.Text = "Loans";
            this.tpLoans.UseVisualStyleBackColor = true;
            // 
            // dgvLoans
            // 
            this.dgvLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoans.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Total,
            this.Minimum,
            this.Rate,
            this.AmountLeft,
            this.LastPaymentAmount,
            this.InterestPaid,
            this.MinimumPayoff});
            this.dgvLoans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoans.Location = new System.Drawing.Point(3, 3);
            this.dgvLoans.Name = "dgvLoans";
            this.dgvLoans.Size = new System.Drawing.Size(887, 336);
            this.dgvLoans.TabIndex = 0;
            // 
            // tpPayments
            // 
            this.tpPayments.Controls.Add(this.dgvPayments);
            this.tpPayments.Location = new System.Drawing.Point(4, 22);
            this.tpPayments.Name = "tpPayments";
            this.tpPayments.Padding = new System.Windows.Forms.Padding(3);
            this.tpPayments.Size = new System.Drawing.Size(893, 342);
            this.tpPayments.TabIndex = 1;
            this.tpPayments.Text = "Payments";
            this.tpPayments.UseVisualStyleBackColor = true;
            // 
            // dgvPayments
            // 
            this.dgvPayments.AllowUserToAddRows = false;
            this.dgvPayments.AllowUserToDeleteRows = false;
            this.dgvPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPayments.Location = new System.Drawing.Point(3, 3);
            this.dgvPayments.Name = "dgvPayments";
            this.dgvPayments.ShowEditingIcon = false;
            this.dgvPayments.ShowRowErrors = false;
            this.dgvPayments.Size = new System.Drawing.Size(887, 336);
            this.dgvPayments.TabIndex = 0;
            // 
            // tpSchedule
            // 
            this.tpSchedule.Controls.Add(this.dgvSchedule);
            this.tpSchedule.Location = new System.Drawing.Point(4, 22);
            this.tpSchedule.Name = "tpSchedule";
            this.tpSchedule.Padding = new System.Windows.Forms.Padding(3);
            this.tpSchedule.Size = new System.Drawing.Size(893, 342);
            this.tpSchedule.TabIndex = 2;
            this.tpSchedule.Text = "Schedule";
            this.tpSchedule.UseVisualStyleBackColor = true;
            this.tpSchedule.UseWaitCursor = true;
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.AllowUserToAddRows = false;
            this.dgvSchedule.AllowUserToDeleteRows = false;
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSchedule.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSchedule.Location = new System.Drawing.Point(3, 3);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.ShowEditingIcon = false;
            this.dgvSchedule.ShowRowErrors = false;
            this.dgvSchedule.Size = new System.Drawing.Size(887, 336);
            this.dgvSchedule.TabIndex = 0;
            this.dgvSchedule.VirtualMode = true;
            // 
            // gbAddLoan
            // 
            this.gbAddLoan.AutoSize = true;
            this.gbAddLoan.Controls.Add(this.btnExportExcel);
            this.gbAddLoan.Controls.Add(this.btnReset);
            this.gbAddLoan.Controls.Add(this.label1);
            this.gbAddLoan.Controls.Add(this.nudMonths);
            this.gbAddLoan.Controls.Add(this.txtMonthlyPayment);
            this.gbAddLoan.Controls.Add(this.btnSave);
            this.gbAddLoan.Controls.Add(this.lblMonthlyPayment);
            this.gbAddLoan.Controls.Add(this.btnAddLoan);
            this.gbAddLoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAddLoan.Location = new System.Drawing.Point(3, 3);
            this.gbAddLoan.MinimumSize = new System.Drawing.Size(395, 85);
            this.gbAddLoan.Name = "gbAddLoan";
            this.gbAddLoan.Size = new System.Drawing.Size(395, 100);
            this.gbAddLoan.TabIndex = 0;
            this.gbAddLoan.TabStop = false;
            this.gbAddLoan.Text = "Add Loan";
            this.gbAddLoan.Enter += new System.EventHandler(this.gbAddLoan_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Months";
            // 
            // nudMonths
            // 
            this.nudMonths.Location = new System.Drawing.Point(106, 51);
            this.nudMonths.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMonths.Name = "nudMonths";
            this.nudMonths.Size = new System.Drawing.Size(100, 20);
            this.nudMonths.TabIndex = 11;
            this.nudMonths.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudMonths.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtMonthlyPayment
            // 
            this.txtMonthlyPayment.Location = new System.Drawing.Point(106, 20);
            this.txtMonthlyPayment.Name = "txtMonthlyPayment";
            this.txtMonthlyPayment.Size = new System.Drawing.Size(100, 20);
            this.txtMonthlyPayment.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(227, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.toolTip1.SetToolTip(this.btnSave, "Save loan information");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblMonthlyPayment
            // 
            this.lblMonthlyPayment.AutoSize = true;
            this.lblMonthlyPayment.Location = new System.Drawing.Point(12, 23);
            this.lblMonthlyPayment.Name = "lblMonthlyPayment";
            this.lblMonthlyPayment.Size = new System.Drawing.Size(88, 13);
            this.lblMonthlyPayment.TabIndex = 8;
            this.lblMonthlyPayment.Text = "Monthly Payment";
            // 
            // btnAddLoan
            // 
            this.btnAddLoan.Location = new System.Drawing.Point(227, 51);
            this.btnAddLoan.Name = "btnAddLoan";
            this.btnAddLoan.Size = new System.Drawing.Size(75, 23);
            this.btnAddLoan.TabIndex = 4;
            this.btnAddLoan.Text = "Calculate";
            this.toolTip1.SetToolTip(this.btnAddLoan, "Calculate windfall style payment to loans");
            this.btnAddLoan.UseVisualStyleBackColor = true;
            this.btnAddLoan.Click += new System.EventHandler(this.btnAddLoan_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(308, 17);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Reset";
            this.toolTip1.SetToolTip(this.btnReset, "Reset Loan Payment and schedule tables");
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gbAnalysis, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.gbAddLoan, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbStatistic, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(913, 499);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(308, 51);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExportExcel.TabIndex = 14;
            this.btnExportExcel.Text = "Export";
            this.toolTip1.SetToolTip(this.btnExportExcel, "Export tables to Excel");
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // gbStatistic
            // 
            this.gbStatistic.Controls.Add(this.txtAmountLeft);
            this.gbStatistic.Controls.Add(this.lblAmountLeft);
            this.gbStatistic.Controls.Add(this.txtTotalInterest);
            this.gbStatistic.Controls.Add(this.txtTotalLoans);
            this.gbStatistic.Controls.Add(this.lblTotalInterest);
            this.gbStatistic.Controls.Add(this.lblTotalLoans);
            this.gbStatistic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbStatistic.Location = new System.Drawing.Point(404, 3);
            this.gbStatistic.Name = "gbStatistic";
            this.gbStatistic.Size = new System.Drawing.Size(506, 100);
            this.gbStatistic.TabIndex = 1;
            this.gbStatistic.TabStop = false;
            this.gbStatistic.Text = "Box";
            this.gbStatistic.Enter += new System.EventHandler(this.gbStatistic_Enter);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(893, 342);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblTotalLoans
            // 
            this.lblTotalLoans.AutoSize = true;
            this.lblTotalLoans.Location = new System.Drawing.Point(3, 16);
            this.lblTotalLoans.Name = "lblTotalLoans";
            this.lblTotalLoans.Size = new System.Drawing.Size(31, 13);
            this.lblTotalLoans.TabIndex = 0;
            this.lblTotalLoans.Text = "Total";
            // 
            // lblTotalInterest
            // 
            this.lblTotalInterest.AutoSize = true;
            this.lblTotalInterest.Location = new System.Drawing.Point(3, 45);
            this.lblTotalInterest.Name = "lblTotalInterest";
            this.lblTotalInterest.Size = new System.Drawing.Size(42, 13);
            this.lblTotalInterest.TabIndex = 2;
            this.lblTotalInterest.Text = "Interest";
            // 
            // txtTotalLoans
            // 
            this.txtTotalLoans.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalLoans.Enabled = false;
            this.txtTotalLoans.Location = new System.Drawing.Point(51, 13);
            this.txtTotalLoans.Name = "txtTotalLoans";
            this.txtTotalLoans.Size = new System.Drawing.Size(100, 13);
            this.txtTotalLoans.TabIndex = 3;
            // 
            // txtTotalInterest
            // 
            this.txtTotalInterest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalInterest.Enabled = false;
            this.txtTotalInterest.Location = new System.Drawing.Point(51, 42);
            this.txtTotalInterest.Name = "txtTotalInterest";
            this.txtTotalInterest.Size = new System.Drawing.Size(100, 13);
            this.txtTotalInterest.TabIndex = 4;
            // 
            // txtAmountLeft
            // 
            this.txtAmountLeft.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAmountLeft.Enabled = false;
            this.txtAmountLeft.Location = new System.Drawing.Point(51, 72);
            this.txtAmountLeft.Name = "txtAmountLeft";
            this.txtAmountLeft.Size = new System.Drawing.Size(100, 13);
            this.txtAmountLeft.TabIndex = 6;
            // 
            // lblAmountLeft
            // 
            this.lblAmountLeft.AutoSize = true;
            this.lblAmountLeft.Location = new System.Drawing.Point(3, 75);
            this.lblAmountLeft.Name = "lblAmountLeft";
            this.lblAmountLeft.Size = new System.Drawing.Size(25, 13);
            this.lblAmountLeft.TabIndex = 5;
            this.lblAmountLeft.Text = "Left";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            dataGridViewCellStyle1.NullValue = null;
            this.ID.DefaultCellStyle = dataGridViewCellStyle1;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle2;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // Minimum
            // 
            this.Minimum.DataPropertyName = "Minimum";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.Minimum.DefaultCellStyle = dataGridViewCellStyle3;
            this.Minimum.HeaderText = "Minimum";
            this.Minimum.Name = "Minimum";
            // 
            // Rate
            // 
            this.Rate.DataPropertyName = "Rate";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N4";
            dataGridViewCellStyle4.NullValue = "0";
            this.Rate.DefaultCellStyle = dataGridViewCellStyle4;
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            // 
            // AmountLeft
            // 
            this.AmountLeft.DataPropertyName = "AmountLeft";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.AmountLeft.DefaultCellStyle = dataGridViewCellStyle5;
            this.AmountLeft.HeaderText = "Amount Left";
            this.AmountLeft.Name = "AmountLeft";
            this.AmountLeft.ReadOnly = true;
            // 
            // LastPaymentAmount
            // 
            this.LastPaymentAmount.DataPropertyName = "LastPaymentAmount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.LastPaymentAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.LastPaymentAmount.HeaderText = "Last Payment";
            this.LastPaymentAmount.Name = "LastPaymentAmount";
            this.LastPaymentAmount.ReadOnly = true;
            // 
            // InterestPaid
            // 
            this.InterestPaid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.InterestPaid.DataPropertyName = "InterestPaidAmount";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.InterestPaid.DefaultCellStyle = dataGridViewCellStyle7;
            this.InterestPaid.HeaderText = "Interest Paid";
            this.InterestPaid.Name = "InterestPaid";
            this.InterestPaid.ReadOnly = true;
            this.InterestPaid.Width = 91;
            // 
            // MinimumPayoff
            // 
            this.MinimumPayoff.DataPropertyName = "MinimumPayoff";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "d";
            dataGridViewCellStyle8.NullValue = null;
            this.MinimumPayoff.DefaultCellStyle = dataGridViewCellStyle8;
            this.MinimumPayoff.HeaderText = "Minimum Payoff";
            this.MinimumPayoff.Name = "MinimumPayoff";
            this.MinimumPayoff.ReadOnly = true;
            // 
            // Loans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 499);
            this.Controls.Add(this.panel1);
            this.Name = "Loans";
            this.Text = "Loans";
            this.panel1.ResumeLayout(false);
            this.gbAnalysis.ResumeLayout(false);
            this.tcAnalysis.ResumeLayout(false);
            this.tpLoans.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).EndInit();
            this.tpPayments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).EndInit();
            this.tpSchedule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.gbAddLoan.ResumeLayout(false);
            this.gbAddLoan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonths)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.gbStatistic.ResumeLayout(false);
            this.gbStatistic.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbAnalysis;
        private System.Windows.Forms.TabControl tcAnalysis;
        private System.Windows.Forms.TabPage tpLoans;
        private System.Windows.Forms.DataGridView dgvLoans;
        private System.Windows.Forms.TabPage tpPayments;
        private System.Windows.Forms.GroupBox gbAddLoan;
        private System.Windows.Forms.Button btnAddLoan;
        private System.Windows.Forms.Label lblMonthlyPayment;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvPayments;
        private System.Windows.Forms.TextBox txtMonthlyPayment;
        private System.Windows.Forms.TabPage tpSchedule;
        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudMonths;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gbStatistic;
        private System.Windows.Forms.Label lblTotalInterest;
        private System.Windows.Forms.Label lblTotalLoans;
        private System.Windows.Forms.TextBox txtTotalInterest;
        private System.Windows.Forms.TextBox txtTotalLoans;
        private System.Windows.Forms.TextBox txtAmountLeft;
        private System.Windows.Forms.Label lblAmountLeft;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Minimum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountLeft;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastPaymentAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn InterestPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinimumPayoff;
    }
}

