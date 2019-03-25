using System;
using System.IO;
using HL_Netcore_ver.UserData_Set_Json;
using HL_Netcore_ver.HL_NetInfo_Send;
using Newtonsoft.Json;

namespace HL_Netcore_ver.StartSettting
{
    class StartCheck : JsonData
    {
        public StartCheck(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            if (File.Exists(path + "/HUALI_login_info.json"))
            {
                FileStream txtfile = new FileStream(path + "/HUALI_login_info.json", FileMode.Open, FileAccess.Read);
                StreamReader txtread = new StreamReader(txtfile);
                string JsonGet = txtread.ReadToEnd().ToString();
                txtfile.Close();
                JsonData jsonData = JsonConvert.DeserializeObject<JsonData>(JsonGet);
                string usernames = jsonData.UserInfo["User"];
                string passwords = jsonData.UserInfo["Password"];
                Netvim NetSend = new Netvim(usernames,passwords);
            }else
            {
                IIPGet ins = new Netvim();
                JsonFuncFirst filesetfirst = new JsonFuncFirst(args[0] , args[1] , ins.IPGet());
            }
        }
    }
}