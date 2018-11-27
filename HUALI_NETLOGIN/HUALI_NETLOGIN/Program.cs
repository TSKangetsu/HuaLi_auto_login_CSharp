using System.IO;
using System.Text;
using System.Net;
using System.Collections.Generic;
using System;

/// <summary>
/// 程序主体
/// </summary>
namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Net_work test = new Net_work();
            Strat test2 = new Strat();
            test.Network(test2.User , test2.Password);
        }

    }
}
/// <summary>
///判断是否写入过用户和密码
/// </summary>
class Strat
{
    public string User { get; set; }
    public string Password { get; set; }
    public Strat()
    {
        string path = System.IO.Directory.GetCurrentDirectory();
        String path1 = path + "/user.txt";
        string path2 = path + "/password.txt";
        if (File.Exists(path1) == false)
        {
            Console.WriteLine("请输入用户名");
            User = Console.ReadLine();
            Console.WriteLine("请输入密码");
            Password = Console.ReadLine();
            /*----------------------------------*/
            FileStream txtfile = new FileStream(path1, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter txtwrite = new StreamWriter(txtfile);
            txtwrite.WriteLine(User);
            txtwrite.Close();
            /*---------------------------------*/
            FileStream txtfile2 = new FileStream(path2, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter txtwrite2 = new StreamWriter(txtfile2);
            txtwrite2.WriteLine(Password);
            txtwrite2.Close();
        }
        else
        {
            User = File.ReadAllText(path1);
            Password = File.ReadAllText(path2);
        }
    }
}
/// <summary>
/// 网络构造和发送
/// </summary>
class Net_work
{
    private string GETIP()
    {
        string psde = string.Empty;
        string ipd = Dns.GetHostName();
        IPAddress[] iplist = Dns.GetHostAddresses(ipd);
        foreach (IPAddress IPD in iplist)
        {
            if (IPD.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                psde = IPD.ToString();
            }
        };
        return psde;
    }
    public void Network(string user, string password)
    {
        Net_work ins = new Net_work();

        List<string> poststring1 = new List<string>
        {
            "wlanuserip="+  ins.GETIP(),
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
        WebClient data_post = new WebClient();
        data_post.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
        data_post.UploadData(url, "POST", postData);
    }
}