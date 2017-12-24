using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace Payroll
{
    public partial class PayrollForm : Form
    {

        private Roster roster;
        private HourlyEmployee selectedEmployee;
        private string fileName;



        public PayrollForm()
        {
            InitializeComponent();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "BIN files (*.bin)|*.BIN";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.Title = "Select Payroll Data File";
            fileName = null;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                roster = Roster.ReadFromFile(fileName);
            }
            else
                roster = new Roster();
            LoadEmployeeList();
            dateHiredTimePicker.Enabled = false;

        }

        private void LoadEmployeeList()
        {
            listEmployee.Items.Clear();
            var ssnSorted =
              from e in roster
              orderby e.SSN
              select e;
            foreach (var e in ssnSorted)
                listEmployee.Items.Add(e.SSN);
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            textBoxSsn.Enabled = true;
            textBoxSsn.Clear();
            textBoxFirstname.Clear();
            textBoxLastName.Clear();
            textBoxMi.Clear();
            dateHiredTimePicker.Value = DateTime.Today;
            dateHiredTimePicker.Enabled = true;
            textBoxRate.Clear();
            textBoxHoursWorked.Clear();
            textBoxEarnings.Clear();
            textBoxEarnings.Enabled = false;
            selectedEmployee = new HourlyEmployee();
        }

        private void listEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedEmployee = (HourlyEmployee)roster.Find((string)listEmployee.SelectedItem);
                textBoxSsn.Text = selectedEmployee.SSN;
                textBoxSsn.Enabled = false;
                textBoxLastName.Text = selectedEmployee.LastName;
                textBoxFirstname.Text = selectedEmployee.FirstName;
                textBoxMi.Text = selectedEmployee.MiddleInitial.ToString();
                dateHiredTimePicker.Value = selectedEmployee.DateHired;
                dateHiredTimePicker.Enabled = true;
                textBoxEarnings.Text = selectedEmployee.Earnings().ToString("C");
                textBoxEarnings.Enabled = false;
                textBoxRate.Text = selectedEmployee.PayRate.ToString();
                textBoxHoursWorked.Text = selectedEmployee.CurrentHoursWorked.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Choose an employee SSN ");
                return;
            }


        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            char mi = ' ';
            if (textBoxMi.Text.Length == 1)
                mi = textBoxMi.Text.ToCharArray()[0];
            string ssn = textBoxSsn.Text;
            string first = textBoxFirstname.Text;
            string last = textBoxLastName.Text;
            DateTime dt;
            try
            {
                dt = dateHiredTimePicker.Value;
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Invalid date hired");
                return;
            }
            decimal rate;
            try
            {
                rate = Convert.ToDecimal(textBoxRate.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Invalid rate");
                return;
            }
            int hours;
            try
            {
                hours = Convert.ToInt32(textBoxHoursWorked.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Invalid hours worked");
                return;
            }
            try
            {
                selectedEmployee.SSN = ssn;
                selectedEmployee.FirstName = first;
                selectedEmployee.LastName = last;
                selectedEmployee.MiddleInitial = mi;
                selectedEmployee.DateHired = dt;
                selectedEmployee.PayRate = rate;
                selectedEmployee.CurrentHoursWorked = hours;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
                return;
            }
            if (textBoxSsn.Enabled)
            {
                Employee emp = roster.Find(selectedEmployee.SSN);
                if (emp == null)
                {
                    roster.Add(selectedEmployee);
                    LoadEmployeeList();
                    textBoxSsn.Enabled = false;
                }
                else
                {
                    MessageBox.Show(this, "SSN already on file");
                    return;
                }
            }
            textBoxEarnings.Text = selectedEmployee.Earnings().ToString("C");
        }

     

        private void onClose(object sender, FormClosedEventArgs e)
        {
            if (fileName == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.Filter = "BIN files (*.bin)|*.BIN";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.CheckFileExists = false;
                saveFileDialog.Title = "Save Payroll Data File";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                    roster.WriteToFile(fileName);
                }
            }
            else
                roster.WriteToFile(fileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchForm form = new SearchForm();
            form.ShowDialog();
            if (form.search == false) return;
            string last = form.lastNameTextBox.Text;
            string first = form.firstNameTextBox.Text;
            char mi = ' ';
            if (form.middleInitialTextBox.Text.Length == 1)
                mi = form.middleInitialTextBox.Text.ToCharArray()[0];
            HourlyEmployee emp = (HourlyEmployee)roster.Find(last, first, mi);
            if (emp == null)
            {
                MessageBox.Show("Employee not found");
                return;
            }
            listEmployee.SelectedIndex = listEmployee.Items.IndexOf(emp.SSN);
        }
    }
}
