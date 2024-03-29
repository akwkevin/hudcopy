﻿using AICWPF.Chart;
using Arction.Wpf.Charting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;


//注意下面的语句一定要加上，指定log4net使用.config文件来读取配置信息
//如果是WinForm（假定程序为MyDemo.exe，则需要一个MyDemo.exe.config文件）
//如果是WebForm，则从web.config中读取相关信息
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace AICWPF
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            LightningChartUltimate.SetDeploymentKey(LicenseKeyStrings.LightningChartUltimate);
            System.Windows.FrameworkCompatibilityPreferences.KeepTextBoxDisplaySynchronizedWithTextProperty = false;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.Current.DispatcherUnhandledException += Application_DispatcherUnhandledException;
        }

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            //记录严重错误 
            log.Fatal(e.Exception);
            e.Handled = true;//使用这一行代码告诉运行时，该异常被处理了，不再作为UnhandledException抛出了。            
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //记录严重错误                  
            log.Fatal(e.ExceptionObject);
        }

        [DllImport("user32", CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindow(string cls, string win);
        [DllImport("user32")]
        static extern IntPtr SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32")]
        static extern bool IsIconic(IntPtr hWnd);
        [DllImport("user32")]
        static extern bool OpenIcon(IntPtr hWnd);
        System.Threading.Mutex mutex;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            bool ret;
            mutex = new System.Threading.Mutex(true, "ElectronicNeedleTherapySystem", out ret);

            if (!ret)
            {
                ActivateOtherWindow();
                Environment.Exit(0);
            }

#if XBAP//XBAP.2
            Application.Current.StartupUri = new Uri("Views/ShellPage.xaml", UriKind.Relative);//
#else
            Bootstrapper bootstrapper = new Bootstrapper();
            bootstrapper.Run();
#endif
        }

        private static void ActivateOtherWindow()
        {
            //里面的文本改成自己程序窗口的标题
            var other = FindWindow(null, AIC.Core.LocalSetting.Title);
            if (other != IntPtr.Zero)
            {
                SetForegroundWindow(other);
                if (IsIconic(other))
                    OpenIcon(other);
            }
        }

        protected override void OnLoadCompleted(System.Windows.Navigation.NavigationEventArgs e)
        {
#if XBAP//XBAP.3
            Bootstrapper bootstrapper = new Bootstrapper();
            bootstrapper.Run();
#else

#endif
        }
    }
}
