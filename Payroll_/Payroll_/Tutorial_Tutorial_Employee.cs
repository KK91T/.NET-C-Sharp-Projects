using System; 
using System.Threading;


namespace Payroll 
{ 
    [Serializable]
	public abstract class Employee: Object 
	{ 
		private string firstName; 
		private char middleInitial; 
		private string lastName; 
		private string ssn; 
        private DateTime dateHired;

		public Employee() 
		{ 
			// This is the default constructor
		} 

        public Employee(Employee emp)
        {
            firstName = emp.firstName;
            lastName = emp.lastName;
            middleInitial = emp.middleInitial;
            ssn = emp.ssn;
            dateHired = emp.dateHired;
        }
  
		public Employee (string lName, string fName, char mi, string ss, DateTime hired) 
		{
			FirstName = fName;
			LastName = lName;
			MiddleInitial = mi; 
			SSN	= ss; 
            DateHired = hired;
		}

        public DateTime DateHired
        {
            get
            {
                return dateHired;
            }
            set
            {
                dateHired = value;
            }
        } 
  
		public override string ToString () 
		{
			string s = ssn + " " + lastName + ", " + firstName + " " + middleInitial + ". ";
            s = s.Replace(" .", "");
            s = s + " Hired: " + dateHired.ToShortDateString();
			return s; 
		} 
 
		public string FirstName 
		{ 
			get 
			{
                return firstName;
            } 
			set 
			{
				string n = value.Trim();
                if (n.Length == 0)
                    firstName = "Unknown";
                else
                    firstName = value;
			} 
		} 
  
		public string LastName 
		{ 
			get 
			{
                return lastName;
            } 
			set 
			{
                string n = value.Trim();
                if (n.Length == 0)
                    lastName = "Unknown";
                else
                    lastName = value;
			} 
		} 
  
		public char MiddleInitial 
		{ 
			get 
			{
                return middleInitial;
            } 
			set 
			{
				middleInitial = value;
			} 
		} 

		public string SSN
		{
			get
			{
                return ssn;
            }
			set
			{
				if (value.Length != 9) 
                    ssn = "999999999";
				else
				    ssn = value;
			}
		}
  
		// Property PayRate is removed

        public bool Equals(Employee emp)
        {
            if (firstName == emp.firstName && middleInitial == emp.middleInitial && lastName == emp.lastName &&
                ssn == emp.ssn && dateHired.Equals(emp.dateHired))
                return true;
            else
                return false;
        }

        public abstract decimal Earnings();
  		
	} 
} 