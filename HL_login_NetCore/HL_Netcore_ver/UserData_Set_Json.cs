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
        public string Connected {set;get;}
        public Dictionary<string, string> UserInfo { get; set; }
    }

    // class JsonFunc
    // {
    //     public string jsondata_on { get; set; }
    //     JsonData jsondata { get; set; }
    //     public JsonFunc(string ConnectFvs)
    //     {

    //         jsondata = new JsonData
    //         {
    //             LastConnectTime = DateTime.Now,
    //             Connected = ConnectFvs
    //         };
    //     }
        // public JsonFunc(string User, string Password, string EndPointIP)
        // {
        //     jsondata = new JsonData
        //     {
        //         IPAdress = EndPointIP,
        //         LastConnectTime = DateTime.Now,
        //         UserInfo = new Dictionary<string, string>
        //         {
        //             {"User" , User},
        //             {"Password" , Password }
        //         }
        //     };
        //     jsondata_on = JsonConvert.SerializeObject(jsondata, Formatting.Indented);
        // }
    // }

    // class JsonFileSet
    // {
    //     public JsonFileSet(string User, string Password, string EndPoint = "0.0.0.0", string Connection = "false")
    //     {
    //         string path = Directory.GetCurrentDirectory();
    //         /*----------------------------------*/
    //         FileStream txtfile = new FileStream(path + "/HUALI_login_info.json", FileMode.OpenOrCreate, FileAccess.ReadWrite);
    //         StreamWriter txtwrite = new StreamWriter(txtfile);
    //         if (true)
    //         {
    //             JsonFunc jsonset = new JsonFunc(User, Password, EndPoint);
    //             txtwrite.Write(jsonset.jsondata_on);
    //             txtwrite.Close();
    //         }
    //         /*---------------------------------*/
    //     }
    // }
}