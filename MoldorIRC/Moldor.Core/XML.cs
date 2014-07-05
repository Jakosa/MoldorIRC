using System;
using System.Xml;

namespace Moldor
{
    class XmlManager
    {
        public static string test = "";

        public static void Help()
        {
            //string NickName;
            //public static string Port;
            //public static string NickPass;

            // Loading XML and XML File
            var xmlRead = new XmlDocument();
            xmlRead.Load(@"C:\\books.xml");

            // Getting data from file
            string hello = xmlRead.SelectSingleNode("Moldor/IRC/server").InnerText;
            // NickName = xmlRead.SelectSingleNode("Moldor/IRC/nick").InnerText;
            //  Port = xmlRead.SelectSingleNode("Moldor/IRC/port").InnerText;
            // NickPass = xmlRead.SelectSingleNode("Moldor/IRC/nickpass").InnerText;

            test = hello;
            Console.WriteLine("LOL LOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLLOLv");

            if (Console.ReadLine() == "hee")
            {
                Console.WriteLine(hello);
            }
        }
    }
}
