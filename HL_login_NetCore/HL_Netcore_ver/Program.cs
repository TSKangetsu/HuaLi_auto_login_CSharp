using System;
using Newtonsoft;
using System.IO;
using HL_Netcore_ver.StartSettting;
using HL_Netcore_ver.HL_NetInfo_Send;
using System.Net.NetworkInformation;

namespace HL_Netcore_ver
{
    class Program
    {
        static void Main(string[] args)
        {
            StartCheck start = new StartCheck();
            switch (args[0])
            {
                case "add_config":
                    start.Addconfig(args);
                    break;
                case "connect":
                    Console.WriteLine(start.Connect(args));
                    break;
                case "connect_with_config":
                    Console.WriteLine(start.Connect_with_config());
                    break;
                case "disconect":

                    break;
                case "help":

                    break;
                default:
                    Console.WriteLine("nothing happend ,please add 'help' for help");
                    break;
            }
        }

        void jsoncon()
        {
            string path1 = Directory.GetCurrentDirectory() + "/HUALI_login_info.json";
            if (File.Exists(path1) == false)
            {

            }
        }
    }
}