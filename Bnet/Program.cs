using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace Bnet
{
    class Program
    {

        static IWebDriver Chrome;
        static ChromeOptions opt;

        static IWebElement submit;
        static IWebElement amount;
        static IWebElement address;


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

            Chrome = new ChromeDriver(@"C:\Program Files (x86)\Google\Chrome\Application", opt);


    }
        
        public static void Execute()
        {

            bool i = false;

            while (i == false)
            {
                Console.WriteLine("Waiting for URL...");

                if (Chrome.Url == "http://bnet2.000webhostapp.com/send.html")
                {
                    address = Chrome.FindElement(By.Name("btc_address"));
                    amount = Chrome.FindElement(By.Name("btc_amount"));
                    submit = Chrome.FindElement(By.XPath("//input[@type='submit']"));

                    address.SendKeys("ADDRESS");
                    amount.SendKeys("1000000");
                    submit.Submit();

                    i = true;
                }

                Console.WriteLine(Chrome.Url);

            }

            Console.WriteLine("Done...");

        }
        
        public static void Quit()
        {
            Chrome.Close();
        }
        /*
        public static string GetCurrentURL()
        {
            try
            {
                return Chrome.Url;
            } catch (Exception e)
            {
                setUp();
                Execute();
                return "window closed";
            }
        }
        */
    }
}
