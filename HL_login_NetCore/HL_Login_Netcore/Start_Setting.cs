using HL_Netcore_ver.HL_NetInfo_Send;
using HL_Netcore_ver.UserData_Set_Json;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;

namespace HL_Netcore_ver.StartSettting
{

    class filebeen
    {

    }
    class StartCheck
    {
        public StartCheck()
        {
            string path1 = Directory.GetCurrentDirectory() + "/HUALI_login_info.json";
            if (File.Exists(path1) == false)
            {
                Console.WriteLine("try to connect remote server........");
                try
                {
                    IIPGet ip = new Netvim();
                    JsonSet jsonset = new JsonSet(null, null, ip.IPGet());
                    Console.WriteLine("data set success");
                }
                catch
                {
                    Console.WriteLine("connect remoteserver failed , write ip null");
                }

            }
            else
            {
                Console.WriteLine("json check ........ok");
            }
        }
        public void Addconfig(String[] args)
        {
            IIPGet IPGET = new Netvim();
            JsonSet writeconfig = new JsonSet(args[1], args[2], IPGET.IPGet());
            Console.WriteLine("config add success");
        }
        public string Connect(string[] args)
        {
            Netvim Net_start = new Netvim();
            string ip = Net_start.IPGet();
            if (Net_start.Netlogin(args[1], args[2], ip))
            {
                return "connect succesfully , connect message dosen't save";
            }
            else
            {
                return "connect fail , plz check you account or NetworkAdpater , or remote server is down";
            }
        }
        public string Connect_with_config()
        {
            try
            {
                IIPGet GetIP = new Netvim();
                Netvim NetSend = new Netvim();
                string[] userinfo = NetSend.filebeens();
                if (NetSend.Netlogin(userinfo[0], userinfo[1], GetIP.IPGet()))
                {
                    return "Connect succfully";
                }
                else
                {
                    return "Connect fail , please check your accountInfo and NetworkAdpter , or remote server is down";
                }
            }
            catch
            {
                return "No Config file set , plz try add config or get help";
            }
        }

        public string Manual_connect(string[] args)//args1 = user ; args2 = password ; args3 = ip address
        {
            try
            {
                Netvim NetSend = new Netvim();
                NetSend.Netlogin(args[1], args[2], args[3]);
                return "connected success";
            }
            catch
            {
                return "manual connect failed";
            }
        }
        public string disconnector()
        {
            try
            {
                Netvim Netoff = new Netvim();
                IIPGet offlineIP = new Netvim();
                string[] userinfo = Netoff.filebeens();
                if (!Netoff.Netoffline(userinfo[0], offlineIP.IPGet()))
                {
                    return "disconnect success";
                }
                else
                {
                    return "disconnect failed";
                }
            }
            catch
            {
                return "No Conf+ig file set , plz try add config or get help";
            }
        }

        public string ask_for_help()
        {
            string usage = "github : http://github.com/TSKangetsu \r\n" +
            "usage dotnet HL_Netcore_ver.dll add_config <username> <password> \r\n" +
            "dotnet HL_Netcore_ver.dll connect <username> <password> \r\n" +
            "dotnet HL_Netcore_ver.dll connect with config \r\n" +
            "dotnet HL_Netcore_ver.dll disconnect \r\n" +
            "dotnet HL_Netcore_ver.dll manual_connect <username> <password> <local IP address>";
            return usage;
        }
    }
}