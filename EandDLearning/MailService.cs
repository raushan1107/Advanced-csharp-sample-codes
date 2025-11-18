using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EandDLearning
{
    public class MailService
    {
        public void onVideoEncoded(object source, EventArgs args)
        {
            Console.WriteLine("Sending mail.....");
            Thread.Sleep(2000);
            Console.WriteLine("MailService Notification: Mail sent sucessfully!");
        }
    }
}
