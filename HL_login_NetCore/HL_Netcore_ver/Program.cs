using System;
using Newtonsoft;
using HL_Netcore_ver.StartSettting;
using HL_Netcore_ver.HL_NetInfo_Send;

namespace HL_Netcore_ver
{
    class Program
    {
        static void Main(string[] args)
        {
            StartCheck ins = new StartCheck(args);
        }
    }
}