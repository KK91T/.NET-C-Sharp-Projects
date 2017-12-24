

using System;

namespace Payroll
{
    [Serializable]

    /// <summary>
    /// Summary description for SalesEmployee.
    /// </summary>

    public class SalesEmployee : HourlyEmployee
    {

        // Attribute declaration
        private decimal currentSales;
        private decimal commission;

        // Default construtor 
        public SalesEmployee()
        {
            // This is the default constructor
        }

        // Copy construtor 
        public SalesEmployee(SalesEmployee emp) : base((HourlyEmployee)emp)
        {
            Commission = emp.commission;
        }



        public SalesEmployee(string lName, string fName, char MI, string ss, DateTime hired, decimal pay, decimal cOmission)
            : base(lName, fName, MI, ss, hired, pay)
        {
            CurrentSales = 0;
            Commission = cOmission;
        }

        // Method for commission
        public decimal Commission
        {
            get { return commission; }
            set
            {
                if (value >= 0m && value <= 0.1m)
                    commission = value;
                else
                    throw new Exception("Invalid Commission");
            }            
        }

        public decimal CurrentSales
        {
            get { return currentSales; }
            set {
                if (value >= 0m && value <= 10000m)
                    currentSales = value;
                else
                    throw new Exception("Invalid Current Sales");
            }
        }


        public override string ToString()
        {
            return base.ToString() + " Commission: " + Commission.ToString() + " Currentsales: " + currentSales.ToString("C");
        }


        public override decimal Earnings()
        {

            return base.Earnings() + (CurrentSales * commission);
        }
    }
}
