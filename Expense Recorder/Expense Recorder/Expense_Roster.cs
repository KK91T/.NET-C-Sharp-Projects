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

    public class ExpenseItemRoster : List<ExpenseItem>
    {


        new public void Add(ExpenseItem e)
        {
            ExpenseItem match = this.Find(e);
            if (match == null)
            {
                base.Add(e);
                return;
            }
            else
                throw new Exception("Duplicate ExpenseItem");
            }

        public void Delete(ExpenseItem e)
        {
            ExpenseItem emp = Find(e);
            if (emp == null) return;
            this.Remove(emp);
        }

        public ExpenseItem Find(ExpenseItem e)
        {

            var selecteditems =
               from e1 in this
               where e1.Equals(e)
               select e1;

            foreach (var e1 in selecteditems) return e1;

            return null;
        }

        public static ExpenseItemRoster ReadFromFile(string filename)
        {
            ExpenseItemRoster deserializedexpenses = null;
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                deserializedexpenses = (ExpenseItemRoster)formatter.Deserialize(stream);
                stream.Close();

            }
            catch (Exception)
            { return null; }
            return deserializedexpenses;
        }

        public void WriteToFile(string filename)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, this);
                stream.Close();
            }
            catch (Exception)
            { }
        }


        public  decimal TotalAmount()
        {
            Decimal TtlAmt = 0;            
                foreach (var e in this)
            {

                TtlAmt += e.Amount;
                  }
            return TtlAmt;

        }       

    }
}



