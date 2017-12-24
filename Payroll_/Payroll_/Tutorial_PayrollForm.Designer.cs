namespace Payroll
{
    partial class PayrollForm
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
            this.listEmployee = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxSsn = new System.Windows.Forms.TextBox();
            this.textBoxFirstname = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxMi = new System.Windows.Forms.TextBox();
            this.dateHiredTimePicker = new System.Windows.Forms.DateTimePicker();
            this.textBoxRate = new System.Windows.Forms.TextBox();
            this.textBoxHoursWorked = new System.Windows.Forms.TextBox();
            this.textBoxEarnings = new System.Windows.Forms.TextBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listEmployee
            // 
            this.listEmployee.FormattingEnabled = true;
            this.listEmployee.Location = new System.Drawing.Point(12, 12);
            this.listEmployee.Name = "listEmployee";
            this.listEmployee.Size = new System.Drawing.Size(120, 264);
            this.listEmployee.TabIndex = 0;
            this.listEmployee.SelectedIndexChanged += new System.EventHandler(this.listEmployee_SelectedIndexChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(30, 282);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textBoxSsn
            // 
            this.textBoxSsn.Location = new System.Drawing.Point(322, 21);
            this.textBoxSsn.MaxLength = 9;
            this.textBoxSsn.Name = "textBoxSsn";
            this.textBoxSsn.Size = new System.Drawing.Size(100, 20);
            this.textBoxSsn.TabIndex = 2;
            // 
            // textBoxFirstname
            // 
            this.textBoxFirstname.Location = new System.Drawing.Point(235, 58);
            this.textBoxFirstname.Name = "textBoxFirstname";
            this.textBoxFirstname.Size = new System.Drawing.Size(124, 20);
            this.textBoxFirstname.TabIndex = 3;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(375, 57);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(112, 20);
            this.textBoxLastName.TabIndex = 4;
            // 
            // textBoxMi
            // 
            this.textBoxMi.Location = new System.Drawing.Point(507, 58);
            this.textBoxMi.MaxLength = 1;
            this.textBoxMi.Name = "textBoxMi";
            this.textBoxMi.Size = new System.Drawing.Size(31, 20);
            this.textBoxMi.TabIndex = 5;
            // 
            // dateHiredTimePicker
            // 
            this.dateHiredTimePicker.Location = new System.Drawing.Point(235, 94);
            this.dateHiredTimePicker.Name = "dateHiredTimePicker";
            this.dateHiredTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateHiredTimePicker.TabIndex = 6;
            // 
            // textBoxRate
            // 
            this.textBoxRate.Location = new System.Drawing.Point(235, 136);
            this.textBoxRate.Name = "textBoxRate";
            this.textBoxRate.Size = new System.Drawing.Size(100, 20);
            this.textBoxRate.TabIndex = 7;
            // 
            // textBoxHoursWorked
            // 
            this.textBoxHoursWorked.Location = new System.Drawing.Point(303, 180);
            this.textBoxHoursWorked.Name = "textBoxHoursWorked";
            this.textBoxHoursWorked.Size = new System.Drawing.Size(31, 20);
            this.textBoxHoursWorked.TabIndex = 8;
            // 
            // textBoxEarnings
            // 
            this.textBoxEarnings.Location = new System.Drawing.Point(235, 219);
            this.textBoxEarnings.Name = "textBoxEarnings";
            this.textBoxEarnings.Size = new System.Drawing.Size(100, 20);
            this.textBoxEarnings.TabIndex = 9;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(322, 252);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(100, 23);
            this.buttonUpdate.TabIndex = 10;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Social Security Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Date Hired";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Rate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Hours Worked";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(156, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Earnings";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(463, 282);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PayrollForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 314);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.textBoxEarnings);
            this.Controls.Add(this.textBoxHoursWorked);
            this.Controls.Add(this.textBoxRate);
            this.Controls.Add(this.dateHiredTimePicker);
            this.Controls.Add(this.textBoxMi);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxFirstname);
            this.Controls.Add(this.textBoxSsn);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listEmployee);
            this.Name = "PayrollForm";
            this.Text = "Payroll";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onClose);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxSsn;
        private System.Windows.Forms.TextBox textBoxFirstname;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxMi;
        private System.Windows.Forms.DateTimePicker dateHiredTimePicker;
        private System.Windows.Forms.TextBox textBoxRate;
        private System.Windows.Forms.TextBox textBoxHoursWorked;
        private System.Windows.Forms.TextBox textBoxEarnings;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ListBox listEmployee;
    }
}

