using ClosedXML.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace loands
{
    public partial class Loans : Form
    {
        private DataTable loans = new DataTable();
        private DataTable payments = new DataTable();
        private DataTable schedule = new DataTable();
        private DateTime lastPayment = DateTime.Now;

        public Loans()
        {
            ImportSavedLoans();
            //= new DataTable();


            InitializeComponent();
            //need to pause drawing
            dgvLoans.SuspendLayout();
            dgvLoans.DataSource = loans;
            dgvLoans.ResumeLayout();
            dgvPayments.SuspendLayout();
            dgvPayments.DataSource = payments;
            dgvPayments.ResumeLayout();
            dgvSchedule.SuspendLayout();
            dgvSchedule.DataSource = schedule;
            dgvSchedule.ResumeLayout();
            txtMonthlyPayment.DataBindings.Add("Text", Properties.Settings.Default, "MonthlyPayment");
            nudMonths.DataBindings.Add("Value", Properties.Settings.Default, "Months");
            cbPaymentFrequency.DataBindings.Add("SelectedItem", Properties.Settings.Default, "PaymentFrequency");
            
            Retotal(true);
        }

        private void ImportSavedLoans()
        {
            loans.Columns.Add(new DataColumn("ID", typeof(String)));
            loans.Columns.Add(new DataColumn("Total", typeof(Double)) { DefaultValue = 0 });
            loans.Columns.Add(new DataColumn("Rate", typeof(Double)) { DefaultValue = 0 });
            loans.Columns.Add(new DataColumn("Minimum", typeof(Double)) { DefaultValue = 0 });
            loans.Columns.Add(new DataColumn("AmountLeft", typeof(Double)) { DefaultValue = 0 });

            if (Properties.Settings.Default.LoansData.Length > 0)
            {
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(Properties.Settings.Default.LoansData);

                //columns we dont want to import
                DataColumn home = dt.Columns["InterestPaidAmount"];
                home.ColumnName = "InterestPaidAmount";
                dt.Columns.Remove(home);
                home = dt.Columns["LastPaymentAmount"];
                dt.Columns.Remove(home);
                home = dt.Columns["MinimumPayoff"];
                dt.Columns.Remove(home);

                loans.Merge(dt);
            }
            loans.Columns.Add(new DataColumn("LastPaymentAmount", typeof(Double)) { DefaultValue = 0 });
            loans.Columns.Add(new DataColumn("MinimumPayoff", typeof(DateTime)) { });
            loans.Columns.Add(new DataColumn("InterestPaidAmount", typeof(Double)) { DefaultValue = 0 });
            loans.Columns.Add(new DataColumn("LastInterestPaid", typeof(Double)) { DefaultValue = 0 });
            loans.Columns.Add(new DataColumn("LastPaymentDate", typeof(DateTime)) { });
        }

        private DateTime NumberOfPayments(double rate, double presentValue, double paymentAmount, double paymentsPerYear = 12.0)
        {
            double paymentsNumber = 0;

            paymentsNumber = (-1.0) * (Math.Log10(1.0 - (presentValue*rate/100)/(paymentAmount* paymentsPerYear)))/(paymentsPerYear * Math.Log10(1.0 + rate/(paymentsPerYear * 100)));

            return DateTime.Now.AddYears((int)paymentsNumber);
        }

        private void btnAddLoan_Click(object sender, EventArgs e)
        {
            dgvPayments.SuspendLayout();
            dgvSchedule.SuspendLayout();
            btnAddLoan.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                InitMonth();
                
                int months = Properties.Settings.Default.Months;

                if (cbPayoffLoan.Checked)
                {
                    int runs = 0;
                                        
                    while (runs < 1000 && CalculateAmountLeft() > 0)
                    {
                        runs++;
                        FirstMonth();
                    }
                }
                else
                {
                    for (var i = 0; i < months; i++)
                    {
                        FirstMonth();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            btnAddLoan.Enabled = true;

            try
            {
                cLoans.DataBindTable(loans.DefaultView, "ID");
            }
            catch(Exception ex)
            {

            }
            Retotal();

            Cursor.Current = Cursors.Default;

            dgvPayments.ResumeLayout();
            dgvSchedule.ResumeLayout();

        }

        private decimal CalculateAmountLeft()
        {
            decimal amount = loans.Compute("SUM(AmountLeft)", "").CastTo<Decimal>();
            return amount;
        }

        private void InitMonth()
        {
            if (schedule.Rows.Count > 0)
            {
                return;
            }

            lastPayment = DateTime.Now;
            
            if(payments.Columns.Count == 0)
            {
                payments.Columns.Add(new DataColumn("Date", typeof(DateTime)));
                payments.Columns.Add(new DataColumn("Payment", typeof(Double)));
                payments.Columns.Add(new DataColumn("LastInterestPaid", typeof(Double)) { DefaultValue = 0});
                //LastPaymentAmount
            }
            if (schedule.Columns.Count == 0)
            {
                schedule.Columns.Add(new DataColumn("Date", typeof(DateTime)));
                schedule.Columns.Add(new DataColumn("Payment", typeof(Double)) { DefaultValue = 0 });
                schedule.Columns.Add(new DataColumn("LastInterestPaid", typeof(Double)) { DefaultValue = 0 });
            }
            int idx = 1;

            DataRow initScheduleRow = schedule.NewRow();

            initScheduleRow["Date"] = lastPayment;

            //dgvPayments.Columns[idx].DefaultCellStyle.Format = "c";
            //dgvSchedule.Columns[idx].DefaultCellStyle.Format = "c";
            foreach (DataRow loanRows in loans.Rows)
            {
                idx++;
                string loanKey = $"Loan {loanRows["ID"].ToString()}";
                loanRows["AmountLeft"] = loanRows["Total"];
                loanRows["LastPaymentAmount"] = Decimal.Zero;
                payments.Columns.Add(new DataColumn(loanKey, typeof(Double)) { DefaultValue = 0 });
                schedule.Columns.Add(new DataColumn(loanKey, typeof(Double)) { DefaultValue = 0 });
                initScheduleRow[loanKey] = loanRows["Total"];

                
            }

            schedule.Rows.Add(initScheduleRow);

            foreach (DataRow loanRows in loans.Rows)
            {
                idx++;
                string loanKey = $"Loan {loanRows["ID"].ToString()}";
                try
                {
                    dgvPayments.Columns[loanKey].DefaultCellStyle.Format = "c";
                    dgvSchedule.Columns[loanKey].DefaultCellStyle.Format = "c";
                }
                catch(Exception ex)
                {

                }
            }

        }

        private void Retotal(bool exclude = false)
        {
            decimal amount = loans.Compute("SUM(Total)", "").CastTo<Decimal>();

            txtTotalLoans.Text = string.Format("{0:C}",amount.ToInvariantString());

            amount = loans.Compute("SUM(AmountLeft)", "").CastTo<Decimal>();

            txtAmountLeft.Text = string.Format("{0:C}",amount.ToInvariantString());

            amount = loans.Compute("SUM(Minimum)", "").CastTo<Decimal>();

            txtMinimumPayment.Text = string.Format("{0:C}",amount.ToInvariantString());

            txtPaymentsMade.Text = payments.Rows.Count.ToString();
            
            int count = loans.Select("AmountLeft > 0").Count();

            txtLoansLeft.Text = count.ToInvariantString();


            if (!exclude)
            {
                amount = loans.Compute("SUM(InterestPaidAmount)", "").CastTo<Decimal>();

                txtTotalInterest.Text = string.Format("{0:C}", amount.ToInvariantString());
            }


            decimal amountLeft = Decimal.Zero;
            decimal minAmount = Decimal.Zero;
            decimal total = Decimal.Zero;
            decimal rate = Decimal.Zero;
            decimal lastPayment = Decimal.Zero;
            decimal interestPaid = Decimal.Zero;
            decimal amountPlusInterest = Decimal.Zero;
            foreach (DataRow loan in loans.Rows)
            {

                Decimal.TryParse(loan["Minimum"].ToString(), out minAmount);
                Decimal.TryParse(loan["Total"].ToString(), out total);
                Decimal.TryParse(loan["AmountLeft"].ToString(), out amountLeft);
                Decimal.TryParse(loan["Rate"].ToString(), out rate);
                Decimal.TryParse(loan["InterestPaidAmount"].ToString(), out interestPaid);
                loan["MinimumPayoff"] = NumberOfPayments((double)rate, (double)total, (double)minAmount);
            }
            cLoans.Update();

        }
        
        private void FirstMonth()
        {
            decimal monthly = Properties.Settings.Default.MonthlyPayment;

            //DataRow loadRow = payments.NewRow();
            //loadRow["Date"] = DateTime.Now;
           // loadRow["Payment"] = monthly;

            DataRow minRow = loans.Select("Total > 0", "Total DESC").First<DataRow>();

            decimal left = monthly;
            string loanKey = "";
            decimal amountLeft = Decimal.Zero;
            decimal minAmount = Decimal.Zero;
            decimal total = Decimal.Zero;
            decimal rate = Decimal.Zero;
            decimal lastPayment = Decimal.Zero;
            decimal interestPaid = Decimal.Zero;
            decimal loanInterestPaid = Decimal.Zero;
            decimal amountPlusInterest = Decimal.Zero;
            DataRow[] sortedLoans = loans.Select("Total > 0", "Total DESC");
            foreach (DataRow loan in sortedLoans)
            {
                lastPayment = Decimal.Zero;
                loanKey = $"Loan {loan["ID"].ToString()}";
                Decimal.TryParse(loan["Minimum"].ToString(), out minAmount);
                Decimal.TryParse(loan["Total"].ToString(), out total);
                Decimal.TryParse(loan["AmountLeft"].ToString(),out amountLeft);
                Decimal.TryParse(loan["Rate"].ToString(), out rate);
                Decimal.TryParse(loan["InterestPaidAmount"].ToString(), out interestPaid);

                if (total == 0 || amountLeft == 0)
                {
                    continue;
                }
                amountPlusInterest = (1 + rate / 1200) * amountLeft;
                loanInterestPaid = (rate / 1200) * amountLeft;
                interestPaid += loanInterestPaid;

                amountLeft = amountPlusInterest - minAmount < 0 ? 0 : amountPlusInterest - minAmount;
                lastPayment = amountPlusInterest - amountLeft;
                loan["AmountLeft"] = amountLeft;
                loan["LastPaymentAmount"] = lastPayment;
                loan["InterestPaidAmount"] = interestPaid;
                loan["LastInterestPaid"] = loanInterestPaid;
                loan["LastPaymentDate"] = this.lastPayment;
                //LastPaymentDate
                //LastInterestPaid
                // loadRow[loanKey] = lastPayment;
                left -= lastPayment;

                //minRow = loan;
            }

            //reverse the array, apply the rest of the overage
            foreach(DataRow loan in sortedLoans.Reverse())
            {
                if(left <= Decimal.Zero)
                {
                    break;
                }

                lastPayment = Decimal.Zero;
                loanKey = $"Loan {loan["ID"].ToString()}";
                Decimal.TryParse(loan["Minimum"].ToString(), out minAmount);
                Decimal.TryParse(loan["Total"].ToString(), out total);
                Decimal.TryParse(loan["AmountLeft"].ToString(), out amountLeft);
                Decimal.TryParse(loan["Rate"].ToString(), out rate);

                if(left > amountLeft)
                {
                    amountLeft = 0;
                    lastPayment += amountLeft;
                    left -= amountLeft;
                }
                else
                {
                    amountLeft -= left;
                    lastPayment += left;
                    left = 0;
                }
                loan["AmountLeft"] = amountLeft;
                loan["LastPaymentAmount"] = lastPayment;

            }
            
            AddSchedulePaymentRow();

        }

        private void AddSchedulePaymentRow()
        {
            DataRow paymentRow = payments.NewRow();
            DataRow scheduleRow = schedule.NewRow();

            decimal monthly = Properties.Settings.Default.MonthlyPayment;

            lastPayment = lastPayment.AddMonths(1);

            foreach (DataRow loanRow in loans.Rows)
            {
                string loanKey = $"Loan {loanRow["ID"].ToString()}";

                paymentRow[loanKey] = loanRow["LastPaymentAmount"];
                paymentRow["Date"] = lastPayment;
                paymentRow["Payment"] = monthly;
                scheduleRow["Date"] = lastPayment;
                scheduleRow["Payment"] = monthly;
                scheduleRow[loanKey] = loanRow["AmountLeft"];
            }
            scheduleRow["LastInterestPaid"] = loans.Compute("SUM(LastInterestPaid)", "LastPaymentAmount > 0").CastTo<Decimal>();

            txtLastInterestPaid.Text = string.Format("{0:C}", scheduleRow["LastInterestPaid"].ToInvariantString());
            paymentRow["LastInterestPaid"] = scheduleRow["LastInterestPaid"];
            payments.Rows.Add(paymentRow);
            schedule.Rows.Add(scheduleRow);
        }
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(loans);

                Properties.Settings.Default.LoansData = JSONresult;
                Properties.Settings.Default.Save();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
            btnSave.Enabled = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            payments = new DataTable();
            schedule = new DataTable();
            lastPayment = DateTime.Now;

            foreach (DataRow loanRows in loans.Rows)
            {
                string loanKey = $"Loan {loanRows["ID"].ToString()}";
                loanRows["AmountLeft"] = loanRows["Total"];
                loanRows["LastPaymentAmount"] = Decimal.Zero;
                loanRows["InterestPaidAmount"] = Decimal.Zero;
                loanRows["LastInterestPaid"] = Decimal.Zero;
            }


            dgvPayments.DataSource = null;
            dgvPayments.Rows.Clear();
            dgvSchedule.DataSource = schedule;

            dgvSchedule.DataSource = null;
            dgvSchedule.Rows.Clear();
            dgvSchedule.DataSource = schedule;
            

            dgvPayments.Refresh();
            dgvSchedule.Refresh();
            InitMonth();
            Retotal();
        }

        private void gbAddLoan_Enter(object sender, EventArgs e)
        {

        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            String folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            //Codes for the Closed XML
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(loans, "Loans");
                wb.Worksheets.Add(payments, "Payments");
                wb.Worksheets.Add(schedule, "Schedule");

                wb.SaveAs(Path.Combine(folderPath, "Loans.xlsx"));
            }
            Process.Start(Path.Combine(folderPath, "Loans.xlsx"));
        }

        private void gbStatistic_Enter(object sender, EventArgs e)
        {

        }

        private void M_Click(object sender, EventArgs e)
        {

        }

        private void cbPayoffLoan_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;
            nudMonths.Enabled = !checkbox.Checked;
        }

        private void dgvLoans_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public static class Extensions
    {
        public static string ToXml(this DataSet ds)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (TextWriter streamWriter = new StreamWriter(memoryStream))
                {
                    var xmlSerializer = new XmlSerializer(typeof(DataSet));
                    xmlSerializer.Serialize(streamWriter, ds);
                    return Encoding.UTF8.GetString(memoryStream.ToArray());
                }
            }
        }
        public static string ToXml(this DataTable dt)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (TextWriter streamWriter = new StreamWriter(memoryStream))
                {
                    var xmlSerializer = new XmlSerializer(typeof(DataTable));
                    xmlSerializer.Serialize(streamWriter, dt);
                    return Encoding.UTF8.GetString(memoryStream.ToArray());
                }
            }
        }
    }
}
