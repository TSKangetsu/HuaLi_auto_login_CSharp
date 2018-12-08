using System;
using System.IO;


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
}