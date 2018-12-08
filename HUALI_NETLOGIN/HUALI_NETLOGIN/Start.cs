using System;
using System.Diagnostics;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Start_Menu
{
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
                Console.WriteLine("如果需要开机自动登录,关闭程序,请右键以管理员身份运行");
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
                //下面拷贝文件到启动文件夹
                try
                {
                    File.Copy(path + @"\HUALI_NETLOGIN.exe", path + @"\HUALI_AUTO.exe");
                    FileInfo FileCopyTo = new FileInfo(path + @"\HUALI_AUTO.exe");
                    FileCopyTo.MoveTo(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp\HUALI_AUTO.exe");
                }
                catch
                {
                    Console.WriteLine("如果需要开机自动登录，请先删掉‘我的文档’下的 ’HUALI_login.txt‘ 的文件,然后请右键以管理员身份重新运行程序");
                    FileInfo FileCopyTo = new FileInfo(path + @"\HUALI_AUTO.exe");
                    FileCopyTo.Delete();
                }

            }
            else
            {
                StreamReader str2 = new StreamReader(path1);
                User1 = str2.ReadLine();
                Password1 = str2.ReadLine();
            }
        }
    }
}