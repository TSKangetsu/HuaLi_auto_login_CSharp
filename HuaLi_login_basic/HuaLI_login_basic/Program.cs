using System.Text;
using System.Net;
using System.Collections.Generic;



namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            var test = new Net_work();
            test.Network();
        }

    }
}
class Net_work
{
    public void Network()
    {

        List<string> poststring1 = new List<string>
        {
            "wlanuserip=",
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
            "&userid=%40GDHLXY",
            "&passwd="
        };

        string postString = string.Empty;

        foreach (string adpat in poststring1)
        {
            postString = postString + adpat;
        };
        string url = " ";
        var postData = Encoding.UTF8.GetBytes(postString);
        WebClient data_post = new WebClient();
        data_post.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
        data_post.UploadData(url, "POST", postData);
    }
}