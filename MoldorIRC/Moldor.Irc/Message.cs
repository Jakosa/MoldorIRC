using System;
using System.Threading;
using System.Diagnostics;

namespace Moldor
{
    public class MessageHander
    {
		private int PLength = Moldor.cmdPrefix.Length;
		public static string Hostmask { get; private set; }
		public static string Channel { get; private set; }
		public static string Args { get; private set; }
		public static string Nick { get; private set; }
		public static string User { get; private set; }
		public static string Host { get; private set; }
		public static string[] Info { get; private set; }

		public MessageHander()
		{

		}

		public void Opcodes(string IrcMessage)
		{
			try
			{
				string opcode;
				string[] userdata;
				string[] hostdata;
				string[] IrcCommand;

				IrcCommand = IrcMessage.Split(' ');

				if(IrcCommand[0].Substring(0, 1) == ":")
					IrcCommand[0] = IrcCommand[0].Remove(0, 1);

				Hostmask = IrcCommand[0];
				userdata = Hostmask.Split('!');

				Args = String.Empty;
				if(IrcCommand.Length > 2)
					Channel = IrcCommand[2];

				Nick = userdata[0];
				if(userdata.Length > 1)
				{
					hostdata = userdata[1].Split('@');
					User = hostdata[0];
					Host = hostdata[1];
				}

				for(int i = 3; i < IrcCommand.Length; i++)
					Args += " " + IrcCommand[i];

				opcode = IrcCommand[1];
				Info = IrcCommand;

				if(Args != String.Empty && Args.Substring(0, 2) == " :")
					Args = Args.Remove(0, 2);

				switch(opcode)
				{
					case "PRIVMSG":
						HandlePrivmsg();
						break;
					case "PING":
						HandlePing();
						break;
					case "PONG":
						HandlePong();
						break;
					default:
						Console.WriteLine("Ismeretlen opcode: {0}", opcode);
						break;
				}
			}
			catch(Exception e)
			{
				Console.WriteLine("Opcodes: Hiba oka: {0}", e.ToString());
				Thread.Sleep(100);
			}
		}

		private void HandlePing()
		{
			Moldor.SendMessage.WriteLine("PING :{0}", Args);
		}

		private void HandlePong()
		{
			Moldor.SendMessage.WriteLine("PONG :{0}", Args);
		}

		private void HandlePrivmsg()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("[{0}] <{1}> {2}", Channel, Nick, Args);
			Console.ForegroundColor = ConsoleColor.Gray;

			if(Info[Info.Length-2] == String.Empty || Info[Info.Length-1] == String.Empty)
				return;

			if(Info[3].Substring(0, 1) == ":")
				Info[3] = Info[3].Remove(0, 1);

			if(Info[3] == String.Empty || Info[3].Substring(0, PLength) == " " || Info[3].Substring(0, PLength) != Moldor.cmdPrefix)
				return;

			Info[3] = Info[3].Remove(0, PLength);
			string cmd = Info[3].ToLower();

			if(cmd == "roll")
            {
                int roll = 0;
                System.Random rnd = new System.Random();
                roll = rnd.Next(1, 100);
                Moldor.SendMessage.WriteLine("PRIVMSG " + Channel + " :Esélyeid: {0}% \u000301Back to black", roll);
                Thread.Sleep(1);
            }

            if(cmd == "info")
            {
                double memory = Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024;
                double precent = memory * 100 / 512;
                string precentAsStr = precent.ToString("0.00");
                //char[] precentAsArray = precentAsStr.ToCharArray();


                Moldor.SendMessage.WriteLine("PRIVMSG " + Channel + " :" + IrcConstants.Bold + "Programmed by: " + IrcConstants.DarkGreen + "Shartigan");
                Moldor.SendMessage.WriteLine("PRIVMSG " + Channel + " :" + IrcConstants.Bold + "Project name: " + IrcConstants.DarkGreen + "Moldor");
                Moldor.SendMessage.WriteLine("PRIVMSG " + Channel + " :" + IrcConstants.Bold + "Memory status: {0} mb, ({1}%)" + IrcConstants.DarkGreen, memory, precentAsStr);
                Thread.Sleep(1);
            }

            if(cmd == "gc" && Nick == "Shartigan")
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

            if(cmd == "test")
            {
                Console.WriteLine(XmlManager.test);
                Thread.Sleep(1);
            }
		}
    }
}
