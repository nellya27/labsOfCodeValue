using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountLib
{
    public class InsufficientFundsException:Exception
    {
        public InsufficientFundsException(string i_Messege):base(i_Messege)
        {

        }
            
    }
}
