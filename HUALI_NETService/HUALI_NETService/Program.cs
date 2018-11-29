using System.ComponentModel;
using System.ServiceProcess;
using System.Configuration.Install;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
/*--------------------------------------------------------------------------------------------------------------------------/*cnm的煞笔编译器*/
namespace HUALI_NETService
{
    /// <summary>
    /// 程序的主入口（基本框架）
    /// </summary>
    static class Program
    {
        static void Main()
        {
            ServiceBase[] ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
    /*-------------------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    /// Service的主入口（基本框架）
    /// </summary>
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
    /*--------------------------------------------------------------------------------------------设计器生成的默认代码，我也不知道有什么用*/
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
            // 
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
