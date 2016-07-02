using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    public class MailArrivedEventArgs
    {
        private string title;
        private string body;

        public MailArrivedEventArgs(string newTitle,string newBody)
        {
            title = newTitle;
            body = newBody;
        }
        public string Title
        {
            get { return title; }
        }

        public string Body
        {
            get { return body; }
        }

    }
}
