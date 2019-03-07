using System;
using Start_Menu;
using HUALI_NETLOGIN_Netim;

/// <summary>
/// 程序主体
/// </summary>
namespace HUALI_NETLOGIN
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
                Netim test = new Netim(user, password);
            }catch
            {

            }
        }

    }
}
