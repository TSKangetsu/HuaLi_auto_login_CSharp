using System.Text;
using System.Net;
using System.Collections.Generic;
using System.Management;
using System.Text.RegularExpressions;
using System;

namespace PCI_IP_module
{
    /// <summary>
    /// 网络构造和发送
    /// </summary>
    class Net_work
    {
        public void Network(string user, string password)
        {
            IP_Test_module inst = new IP_Test_module();

            List<string> poststring1 = new List<string>
            {
                "wlanuserip="+inst.IPAddress ,
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
            string url = "http://219.136.125.139/portalAuthAction.do";
            var postData = Encoding.UTF8.GetBytes(postString);
            WebClient data_post = new WebClient();//webclient模拟表单提交
            data_post.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            data_post.UploadData(url, "POST", postData);
        }
    }
    /// <summary>
    /// 下线的数据包，先放着，现在没用上
    /// </summary>
    class Offline
    {
        List<string> poststring2 = new List<string>
        {
            "userid=19924613328%40GDHLXY" ,
            "&wlanuserip=",//ip
            "&wlanacname=gzhlxy" ,
            "&chal_id=" ,
            "&chal_vector=" ,
            "&auth_type=PAP" ,
            "&seq_id=" ,
            "&req_id=" ,
            "&wlanacIp=183.56.17.19" ,
            "&ssid=" ,
            "&vlan=" ,
            "&mac=" ,
            "&message=" ,
            "%C4%FA%B5%C4%BF%C9%D3%C3%CC%EC%CA%FD%CE%AA%28%CC%EC%29%3A23.0" ,
            "&bank_acct=" ,
            "&isCookies=" ,
            "&version=0" ,
            "&authkey=gzhlxy" ,
            "&url=http%3A%2F%2Fabout%3Ablank" ,
            "&usertime=570192564" ,
            "&listpasscode=0" ,
            "&listgetpass=0" ,
            "&getpasstype=0" ,
            "&randstr=" ,
            "&domain=GDHLXY" ,
            "&isRadiusProxy=false" ,
            "&usertype=0" ,
            "&isHaveNotice=0" ,
            "&times=12" ,
            "&weizhi=0" ,
            "&smsid=0" ,
            "&freeuser=" ,
            "&freepasswd=" ,
            "&listwxauth=0" ,
            "&templatetype=1" ,
            "&tname=5" ,
            "&logintype=0" ,
            "&act=DISCONN" ,
            "&is189=true" ,
            "&terminalType ="
        };
    }

    /// <summary>
    /// 真实有线网卡IP获得
    /// </summary>
    public class IP_Test_module
    {
        private const string IPv4RegularExpression = "^(?:(?:25[0-5]|2[0-4]\\d|((1\\d{2})|([1-9]?\\d)))\\.){3}(?:25[0-5]|2[0-4]\\d|((1\\d{2})|([1-9]?\\d)))$";
        //正则式
        private string Device { get; set; }//所有真实的网卡
        private string Target_Device { get; set; }//筛选出来的有线网卡
                                                  //Adapter的元素
        private string[] IPAddresses { get; set; }
        public string IPAddress { get; set; }
        //是否包含usb的值
        private string query_Devices { get; set; }
        /// <summary>
        /// 获得ip
        /// </summary>
        /// <param name="Include_USB">是否包含usb网卡，默认为没有</param>
        public IP_Test_module(bool Include_USB = false)
        {
            if (Include_USB == false)
            {
                query_Devices = "SELECT * FROM Win32_NetworkAdapter WHERE (PNPDeviceID LIKE 'PCI%') AND (NOT (Description LIKE '%Wireless%'))";
            }
            else
            {
                query_Devices = "SELECT * FROM Win32_NetworkAdapter WHERE (PNPDeviceID LIKE 'PCI%') AND (NOT (Description LIKE '%Wireless%')  AND (PNPDeviceID LIKE 'USB%') )";
            }

            ManagementObjectCollection True_NETWork_Adapter = new ManagementObjectSearcher(query_Devices).Get();
            foreach (ManagementObject True_Adapter in True_NETWork_Adapter)
            {
                Device = True_Adapter["Description"] as string;
            }
            //先从Win32_NetworkAdapter里面筛选符合条件的网卡并提取描述，并在下面与Win32_NetworkAdapterConfiguration类里查找相同描述的网卡并取得IP地址
            //这是 Win32_NetworkAdapter https://docs.microsoft.com/zh-cn/windows/desktop/CIMWin32Prov/win32-networkadapter 的元素
            //这是 Win32_NetworkAdapterConfiguration https://docs.microsoft.com/zh-cn/windows/desktop/CIMWin32Prov/win32-networkadapterconfiguration 的元素
            //windows网卡的管理真tm屑，煞 笔 系 统 
            ManagementObjectCollection Target_Adapter_info = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE Description=" + "'" + Device + "'").Get();
            foreach (ManagementObject Target_Adapter in Target_Adapter_info)
            {
                String[] IPCollection = Target_Adapter["IPAddress"] as String[]; // IP地址
                if (IPCollection != null)
                {
                    foreach (String adress in IPCollection)
                    {
                        Match match = Regex.Match(adress, IPv4RegularExpression);
                        if (match.Success)
                        {
                            IPAddress = adress;
                        }
                    }
                }
            }
        }
    }
}