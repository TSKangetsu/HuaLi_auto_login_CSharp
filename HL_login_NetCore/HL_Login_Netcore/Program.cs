using System;
using Newtonsoft;
using System.IO;
using HL_Netcore_ver.StartSettting;
using HL_Netcore_ver.HL_NetInfo_Send;
using HL_Netcore_ver.UserData_Set_Json;
using System.Net.NetworkInformation;

namespace HL_Netcore_ver
{
    class Program
    {
        static void Main(string[] args)
        {
            StartCheck start = new StartCheck();
            try
            {
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
                    case "disconnect":
                        Console.WriteLine(start.disconnector());
                        break;
                    case "manual_connect":
                        Console.WriteLine(start.Manual_connect(args));
                        break;
                    case "help":
                        Console.WriteLine(start.ask_for_help());
                        break;
                    default:
                        Console.WriteLine("nothing happend ,please add 'help' for help");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("nothing happend ,please add 'help' for help");
            }
        }
    }
}