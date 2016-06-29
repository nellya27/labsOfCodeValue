using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp
{
    public class Customer:IComparable<Customer>,IEquatable<Customer>
    {
        private string m_Name;
        private string m_Adress;
        private int m_Id;

        public Customer(string i_Name,string i_Adress,int i_Id)
        {
            m_Name = i_Name;
            m_Adress = i_Adress;
            m_Id = i_Id;
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public string Adress
        {
            get { return m_Adress; }
            set { m_Adress = value; }
        }

        public int ID
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        int IComparable<Customer>.CompareTo(Customer other)
        {

            return string.Compare(this.Name, other.Name, true);
        }

        public bool Equals(Customer other)
        {
            
            if(other==null)
            {
                return  false;
            } 
            else
            {
               return  this.ID == other.ID && string.Equals(this.Name, other.Name); 
            }

        }

        public override bool Equals(object obj)
        {
            if (obj is Customer)
            {
                return this.Equals((Customer)obj);
            }
            else
                return false;
          
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.ID.GetHashCode(); 
        }

    }
}
