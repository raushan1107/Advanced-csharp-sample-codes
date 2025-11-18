using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EandDLearning
{
    public class WhatsappService
    {
        public void onVideoEncoded(object source, EventArgs args)
        {
            Console.WriteLine("Sending whatsapp.....");
            Thread.Sleep(2000);
            Console.WriteLine("WhatsappService Notification: Whatsapp sent sucessfully!");
        }
    }
}
