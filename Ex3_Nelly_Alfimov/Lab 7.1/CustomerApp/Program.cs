using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp
{
    public class Program
    {
        public static void Main()
        {
            Customer[] customerList = new Customer[4];
            customerList[0] = new Customer("NELLY","Holon",311);
            customerList[1] = new Customer("nelly", "Holon", 450);
            customerList[2] = new Customer("Elad", "Givaataim", 300);
            customerList[3] = new Customer("Tami", "Raanana", 324);
            Array.Sort(customerList);
            foreach(Customer currentCustomer in customerList)
            {
                Console.WriteLine("{0},{1}", currentCustomer.Name,currentCustomer.ID);
            }
            IComparer<Customer> newComparer = new AnotherCustomerComparer();
            Array.Sort(customerList, newComparer);
            foreach(Customer currentCustomer in customerList)
            {
                Console.WriteLine("{0},{1}", currentCustomer.Name, currentCustomer.ID);
            }

        }
    
    }
}
