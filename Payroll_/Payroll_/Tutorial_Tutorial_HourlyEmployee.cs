using System;

namespace Payroll
{[Serializable] 
	/// <summary>
	/// Summary description for HourlyEmployee.
	/// </summary>
	public class HourlyEmployee : Employee
	{
		private decimal payRate;
		decimal currentHoursWorked;

		public HourlyEmployee()
		{
            // This is the default constructor
        }

        public HourlyEmployee(HourlyEmployee emp): base((Employee)emp)
        {
            PayRate = emp.PayRate;
        } 

		public HourlyEmployee (string lName, string fName, char MI, string ss,  DateTime hired, decimal pay)
            : base (lName, fName, MI, ss, hired) 
		{  
			PayRate = pay; 
			CurrentHoursWorked = 0;
		} 
  
		public decimal CurrentHoursWorked
        {
            get { return currentHoursWorked; }

            set
            {
                if (value >= 0m && value <= 60m)
                    currentHoursWorked = value;
                else
                    throw new Exception("Invalid hours worked");
            }
        }
        public override decimal Earnings  ()  
		{ 
			return
				(	
				// regular pay
				(Math.Min(CurrentHoursWorked,40) * PayRate) +
				// overtime pay
				(Math.Max(CurrentHoursWorked-40,0) * (1.5m * PayRate))
				);
		} 

		public decimal PayRate
        {
            get { return payRate; }
            set
            {
                if (value >= 7.25m && value <= 25.00m)
                    payRate = value;
                else
                    throw new Exception("Invalid pay rate");
            }
        }
        public override string ToString() 
		{  
			return base.ToString() + " Pay Rate: " + PayRate.ToString("C") + " Current Hours: " + CurrentHoursWorked.ToString() ; 
		} 
	}
}
