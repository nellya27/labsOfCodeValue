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
            
            CustomerFilter filterByAK = new CustomerFilter(IsCustomerStartWithAToK);
            CustomerFilter filterByLZ = new CustomerFilter(IsCustomerStartWithLToZ);

            List<Customer> anotherCustomerList = new List<Customer>();
            anotherCustomerList.Add(new Customer("Nelly", "Holon", 311));
            anotherCustomerList.Add(new Customer("Kevin", "TelAviv", 11));
            anotherCustomerList.Add(new Customer("Itay", "Heifa", 89));
            anotherCustomerList.Add(new Customer("Ziva", "BatYam", 111));
            anotherCustomerList.Add(new Customer("Ketty", "Holon", 222));

            List<Customer> list1 = GetCustomers(anotherCustomerList, filterByAK);
            Console.WriteLine("The Names that starts with A-K");
            foreach (Customer customer in list1)
            {
                Console.WriteLine("{0}", customer.Name);
            }
            List<Customer> list2 = GetCustomers(anotherCustomerList, filterByLZ);
            Console.WriteLine("The Names That starts With L-Z");
            foreach (Customer customer in list2)
            {
                Console.WriteLine("{0}", customer.Name);
            }
            List<Customer> list3 = new List<Customer>();
            CustomerFilter lambdaFilter =s => s.ID < 100;
            list3=GetCustomers(anotherCustomerList, lambdaFilter);
            Console.WriteLine("The list of customers that thier Id is smaller than 100");
            foreach (Customer customer in list3)
            {
                Console.WriteLine("{0}", customer.Name);
            }

            Customer[] customerList = new Customer[4];
            customerList[0] = new Customer("NELLY", "Holon", 311);
            customerList[1] = new Customer("nelly", "Holon", 450);
            customerList[2] = new Customer("Elad", "Givaataim", 300);
            customerList[3] = new Customer("Tami", "Raanana", 324);
            Array.Sort(customerList);
            Console.WriteLine("Sorted List");
            foreach (Customer currentCustomer in customerList)
            {
                Console.WriteLine("{0},{1}", currentCustomer.Name,currentCustomer.ID);
            }
            IComparer<Customer> newComparer = new AnotherCustomerComparer();
            Array.Sort(customerList, newComparer);
            Console.WriteLine("the list of customers sorted by id");
            foreach(Customer currentCustomer in customerList)
            {
                Console.WriteLine("{0},{1}", currentCustomer.Name, currentCustomer.ID);
            }
            

        }

        public static List<Customer> GetCustomers( List<Customer> listOfCustomer,CustomerFilter customerFilter)
        {
            List<Customer> customerListAfterFiltering = new List<Customer>(); 
            foreach(Customer customer in listOfCustomer)
            {
                if (customerFilter.Invoke(customer))
                {
                    customerListAfterFiltering.Add(customer);
                }
            }

            return customerListAfterFiltering;
        }

        public static bool IsCustomerStartWithAToK(Customer newCustomer)
        {

            char firstCharInName =char.Parse(newCustomer.Name.Substring(0,1));
            if (firstCharInName >= 'A' && firstCharInName <= 'K')
            {
                return true;
            }
            else
                return false;

        }
        public static bool IsCustomerStartWithLToZ(Customer newCustomer)
        {
            char firstCharInName = char.Parse(newCustomer.Name.Substring(0, 1));
            if (firstCharInName >= 'L' && firstCharInName <= 'Z')
            {
                return true;
            }
            else
                return false;
        }
    
    }
}
