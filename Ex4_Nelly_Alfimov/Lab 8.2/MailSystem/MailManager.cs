using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
   
    public class MailManager
    {
        public event EventHandler<MailArrivedEventArgs> MailArrived;

        protected virtual void OnMailArrived(MailArrivedEventArgs mail)
        {
            if(MailArrived!=null)
            {
                MailArrived(this, mail);
            }
        }

       public void SimulateMailArrived(object obj)
       {            
           obj = new MailArrivedEventArgs("dummy title", "dummy body");
           OnMailArrived(obj as MailArrivedEventArgs);                                   
       }
    
       public void MailSent(MailArrivedEventArgs mail)
        {            
           OnMailArrived(mail);                    
        }


    }
}
