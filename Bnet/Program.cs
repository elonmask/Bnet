using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Bnet
{
    class Program
    {

        static IWebDriver Chrome;
        static IWebElement element;
        static ChromeOptions opt;

        static void Main(string[] args)
        {
            setUp();
            Execute();
        }

        public static void setUp()
        {
            opt = new ChromeOptions();
            opt.AddArgument(@"user-data-directory=C:\Users\Сергей\AppData\Local\Google\Chrome\User Data\Default");
            Chrome = new ChromeDriver(@"D:\", opt);
        }

        public static void Execute()
        {
            /*
            Chrome.Navigate().GoToUrl(@"http://bnet2.000webhostapp.com/send.html");
            Chrome.FindElement(By.Name("btc_address")).SendKeys("test_btc_address");
            Chrome.FindElement(By.Name("btc_amount")).SendKeys("$$$");
            */
        }

        public static void Quit()
        {
            Chrome.Close();
        }
    }
}
