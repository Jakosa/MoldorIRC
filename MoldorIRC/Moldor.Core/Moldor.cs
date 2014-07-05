using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Moldor
{
    class IrcBot
    {
        private static void Main(string[] args)
        {
            new Moldor();
        }
    }

	public class Moldor
    {
        public static string SERVER = "irc.rizon.net";
        private static int PORT = 6667;
        private static string USER = "USER Moldor 8 * :I'm Shartigan's C# BOT!";
        private static string NICK = "Moldor2";
        private static string CHANNEL = "#hun_bot";
        public static string cmdPrefix = "M#";
        public static string test = "";

        public static StreamWriter SendMessage { get; private set; }
		public static StreamReader Reader { get; private set; }
		private MessageHander MHander = new MessageHander();

        public Moldor()
        {
            try
            {
				string inputLine;
                var irc = new TcpClient();
                irc.Connect(SERVER, PORT);
                Reader = new StreamReader(irc.GetStream());
                SendMessage = new StreamWriter(irc.GetStream()) { AutoFlush = true };

                SendMessage.WriteLine(USER);
                SendMessage.WriteLine("NICK " + NICK);
                SendMessage.WriteLine("JOIN " + CHANNEL);

                //Thread Import to core
                new PingSender();
                new ConsoleControl();
                //new XmlManager();
				AddonManager.Initialize();
				AddonManager.LoadPluginsFromDirectory("Addons");

                while (true)
                {
                    while ((inputLine = Reader.ReadLine()) != null)
                    {
						MHander.Opcodes(inputLine);
                        //MessageHander.CleanMessage(inputLine);
                        //StrictCommands.StrictCmDs(inputLine);
                    }

                    SendMessage.Close();
                    Reader.Close();
                    irc.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                //Thread.Sleep(5000);
            }
		}
	}
}