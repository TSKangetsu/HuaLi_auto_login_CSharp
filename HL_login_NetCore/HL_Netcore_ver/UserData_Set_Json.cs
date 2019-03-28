using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace HL_Netcore_ver.UserData_Set_Json
{
    class JsonData
    {
        public string IPAdress { set; get; }
        public DateTime LastConnectTime { set; get; }
        public string Connected { set; get; }
        public Dictionary<string, string> UserInfo { get; set; }
    }
    class JsonFuncFirst
    {
        public string jsondata_on { get; set; }
        JsonData jsondata { get; set; }
        public JsonFuncFirst(string User, string Password, string EndPointIP)
        {
            jsondata = new JsonData
            {
                IPAdress = EndPointIP,
                LastConnectTime = DateTime.Now,
                UserInfo = new Dictionary<string, string>
                {
                    {"User" , User},
                    {"Password" , Password }
                }
            };
            jsondata_on = JsonConvert.SerializeObject(jsondata, Formatting.Indented);
            string path = Directory.GetCurrentDirectory();
            FileStream txtfile = new FileStream(path + "/HUALI_login_info.json", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter txtwrite = new StreamWriter(txtfile);
            txtwrite.Write(jsondata_on);
            txtwrite.Close();
        }

        public string[] JsonFuncRead_userinfo()
        {
            string path = Directory.GetCurrentDirectory();
            FileStream txtfile = new FileStream(path + "/HUALI_login_info.json", FileMode.Open, FileAccess.Read);
            StreamReader txtread = new StreamReader(txtfile);
            string JsonGet = txtread.ReadToEnd().ToString();
            txtfile.Close();
            JsonData jsonData = JsonConvert.DeserializeObject<JsonData>(JsonGet);
            string[] Userinfo = new string[2];
            Userinfo[0] = jsonData.UserInfo["User"];
            Userinfo[1] = jsonData.UserInfo["Password"];
            return Userinfo;
        }
    }
}