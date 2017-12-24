using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace Payroll
{    
    [Serializable]
    class Roster : List<Employee>
    {
       
         public Employee Find (string ssn)
        {
            var specificEmployee =
               from e in this
               where e.SSN == ssn
               select e;
            foreach (var e in specificEmployee) return e;
            return null;
        }

        new public void Add(Employee e)
        {
            Employee match = this.Find(e.SSN);
            if (match == null)
            {
                base.Add(e);
                return;
            }
            else
                throw new Exception("Duplicate Employee");
        }

        public void Delete(string ssn)
        {
            Employee emp = Find(ssn);
            if (emp == null) return;
            this.Remove(emp);
        }

        public static Roster ReadFromFile(string filename)
        {
            Roster r;

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                r = (Roster)formatter.Deserialize(stream);
                stream.Close();
            }
            catch (Exception)
            { return null; }
            return r;
        }


        public void  WriteToFile(string filename)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, this);
                stream.Close();
            }
            catch (Exception)
            {  }
        }

        public Employee Find(string lastName, string firstName, char mi)
        {
            var specificEmployee =
             from e in this
             where e.LastName == lastName && e.FirstName == firstName && e.MiddleInitial == mi
             select e;
            if (specificEmployee.Count() == 1)
                return specificEmployee.First();
            return null;
        }


    }
}
