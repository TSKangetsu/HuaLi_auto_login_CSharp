using System;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Net.Sockets;
using System.IO;
using HL_Netcore_ver.UserData_Set_Json;
using Newtonsoft.Json;

namespace HL_Netcore_ver.HL_NetInfo_Send
{
    interface IIPGet
    {
        string IPGet();
    }
    class Netvim : JsonData, IIPGet
    {
        string ip { get; set; }
        public string IPGet()
        {
            Socket netpro = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            netpro.Connect(IPAddress.Parse("219.136.125.139"), 80);
            ip = ((IPEndPoint)netpro.LocalEndPoint).Address.ToString();
            return ip;
        }
        private bool Net_send(string postString)
        {
            string url = "http://219.136.125.139/portalAuthAction.do";
            string neturl = "www.baidu.com";
            var postData = Encoding.UTF8.GetBytes(postString);
            WebClient data_post = new WebClient();//webclient模拟表单提交
            data_post.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            try
            {
                data_post.UploadData(url, "POST", postData);
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(neturl);
                if (pingReply.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (PingException e)
            {
                JsonData connectset = new JsonData { Connected = e.ToString() };
                return false;
            }
        }
        public string[] filebeens()
        {
            string path = Directory.GetCurrentDirectory();
            FileStream txtfile = new FileStream(path + "/HUALI_login_info.json", FileMode.Open, FileAccess.Read);
            StreamReader txtread = new StreamReader(txtfile);
            string JsonGet = txtread.ReadToEnd().ToString();
            txtfile.Close();
            JsonData jsonData = JsonConvert.DeserializeObject<JsonData>(JsonGet);
            string[] userinfo = new string[2];
            userinfo[0] = jsonData.UserInfo["User"];
            userinfo[1] = jsonData.UserInfo["Password"];
            return userinfo;
        }
        public bool Netlogin(string user, string password, string ip)
        {
            List<string> poststring1 = new List<string>
            {
                "wlanuserip="+ip,
                "&wlanacname=gzhlxy",
                "&chal_id=",
                "&chal_vector=",
                "&auth_type=PAP",
                "&seq_id=",
                "&req_id=",
                "&wlanacIp=183.56.17.19",
                "&ssid=",
                "&vlan=",
                "&mac=",
                "&message=",
                "&bank_acct=",
                "&isCookies=",
                "&version=0",
                "&authkey=gzhlxy",
                "&url=",
                "&usertime=0",
                "&listpasscode=0",
                "&listgetpass=0",
                "&getpasstype=0",
                "&randstr=",
                "&domain=GDHLXY",
                "&isRadiusProxy=false",
                "&usertype=0",
                "&isHaveNotice=0",
                "&times=12",
                "&weizhi=0",
                "&smsid=0",
                "&freeuser=",
                "&freepasswd=",
                "&listwxauth=0",
                "&templatetype=1",
                "&tname=5",
                "&logintype=0",
                "&act=",
                "&is189=true",
                "&terminalType=",
                "&useridtemp="+user,
                "&userid="+user+"%40GDHLXY",
                "&passwd="+password,
            };
            string postString = string.Empty;
            foreach (string adpat in poststring1)
            {
                postString = postString + adpat;
            };
            return Net_send(postString);
        }
        public bool Netoffline(string user, string ip)
        {
            List<string> poststring = new List<string>
            {
                "userid="+user+"%40GDHLXY",
                "&wlanuserip="+ip,
                "&wlanacname=gzhlxy",
                "&chal_id=",
                "&chal_vector=",
                "&auth_type=PAP",
                "&seq_id=",
                "&req_id=",
                "&wlanacIp=183.56.17.19",
                "&ssid=",
                "&vlan=",
                "&mac=",
                "&message=",
                "%C4%FA%B5%C4%BF%C9%D3%C3%CC%EC%CA%FD%CE%AA%28%CC%EC%29%3A23.0",
                "&bank_acct=",
                "&isCookies=",
                "&version=0",
                "&authkey=gzhlxy",
                "&url=http%3A%2F%2Fabout%3Ablank",
                "&usertime=570192564",
                "&listpasscode=0",
                "&listgetpass=0",
                "&getpasstype=0",
                "&randstr=",
                "&domain=GDHLXY",
                "&isRadiusProxy=false",
                "&usertype=0",
                "&isHaveNotice=0",
                "&times=12",
                "&weizhi=0",
                "&smsid=0",
                "&freeuser=",
                "&freepasswd=",
                "&listwxauth=0",
                "&templatetype=1",
                "&tname=5",
                "&logintype=0",
                "&act=DISCONN",
                "&is189=true",
                "&terminalType ="
            };
            string postString = string.Empty;
            foreach (string adpat in poststring)
            {
                postString = postString + adpat;
            };
            return Net_send(postString);
        }
    }
}