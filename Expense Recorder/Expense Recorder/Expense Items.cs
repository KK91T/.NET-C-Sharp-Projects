using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace ExpenseRecorder
{
    [Serializable]
    public class ExpenseItem
    {
        private string description;
        private decimal amount;
        private string paymentMethod;
        private string trip;
        private string note;
        private DateTime date;

        public ExpenseItem()
        {
            // This is the default constructor
        }

        public ExpenseItem(DateTime DATE, string trip, string description, decimal amt, string payrate, string note)
        { 
            Description = description;
            Amount = amt;
            PaymentMethod = payrate;
            Trip = trip;
            Note = note;
            Date = DATE;
        }

        public string Description //accessor methods (property)
        {
            get
            {
                return description;
            }
            set
            {
                string n = value.Trim();
                if (n.Length != 0)
                    description = value;
                else
                    throw new Exception("Description Required");
            }
        }
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }
        public decimal Amount //accessor methods (property)
        {
            get
            {
                return amount;
            }
            set
            {
                if (value <= 10000m && value >= 0.00m)
                    amount = value;
                else
                    throw new Exception("Invalid Amount | Maximum allowed spending is $10000");
            }
        }
        public string PaymentMethod//accessor methods (property)
        {
            get
            {
                return paymentMethod;
            }
            set
            {
                string n = value.Trim();
                if (n.Length != 0)
                    paymentMethod = value;
                else
                    throw new Exception("Select a Payment Method");

            }
        }

        public string Trip //accessor methods (property)
        {
            get
            {
                return trip;
            }
            set
            {

                trip = value.Trim();
                if (trip.Length == 0)
                    trip = "** unspecified **";
            }
        }

        public string Note //accessor methods (property)
        {
            get
            {
                return note;
            }
            set
            {
                note = value.Trim();
            }
        }
        public override string ToString()
        {
            string s =  date.ToShortDateString();
            s = s + ", " + trip + ", " + Description;
            s = s + ", " + Amount.ToString("C");//format the amount as currency
            s = s + ", " + PaymentMethod;
            if (Note.Length > 0)
                s = s + ", " + Note;
            return s;
        }

        public ExpenseItem(ExpenseItem exp) //Copy constructor 
        {
            description = exp.description;
            amount = exp.amount;
            paymentMethod = exp.paymentMethod;
            trip = exp.trip;
            note = exp.note;
            date = exp.date;
        }
        public bool Equals(ExpenseItem exp) // Equals method 
        {
            if (description == exp.description && date.Equals(exp.date) && amount == exp.amount && paymentMethod == exp.paymentMethod && trip == exp.trip && note == exp.note)
                return true;

            else
                return false;
        }
    }
}
