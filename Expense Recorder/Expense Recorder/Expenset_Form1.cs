using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseRecorder
{
    public partial class ExpenseRecorder : Form
    {


        private ExpenseItemRoster roster;
        private ExpenseItem selectedExpense;
        private string fileName;


        public ExpenseRecorder()
        {
            InitializeComponent();

            // Adding List of values for Payment Method Drop Down
            comboBoxPayment.Items.Add("Cash");
            comboBoxPayment.Items.Add("Cheque");
            comboBoxPayment.Items.Add("myDiscover");
            comboBoxPayment.Items.Add("myVisa");
            comboBoxPayment.Items.Add("myMaster");
            comboBoxPayment.Items.Add("myAmericanExpress");


            // Adding List of values for Expense Trip Drop Down 
            comboBoxTrip.Items.Add("Australia Sale meeting");
            comboBoxTrip.Items.Add("Australia Conference");
            comboBoxTrip.Items.Add("Chicago Sale meeting");
            comboBoxTrip.Items.Add("Chicago Conference");
            comboBoxTrip.Items.Add("Denver Sale meeting");
            comboBoxTrip.Items.Add("Denver Conference");
            comboBoxTrip.Items.Add("New York Sale meeting");
            comboBoxTrip.Items.Add("New York Conference");
            comboBoxTrip.Items.Add("Orlando Sale meeting");
            comboBoxTrip.Items.Add("Orlando Conference");
            comboBoxTrip.Items.Add("Local sales call");
            comboBoxTrip.Items.Add("Emergency customer call");
            comboBoxTrip.Items.Add("Sales Material purchase");


            // Adding List of values for Filter Drop Down
            comboBoxFilter.Items.Add("All");
            comboBoxFilter.Items.Add("Trip");

            comboBoxFilter.Enabled = true;
            textBoxTotalExepense.Enabled = false;
            buttonCloseOut.Enabled = false;
            

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "BIN files (*.bin)|*.BIN";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.Title = "Select Expenses Data File";
            fileName = null;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                roster = ExpenseItemRoster.ReadFromFile(fileName);
            }
            else
                roster = new ExpenseItemRoster();
            LoadExpensesList();
            textBoxTotalExepense.Text = roster.TotalAmount().ToString("C");
            dateTimePickerExpense.Enabled = false;
            textBoxAmount.Enabled = true;
        }
            private void LoadExpensesList()
        {
            listExpense.Items.Clear();
            var DateSorted =
              from e in roster
              orderby e.Date
              select e;
            foreach (var e in DateSorted)
            listExpense.Items.Add(e);
            textBoxTotalExepense.Text = roster.TotalAmount().ToString("C");
            buttonCloseOut.Enabled = false;
            dateTimePickerExpense.Enabled = false;
            textBoxAmount.Enabled = true;
        }

    

        private void LoadExpensesListTrip()
        {
            listExpense.Items.Clear();
            var TripSorted =
              from e in roster
              where e.Trip == "Australia Sale meeting" || e.Trip != "Australia Conference" || e.Trip != "Chicago Sale meeting" || e.Trip != "Chicago Conference" || e.Trip != "Denver Sale meeting" || e.Trip != "Denver Conference" || e.Trip != "New York Sale meeting" || e.Trip != "New York Conference" || e.Trip != "Orlando Sale meeting" || e.Trip != "Orlando Conference"
              where e.Trip != "Local sales call" && e.Trip != "Emergency customer call" && e.Trip != "Sales Material purchase"
              orderby e.Trip
              select e;
            foreach (var e in TripSorted)
                listExpense.Items.Add(e);
            textBoxTotalExepense.Text = TotalAmountTrip().ToString("C");
            dateTimePickerExpense.Enabled = false;
            textBoxAmount.Enabled = true;
        }

        private void DeleteTrip()
        {
            ExpenseItem ext = (ExpenseItem)listExpense.SelectedItem;
            var DltTrp =
            from e in roster
            where e.Trip == ext.Trip
            orderby e.Trip
            select e;
            foreach (var e in DltTrp)
            {
                ExpenseItem emp2 = DltTrp.ElementAt(0);
                roster.Remove(emp2);
                
            }
            LoadExpensesList();
        }

        public decimal TotalAmountTrip()
        {
            Decimal TtlTrip = 0;
            var TripSorted =
              from e in roster
              where e.Trip == "Australia Sale meeting" || e.Trip != "Australia Conference" || e.Trip != "Chicago Sale meeting" || e.Trip != "Chicago Conference" || e.Trip != "Denver Sale meeting" || e.Trip != "Denver Conference" || e.Trip != "New York Sale meeting" || e.Trip != "New York Conference" || e.Trip != "Orlando Sale meeting" || e.Trip != "Orlando Conference"
              where e.Trip != "Local sales call" && e.Trip != "Emergency customer call" && e.Trip != "Sales Material purchase"
              orderby e.Trip
              select e;
            foreach (var e in TripSorted)
            {
                TtlTrip += e.Amount;
            }
            return TtlTrip;
        }    
        


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            textBoxTotalExepense.Clear();
            textBoxTotalExepense.Enabled = false;
            dateTimePickerExpense.Value = DateTime.Today;
            dateTimePickerExpense.Enabled = true;
            comboBoxTrip.ResetText();
            textBoxDescription.Clear();
            textBoxNote.Clear();
            textBoxAmount.Clear();
            comboBoxPayment.ResetText();            
            comboBoxFilter.ResetText();
            comboBoxFilter.Enabled = true;
            textBoxAmount.Enabled = true;
            selectedExpense = new ExpenseItem();
        }
        private void listExpense_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ExpenseItem exp = (ExpenseItem)listExpense.SelectedItem;
                selectedExpense = roster.Find(exp);
                textBoxAmount.Text = selectedExpense.Amount.ToString("C");
                comboBoxTrip.Text = selectedExpense.Trip;
                textBoxDescription.Text = selectedExpense.Description;
                textBoxNote.Text = selectedExpense.Note;
                comboBoxPayment.Text = selectedExpense.PaymentMethod;
                dateTimePickerExpense.Value = selectedExpense.Date;
                dateTimePickerExpense.Enabled = true;
                textBoxTotalExepense.Enabled = false;
                textBoxAmount.Enabled = true;
                textBoxTotalExepense.Text = roster.TotalAmount().ToString("C");
            }
            catch(Exception )
            {
                MessageBox.Show(this, "Choose an expense item");
                return;
            }

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {            
            string Trp = comboBoxTrip.Text;
            string desc;
            try
            {
                desc = textBoxDescription.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
                return;
            }
            string nte = textBoxNote.Text;
            string pay;
            try
            {
                pay = comboBoxPayment.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
                return;
            }

            DateTime dt;
            try
            {
                dt = dateTimePickerExpense.Value;
            }

            catch (Exception)
            {
                MessageBox.Show(this, "Invalid Date");
                return;
            }
            decimal amot;
            try
            {
                amot = Convert.ToDecimal(textBoxAmount.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Invalid Amount | Remove the $ sign");
                return;
            }

            try
            {
                selectedExpense.Amount = amot;
                selectedExpense.Description = desc;
                selectedExpense.PaymentMethod = pay;
                selectedExpense.Trip = Trp;
                selectedExpense.Note = nte;
                selectedExpense.Date = dt;
            }

            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
                return;
            }

            try
            {
                ExpenseItem exp3 = roster.Find(selectedExpense);
                if (exp3 == null)
                {
                    roster.Add(selectedExpense);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
                return;
            }
            LoadExpensesList();
            textBoxTotalExepense.Enabled = false;
            dateTimePickerExpense.Value = DateTime.Today;
            dateTimePickerExpense.Enabled = true;
            comboBoxTrip.ResetText();
            textBoxDescription.Clear();
            textBoxNote.Clear();
            textBoxAmount.Clear();
            comboBoxPayment.ResetText();
            comboBoxFilter.ResetText();
            comboBoxFilter.Enabled = true;
        }

        private void ExpenseRecorder_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (fileName == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.Filter = "BIN files (*.bin)|*.BIN";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.CheckFileExists = false;
                saveFileDialog.Title = "Save Expenses Data File";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                    roster.WriteToFile(fileName);
                }
            }
            else
                roster.WriteToFile(fileName);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {     
            ExpenseItem exp = (ExpenseItem)listExpense.SelectedItem;
            roster.Delete(exp);           
            LoadExpensesList();                      
        }

        private void buttonCloseOut_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteTrip();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Choose an Trip expense Item to Close Out the Trip ");
                return;
            }

            textBoxAmount.Text = selectedExpense.Amount.ToString("C");
            comboBoxTrip.Text = selectedExpense.Trip;
            textBoxDescription.Text = selectedExpense.Description;
            textBoxNote.Text = selectedExpense.Note;
            comboBoxPayment.Text = selectedExpense.PaymentMethod;
            dateTimePickerExpense.Value = selectedExpense.Date;
            dateTimePickerExpense.Enabled = true;
            textBoxTotalExepense.Enabled = false;
            textBoxAmount.Enabled = true;
            textBoxTotalExepense.Text = roster.TotalAmount().ToString("C");
        }

        private void textBoxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
          (e.KeyChar != '.') && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }           
        }

        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFilter.SelectedIndex == 1)
            {
                buttonCloseOut.Enabled = true;
                LoadExpensesListTrip();
            }
            if (comboBoxFilter.SelectedIndex == 0)
            {
                buttonCloseOut.Enabled = false;
                LoadExpensesList();
            }
        }
    }
}

