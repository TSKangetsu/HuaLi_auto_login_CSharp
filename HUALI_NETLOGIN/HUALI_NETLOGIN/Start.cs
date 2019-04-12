using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;

namespace Start_Menu
{
    class JsonData
    {
        public string IPAdress { set; get; }
        public DateTime LastConnectTime { set; get; }
        public bool Connected { set; get; }
        public Dictionary<string, string> UserInfo { get; set; }
    }

    class JsonFunc
    {
        public string jsondata_on { get; set; }
        JsonData jsondata { get; set; }
        public JsonFunc(string User, string Password, string EndPointIP, bool ConnectFuc)
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
        }
    }

    class JsonSet
    {
        public JsonSet(string User, string Password, string EndPoint = "0.0.0.0", bool Connection = false)
        {
            string path = Directory.GetCurrentDirectory();
            string path1 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/HUALI_login_info.json";
            /*----------------------------------*/
            FileStream txtfile = new FileStream(path1, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter txtwrite = new StreamWriter(txtfile);
            JsonFunc jsonset = new JsonFunc(User, Password, EndPoint, Connection);
            txtwrite.Write(jsonset.jsondata_on);
            txtwrite.Close();
            /*---------------------------------*/
        }
    }
}

