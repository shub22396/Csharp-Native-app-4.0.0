
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace ConsoleApp1
{
    public class Program
    {
        public static IWebDriver driver;
        public static String ltUserName = "shubhamr";
        public static String ltAppKey = "";
        public static String platform;
        public static String browser;
        public static String browserVersion;

        //public static string seleniumUri = "https://hub.lambdatest.com:443/wd/hub";


        [Obsolete]
        static void Main(string[] args)
        {


            AppiumOptions caps = new AppiumOptions();
            caps.AddAdditionalCapability("platformName", "android");
            caps.AddAdditionalCapability("deviceName", "Galaxy Note 20");
            caps.AddAdditionalCapability("platformVersion", "12");
            //caps.AddAdditionalCapability("isRealMobile", true);



            driver = new RemoteWebDriver(new Uri("http://" + ltUserName + ":" + ltAppKey + "@hub.lambdatest.com/wd/hub/"), caps, TimeSpan.FromSeconds(600));



            //driver.Manage().Window.Maximize();
            driver.Url = "https://lambdatest.github.io/sample-todo-app/";

            Assert.AreEqual("Sample page - lambdatest.com", driver.Title);
            String itemName = "Yey, Let's add it to list";
            // Click on First Check box
            IWebElement firstCheckBox = driver.FindElement(By.Name("li1"));
            firstCheckBox.Click();

            // Click on Second Check box
            IWebElement secondCheckBox = driver.FindElement(By.Name("li2"));
            secondCheckBox.Click();

            // Enter Item name 
            IWebElement textfield = driver.FindElement(By.Id("sampletodotext"));
            textfield.SendKeys(itemName);

            // Click on Add button
            IWebElement addButton = driver.FindElement(By.Id("addbutton"));
            addButton.Click();

            // Verified Added Item name
            IWebElement itemtext = driver.FindElement(By.XPath("/html/body/div/div/div/ul/li[6]/span"));
            String getText = itemtext.Text;
            Assert.IsTrue(itemName.Contains(getText));

            driver.Quit(); //really important statement for preventing your test execution from a timeout.
        }
    }
}
