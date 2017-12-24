using System;

namespace Payroll
{
    [Serializable] 
	public class Manager : Employee
	{
		private int monthlySalary;

		public Manager()
		{
			// TODO: Add constructor logic here
		}

		public Manager (string lName, string fName, char MI, string ss, DateTime hired, int salary)
            : base(lName, fName, MI, ss, hired)
		{
            MonthlySalary = salary; 
        }

		public Manager (Manager mgr) : base (mgr)
		{
            MonthlySalary = mgr.MonthlySalary; 
        }

		public int MonthlySalary
		{
			get{return monthlySalary;}
			set{monthlySalary = value;}
		}

		public override decimal Earnings()
		{
			return MonthlySalary;
		}

		public override string ToString()
		{    
            return base.ToString() + " Salary: " + MonthlySalary.ToString("C");
        }
	}
}

