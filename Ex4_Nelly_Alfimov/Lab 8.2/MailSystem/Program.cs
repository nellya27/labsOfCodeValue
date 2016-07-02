using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSystem
{
    static class Program
    {
        public static void Main(string[] args)
        {
            MailManager manager = new MailManager();
            MailArrivedEventArgs mail = new MailArrivedEventArgs("Nelly", "you got a new messege");
            MailArrivedEventArgs anotherMail = new MailArrivedEventArgs("Dror", "Mail");
            manager.MailArrived+= GotMail;
            manager.SimulateMailArrived(new object());
            manager.MailSent(mail);
            manager.MailSent(anotherMail);

            TimerCallback timeCall =manager.SimulateMailArrived;
            System.Threading.Timer timer = new System.Threading.Timer(timeCall, null, 0,1000);
            System.Threading.Thread.Sleep(10000);

        }

        public static void GotMail(object sender, MailArrivedEventArgs e)
        {
            Console.WriteLine(e.Title);
            Console.WriteLine(e.Body);
            System.Threading.Thread.Sleep(3000);

        }
    }
}
