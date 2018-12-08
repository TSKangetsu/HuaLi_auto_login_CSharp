using System;
using PCI_IP_module;
using Start_Menu;

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
            IP_Test_module ins = new IP_Test_module();
            Net_work test = new Net_work();
            test.Network(user, password);
        }

    }
}
