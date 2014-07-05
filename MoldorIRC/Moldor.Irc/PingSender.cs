using System;
using System.Threading;

namespace Moldor
{
    public class PingSender
    {
        static string PING = "PING :";

        // Empty constructor makes instance of Thread
        public PingSender()
        {
            var pingSender = new Thread(new ThreadStart(Run));
            pingSender.Start();
            pingSender.Name = "PingSender";

            Console.WriteLine("Name: {0}", pingSender.Name);
        }

        // Send PING to irc server every 30 seconds
        private void Run()
        {
            while (true)
            {
                Moldor.SendMessage.WriteLine(PING + Moldor.SERVER);
                Thread.Sleep(30*1000);
            }
        }
    }
}