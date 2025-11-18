using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EandDLearning
{
    public class VideoEncoder
    {
        public delegate void videoEncoderEventHandler(object source, EventArgs args); // delegate defining.. use EventHandler as suffix after your delegate name.
        public event videoEncoderEventHandler VideoEncoded;

        public void EnCoder(Video video)
        {
            // Define delegate
            // define event for delegate
            // raise event

            Console.WriteLine("Enconding begin....");
            Thread.Sleep(4000);
            // Encoding logic

            //MailService();
            //TextService();
            onVideoEncoded();  // Raising the event..

        }
        protected virtual void onVideoEncoded()   // Raising event syntax: Protected, virtual, put prefix on before event name
        {
            if( VideoEncoded != null)
            {
                VideoEncoded(this, EventArgs.Empty); // invkoing delegate..
            }
        }
    }
}
