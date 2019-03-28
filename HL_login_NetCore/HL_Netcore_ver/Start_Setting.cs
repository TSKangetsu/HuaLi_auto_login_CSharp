using HL_Netcore_ver.HL_NetInfo_Send;
using HL_Netcore_ver.UserData_Set_Json;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;

namespace HL_Netcore_ver.StartSettting
{
    class StartCheck
    {
        public void Addconfig(String[] args)
        {
            IIPGet IPGET = new Netvim();
            JsonFuncWrite writeconfig = new JsonFuncWrite(args[1] , args[2] , IPGET.IPGet());
            Console.WriteLine("config add success");
        }
        public string Connect(string[] args)
        {
            Netvim Net_start = new Netvim();
            string ip = Net_start.IPGet();
            if(Net_start.Netlogin(args[1], args[2], ip))
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
                string path = Directory.GetCurrentDirectory();
                FileStream txtfile = new FileStream(path+"/HUALI_login_info.json", FileMode.Open, FileAccess.Read);
                StreamReader txtread = new StreamReader(txtfile);
                string JsonGet = txtread.ReadToEnd().ToString();
                txtfile.Close();
                JsonData jsonData = JsonConvert.DeserializeObject<JsonData>(JsonGet);
                string usernames = jsonData.UserInfo["User"];
                string passwords = jsonData.UserInfo["Password"];
                IIPGet GetIP = new Netvim();
                Netvim NetSend = new Netvim();
                if (NetSend.Netlogin(usernames, passwords, GetIP.IPGet()))
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
        public string disconnector()
        {
            return "";
        }
    }
}