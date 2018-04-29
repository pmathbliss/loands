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

            //= new DataTable();
            loans.Columns.Add(new DataColumn("ID", typeof(String)));
            loans.Columns.Add(new DataColumn("Total", typeof(Double)));
            loans.Columns.Add(new DataColumn("Rate", typeof(Double)));
            loans.Columns.Add(new DataColumn("Minimum", typeof(Double)));
            loans.Columns.Add(new DataColumn("AmountLeft", typeof(Double)));
            loans.Columns.Add(new DataColumn("LastPaymentAmount", typeof(Double)));
            loans.Columns.Add(new DataColumn("InterestPaidAmount", typeof(Double)));
            loans.Columns.Add(new DataColumn("MinimumPayoff", typeof(DateTime)));



            if (Properties.Settings.Default.LoansData.Length > 0)
            {
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(Properties.Settings.Default.LoansData);

                var home = dt.Columns["InterestPaidAmount"];
                home.ColumnName = "InterestPaidAmount";
                dt.Columns.Remove(home);

                loans.Merge(dt);
            }


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

            Retotal(true);
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
                if (payments.Rows.Count == 0)
                {
                    payments.Columns.Add(new DataColumn("Date", typeof(DateTime)));
                    payments.Columns.Add(new DataColumn("Payment", typeof(Double)));
                    schedule.Columns.Add(new DataColumn("Date", typeof(DateTime)));
                    schedule.Columns.Add(new DataColumn("Payment", typeof(Double)));
                    int idx = 1;

                    dgvPayments.Columns[idx].DefaultCellStyle.Format = "c";
                    dgvSchedule.Columns[idx].DefaultCellStyle.Format = "c";
                    foreach (DataRow loanRows in loans.Rows)
                    {
                        idx++;
                        string loanKey = $"Loan {loanRows["ID"].ToString()}";
                        loanRows["AmountLeft"] = loanRows["Total"];
                        loanRows["LastPaymentAmount"] = Decimal.Zero;
                        //loanRows["Date"] = lastPayment;
                        payments.Columns.Add(new DataColumn(loanKey, typeof(Double)));
                        schedule.Columns.Add(new DataColumn(loanKey, typeof(Double)));

                        dgvPayments.Columns[idx].DefaultCellStyle.Format = "c";
                        dgvSchedule.Columns[idx].DefaultCellStyle.Format = "c";
                        //payments.Rows.Add()
                    }
                }
                int months = Properties.Settings.Default.Months;


                for (var i = 0; i < months; i++)
                {
                    FirstMonth();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            btnAddLoan.Enabled = true;

            Retotal();

            Cursor.Current = Cursors.Default;

            dgvPayments.ResumeLayout();
            dgvSchedule.ResumeLayout();

        }

        private void Retotal(bool exclude = false)
        {
            decimal amount = loans.Compute("SUM(Total)", "").CastTo<Decimal>();

            txtTotalLoans.Text = amount.ToInvariantString();


             amount = loans.Compute("SUM(AmountLeft)", "").CastTo<Decimal>();

            txtAmountLeft.Text = amount.ToInvariantString();


            if(!exclude)
            {
                amount = loans.Compute("SUM(InterestPaidAmount)", "").CastTo<Decimal>();

                txtTotalInterest.Text = amount.ToInvariantString();
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
        }

        private void MoreMonth()
        {

            decimal monthly = Properties.Settings.Default.MonthlyPayment;

            DataRow paymentsRow = payments.NewRow();
            paymentsRow["Payment"] = monthly;

            DataRow latestMoney = schedule.Select().Last<DataRow>();
            paymentsRow["Date"] = DateTime.Parse(latestMoney["Date"].ToString());

            decimal left = monthly;

            string minLoanKey = "";
            string minLoanKey2 = "";
            decimal minTotal = 999999999;
            decimal minTotal2 = 999999999;

            foreach (DataRow loan in loans.Rows)
            {
                string loanKey = $"Loan {loan["ID"].ToString()}";
                decimal minAmount = Decimal.Parse(loan["Minimum"].ToString());
                string money = latestMoney[loanKey].ToString();
                decimal loanLeft = Decimal.Parse(money.Contains("E")?"0":money);

                if(Math.Abs(loanLeft) <= (Decimal).19)
                {
                    paymentsRow[loanKey] = Decimal.Zero;
                    continue;
                }

                decimal rate = Decimal.Parse(loan["Rate"].ToString());

                loanLeft = loanLeft * (1 + rate / 1200);

                decimal loanAfterPayment = loanLeft > minAmount ? loanLeft - minAmount:0 ;

                paymentsRow[loanKey] = loanLeft > minAmount?minAmount:loanLeft;

                left -= (loanLeft > minAmount ? minAmount :  loanLeft);

                if(loanAfterPayment > 0 && minTotal > loanAfterPayment)
                {
                    minLoanKey2 = minLoanKey;
                    minLoanKey = loanKey;
                    minTotal2 = minTotal;
                    minTotal = loanAfterPayment;
                }
            }

            if (left > decimal.Zero)
            {
                decimal minPaymentAmount = Decimal.Parse(paymentsRow[minLoanKey].ToString());

                paymentsRow[minLoanKey] = (minPaymentAmount + left-minTotal) > 0? minTotal : minPaymentAmount + left;

                left -= (minPaymentAmount + left - minTotal) > 0 ? minTotal :  left;
            }

            if (left > decimal.Zero && minLoanKey2 != "")
            {
                decimal minPaymentAmount = Decimal.Parse(paymentsRow[minLoanKey2].ToString());

                paymentsRow[minLoanKey2] = (minPaymentAmount + left - minTotal2) > 0 ? minTotal2 : left;

                left -= (minPaymentAmount + left - minTotal2) > 0 ? minTotal2 :  left;

                paymentsRow[minLoanKey] = latestMoney[minLoanKey];
            }

            AddScheduleRow(paymentsRow);

            payments.Rows.Add(paymentsRow);

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
                interestPaid += (rate / 1200) * amountLeft;
                amountLeft = amountPlusInterest - minAmount < 0 ? 0 : amountPlusInterest - minAmount;
                lastPayment = amountPlusInterest - amountLeft;
                loan["AmountLeft"] = amountLeft;
                loan["LastPaymentAmount"] = lastPayment;
                loan["InterestPaidAmount"] = interestPaid;
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
            payments.Rows.Add(paymentRow);
            schedule.Rows.Add(scheduleRow);
        }
        
        private void AddScheduleRow(DataRow loadRow)
        {
            if (schedule.Rows.Count == 0)
            {
                schedule.Columns.Add(new DataColumn("Date", typeof(DateTime)));
                var firstRow = schedule.NewRow();
                firstRow["Date"] = DateTime.Now;
                foreach (DataRow loanRows in loans.Rows)
                {
                    schedule.Columns.Add(new DataColumn($"Loan {loanRows["ID"].ToString()}", typeof(Double)));
                    firstRow[$"Loan {loanRows["ID"].ToString()}"] = loanRows["Total"];
                }
                schedule.Rows.Add(firstRow);
            }

            var lastRow = schedule.Select("", "Date DESC").First<DataRow>();
            var newRow = schedule.NewRow();
            newRow["Date"] = DateTime.Parse(lastRow["Date"].ToString()).AddMonths(1);

            foreach (DataRow loanRow in loans.Rows)
            {
                string loanKey = $"Loan {loanRow["ID"].ToString()}";

                decimal rate = Decimal.Parse(loanRow["Rate"].ToString());

                decimal previousAmount = Decimal.Zero;
                Decimal.TryParse(lastRow[loanKey].ToString(), out previousAmount);
                decimal paymentAmount = Decimal.Zero;
                Decimal.TryParse(loadRow[loanKey].ToString(), out paymentAmount);

                if(rate > 0)
                {
                    newRow[loanKey] = previousAmount * (1 + rate / 1200) - paymentAmount;
                }
                else
                {
                    newRow[loanKey] = previousAmount  - paymentAmount;
                }
                loanRow["AmountLeft"] = newRow[loanKey];
            }

            schedule.Rows.Add(newRow);


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

            foreach (DataRow loanRows in loans.Rows)
            {
                string loanKey = $"Loan {loanRows["ID"].ToString()}";
                loanRows["AmountLeft"] = loanRows["Total"];
                loanRows["LastPaymentAmount"] = Decimal.Zero;
                //loanRows["Date"] = lastPayment;
                payments.Columns.Add(new DataColumn(loanKey, typeof(Double)));
                schedule.Columns.Add(new DataColumn(loanKey, typeof(Double)));

            }
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
