using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EandDLearning
{
    class Text
    {
        public void onVideoEncoded(object source, EventArgs args)
        {
            Console.WriteLine("Sending Text.....");
            Thread.Sleep(2000);
            Console.WriteLine("TextService Notification: Text sent sucessfully!");
        }
    }
}
