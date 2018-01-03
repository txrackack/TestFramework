using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using WordpressAutomation.Properties;

namespace WordpressAutomation
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static string BaseAddress
        {
            get { return "http://localhost:8080/testframework/"; }
        }

        public static void Initialize()
        {
            string path = Settings.Default.geckodriver;
            Instance = new FirefoxDriver(path); 
            TurnOnWait();
        }

        public static void Close()
        {
            Instance.Quit();
            Instance.Dispose();
        }

        public static void Wait(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        public static void NoWait(Action action)
        {
            TurnOffWait();
            action();
            TurnOnWait();

        }

        private static void TurnOnWait()
        {
            Instance.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(5));
        }

        static void TurnOffWait()
        {
            Instance.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(0));
        }
    }
}