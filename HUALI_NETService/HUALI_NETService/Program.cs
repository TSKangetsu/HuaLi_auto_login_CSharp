using System.ComponentModel;
using System.ServiceProcess;
using System.Configuration.Install;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Net;
/*--------------------------------------------------------------------------------------------------------------------------/*杀一个程序员祭天*/
namespace HUALI_NETService
{
    /// <summary>
    /// 程序的主入口（基本框架）
    /// </summary>
    using HUALI_NETObject;//程序集在Object.cs里面
    using HUALI_NET;//程序集在NET.cs里面
    /***---------------***/
    static class Program
    {
        static void Main()
        {
            Detect_info test_ins = new Detect_info();//使用之前导入的参数判断是以windows服务启动还是启动安装程序；*/*/在Start.cs内的类
            if(test_ins.Detect() == "installed")
            {//这一段是判断是否输入过用户密码，有则会成为服务的形式运行，否则执行else，将会变为控制台程序获取输入*/
                ServiceBase[] ServicesToRun = new ServiceBase[]
                {
                    new Service1()
                };
                ServiceBase.Run(ServicesToRun);
            }//到这里为服务本体，在OnStart方法启动---------------------------------------------------------------*/
            else
            {
                Ride_info test_ins2 = new Ride_info();//Start.cs内的类
            }
        }
    }
    /// <summary>
    /// Service的主入口（基本框架）
    /// </summary>
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)//服务承载的主体，开机自动运行的部分
        {
            Detect_info infoNet = new Detect_info();//初始化Start.cs的类，获得账户密码的字段
            Net_work Net_Drive = new Net_work();//初始话NET.cs的方法
            Net_Drive.Network(infoNet.User1 , infoNet.Password1);
        }

        protected override void OnStop()
        {
        }
    }
    /*--------------------------------------------------------------------------------------------设计器生成的默认代码，我也不知道有什么用*/
    /// <summary>
    /// 这后面真的不用管了我也看不懂，都是windows服务的模板要求
    /// </summary>
    /// 
    partial class Service1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region 组件设计器生成的代码
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.ServiceName = "Service1";
        }
        #endregion
    }
    /*-------------------------------------------------------------------------------------------------------------------下面是琪露诺时间*/
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
    partial class ProjectInstaller
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码
        private void InitializeComponent()
        {
            this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            /*------------------------------------------------------------------------windows服务的信息，貌似是安装服务才有在servicecontrol看到-----------------------------------*/
            // 
            // serviceProcessInstaller1
            // 
            this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller1.Password = null;
            this.serviceProcessInstaller1.Username = null;
            // 
            // serviceInstaller1
            // 里面是在servicecontrol里面的名字和描述---*/
            this.serviceInstaller1.Description = "TEST";
            this.serviceInstaller1.DisplayName = "SERVICE TEST";
            this.serviceInstaller1.ServiceName = "Service tests";
            this.serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller1,
            this.serviceInstaller1});

        }
        #endregion
        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;
        private System.ServiceProcess.ServiceInstaller serviceInstaller1;
    }
}
