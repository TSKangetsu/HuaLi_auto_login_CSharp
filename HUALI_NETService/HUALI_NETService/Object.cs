using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace HUALI_NETObject
{
    class Detect_info
    {
        public string User1;
        public string Password1;
        public string inst_note;
        public string path1 = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/HUALI_login.txt";
        public string Detect()
        {
            try
            {
                StreamReader str2 = new StreamReader(path1);
                User1 = str2.ReadLine();
                Password1 = str2.ReadLine();
                inst_note = str2.ReadLine();
            }catch
            {
                inst_note = "not installed";
            }
            return inst_note;
        }

    }

    class ride_info
    {
        public string User1;
        public string Password1;
        public ride_info()
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
                txtwrite.WriteLine("installed");
                txtwrite.Close();
                /*---------------------------------*/
            }
        }
    }
}
