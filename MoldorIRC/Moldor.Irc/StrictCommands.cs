using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Moldor
{
    class StrictCommands
    {
        // Here was stored the structural commands
        public static void StrictCmDs(string argument)
        {
            /*if (MessageHander.getMessage.StartsWith(IrcBot.cmdPrefix + "roll"))
            {
                int roll = 0;
                System.Random rnd = new System.Random();
                roll = rnd.Next(1, 100);
                IrcBot.SendMessage.WriteLine("PRIVMSG " + MessageHander.getChannel + " :Esélyeid: {0}% \u000301Back to black", roll);
                Thread.Sleep(1);
            }

            if (MessageHander.getMessage.StartsWith(IrcBot.cmdPrefix + "info"))
            {

                double memory = Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024;
                double precent = memory * 100 / 512;
                string precentAsStr = precent.ToString("0.00");
                char[] precentAsArray = precentAsStr.ToCharArray();


                IrcBot.SendMessage.WriteLine("PRIVMSG " + MessageHander.getChannel + " :" + IrcConstants.Bold + "Programmed by: " + IrcConstants.DarkGreen + "Shartigan");
                IrcBot.SendMessage.WriteLine("PRIVMSG " + MessageHander.getChannel + " :" + IrcConstants.Bold + "Project name: " + IrcConstants.DarkGreen + "Moldor");
                IrcBot.SendMessage.WriteLine("PRIVMSG " + MessageHander.getChannel + " :" + IrcConstants.Bold + "Memory status: {0} mb, ({1}%)" + IrcConstants.DarkGreen, memory, precentAsStr);
                Thread.Sleep(1);
            }

            if (MessageHander.getMessage.StartsWith(IrcBot.cmdPrefix + "gc") && (MessageHander.getSender.StartsWith("Shartigan")))
            {
                var _memory = Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024;

                // Put some objects in memory.
                Console.WriteLine("Memory used before collection: {0}", _memory);

                // Collect all generations of memory.
                GC.Collect();
                var memory = Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024;
                Console.WriteLine("Memory used after full collection: {0}", memory);

                Thread.Sleep(1);

            }

            if (MessageHander.getMessage.StartsWith(IrcBot.cmdPrefix + "test"))
            {
                Console.WriteLine(XmlManager.test);
                Thread.Sleep(1);
            }*/
        }
    }
}
