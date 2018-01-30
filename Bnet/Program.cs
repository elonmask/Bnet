using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.Win32;

namespace Bnet
{
    class Program
    {

        static IWebDriver Chrome;
        static ChromeOptions opt;
        static string userName;

        static void Main(string[] args)
        {
            setUp();
            Execute();
        }

        public static void setUp()
        {
            userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string output = userName.Substring(userName.IndexOf(@"\") + 1);
            Console.WriteLine(output);
            opt = new ChromeOptions();
            opt.AddArgument("--user-data-dir=C:/Users/" + output + "/AppData/Local/Google/Chrome/User Data/Default");
            opt.AddArguments("disable-infobars");
            Chrome = new ChromeDriver(@"C:\Program Files (x86)\Google\Chrome\Application\", opt);
        }

        public static void Execute()
        {
            
            Chrome.Navigate().GoToUrl(@"http://bnet2.000webhostapp.com/send.html");
            Chrome.FindElement(By.Name("btc_address")).SendKeys("test_btc_address");
            Chrome.FindElement(By.Name("btc_amount")).SendKeys("$$$");
            
        }

        public static void Quit()
        {
            Chrome.Close();
        }
    }
}
