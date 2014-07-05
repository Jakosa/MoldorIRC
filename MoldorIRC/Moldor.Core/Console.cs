using System;
using System.Threading;

namespace Moldor
{
    public class ConsoleControl
    {
        public ConsoleControl()
        {
            var consoleController = new Thread(new ThreadStart(Run));
            consoleController.Start();
        }
        private void Run()
        {
            Console.Title = "Moldor Project";

            while (true)
            {
                if (Console.ReadLine().StartsWith("Hello"))
                {
                    Console.WriteLine("Hello");
                }

                Moldor.SendMessage.WriteLine("PRIVMSG " + Console.ReadLine() + " :lol");
            }
        }
    }
}