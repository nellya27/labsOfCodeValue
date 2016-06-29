using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp
{
    public class AnotherCustomerComparer : IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {
            int compare = 0;
            if(x.ID==y.ID)
            {
                compare = 0;
            }
            if(x.ID>y.ID)
            {
                compare = 1;
            }
            if(x.ID<y.ID)
            {
                compare = -1;
            }
            return compare;
        }
    }
}
