using System.IO;
using System.Text;
using System.Net;
using System.Collections.Generic;
using System;
using System.Management;
using System.Text.RegularExpressions;

/// <summary>
/// 程序主体
/// </summary>
namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Strat test2 = new Strat();
            string user = test2.User1;
            string password = test2.Password1;
            try
            {
                Net_work test = new Net_work();
                test.Network(user, password);
            }catch
            {
                Console.WriteLine("");
            }

        }

    }
}
/// <summary>
///判断是否写入过用户和密码
/// </summary>
class Strat
{
    public string User1;
    public string Password1;
    public Strat()
    {
        string path = System.IO.Directory.GetCurrentDirectory();
        String path1 = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/HUALI_login.txt";
        if (File.Exists(path1) == false)
        {
            Console.WriteLine("请输入用户名");
            User1 = Console.ReadLine();
            Console.WriteLine("请输入密码");
            Password1 = Console.ReadLine();
            /*----------------------------------*/
            FileStream txtfile = new FileStream(path1, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter txtwrite = new StreamWriter(txtfile);
            txtwrite.WriteLine(User1);
            txtwrite.WriteLine(Password1);
            txtwrite.Close();
        }
        else
        {
            StreamReader str2 = new StreamReader(path1);
            User1 = str2.ReadLine();
            Password1 = str2.ReadLine();    
        }
    }
}
/// <summary>
/// 网络构造和发送
/// </summary>
class Net_work
{
    public void Network(string user, string password)
    {
        IP_Test_module IPD = new IP_Test_module();

        List<string> poststring1 = new List<string>
        {
            "wlanuserip="+IPD.IPAddress,
            "&wlanacname=gzhlxy",
            "&chal_id=&chal_vector=",
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
            "&url=&usertime=0",
            "&listpasscode=0",
            "&listgetpass=0",
            "&getpasstype=0",
            "&randstr=",
            "&domain=GDHLXY",
            "&isRadiusProxy=false",
            "&usertype=0",
            "&isHaveNotice=0",
            "&times=12",
            "&weizhi=0&smsid=0",
            "&freeuser=",
            "&freepasswd=",
            "&listwxauth=0",
            "&templatetype=1",
            "&tname=5",
            "&logintype=0",
            "&act=",
            "&is189=true",
            "&terminalType=",
            "&useridtemp=",
            "&userid="+user+"%40GDHLXY",
            "&passwd="+password
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
/// 真实有线网卡IP获得
/// </summary>
public class IP_Test_module
{
    private const string IPv4RegularExpression = "^(?:(?:25[0-5]|2[0-4]\\d|((1\\d{2})|([1-9]?\\d)))\\.){3}(?:25[0-5]|2[0-4]\\d|((1\\d{2})|([1-9]?\\d)))$";
    private const string Device_Include = "^GBE$";
    //正则式
    private string[] Device { get; set; }//所有真实的网卡
    private string Target_Device { get; set; }//筛选出来的有线网卡
    //Adapter的元素
    private string[] IPAddresses { get; set; }
    public string IPAddress { get; set; }

    public IP_Test_module()
    {
        ManagementObjectCollection Ture_NETWork_Adapter = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter WHERE PNPDeviceID LIKE 'PCI%'").Get();
        foreach(ManagementObject Ture_Adapter in Ture_NETWork_Adapter)
        {
            Device = Ture_Adapter["Description"] as string[];
        }
        foreach(string Ture_Device in Device)
        {
            Match matchs = Regex.Match(Ture_Device, Device_Include);
            if(matchs.Success)
            {
                Target_Device = Ture_Device;
            }
        }
        //先从Win32_NetworkAdapter里面筛选符合条件的网卡并提取描述，并在下面与Win32_NetworkAdapterConfiguration类里查找相同描述的网卡并取得IP地址
        //这是 Win32_NetworkAdapter https://docs.microsoft.com/zh-cn/windows/desktop/CIMWin32Prov/win32-networkadapter 的元素
        //这是 Win32_NetworkAdapterConfiguration https://docs.microsoft.com/zh-cn/windows/desktop/CIMWin32Prov/win32-networkadapterconfiguration 的元素
        //windows网卡的管理真tm屑，煞 笔 系 统 
        ManagementObjectCollection Target_Adapter_info = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE Description=" + "'" + Target_Device + "'").Get();
        foreach(ManagementObject Address in Target_Adapter_info)
        {
            IPAddresses = Address["IPAddress"] as string[];
            foreach(string Target_Address in IPAddresses)
            {
                Match matchs = Regex.Match(Target_Address , IPv4RegularExpression);//IP组有IPV4和IPV6，这里用正则式筛掉IPV6
                if(matchs.Success)
                {
                    IPAddress = Target_Address;
                }
            }
        }
    }
}