using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace SeleniumPrepare4Crawler
{
    [TestClass]
    public class HeadlessFirefoxTest
    {
       

        /// <summary>
        /// Tests the flip automatic chat.
        /// </summary>
        [TestMethod]
        public void TestHeadlessFirefox()
        {
            IWebDriver webDriver = CreateEdgeDriver();
            
            webDriver.Navigate().GoToUrl("https://fleep.io/chat");
            webDriver.FindElement(By.XPath("//input[@placeholder='Username or email address']")).SendKeys("account");
            webDriver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("pwd");

            webDriver.FindElement(By.XPath("//button[contains(text(), 'SIGN IN')]")).Click();

            System.Threading.Thread.Sleep(9000);
            //hard code
            webDriver.FindElement(By.XPath("//div[contains(text(),'微軟mvp讀書會')]")).Click();
            var elem = webDriver.FindElement(By.XPath("//textarea[@placeholder='Type your message']"));
            elem.SendKeys(DateTime.Now.ToLongDateString());
            elem.FindElement(By.XPath("//div[contains(text(), 'Send')]")).Click();
            webDriver.Quit();


        }

        /// <summary>
        /// Creates the firefox driver.
        /// </summary>
        /// <returns>OpenQA.Selenium.IWebDriver.</returns>
        private static IWebDriver CreateFirefoxDriver()
        {

            var service = FirefoxDriverService.CreateDefaultService();
            var option = new FirefoxOptions();
            option.AddArgument("-headless"); //headless firefox
            //option.AddArgument("-private-window");//incognito mode;private mode  ref:https://developer.mozilla.org/en-US/docs/Mozilla/Command_Line_Options

            return new FirefoxDriver(service, option, TimeSpan.FromSeconds(40));

        }
        private static IWebDriver CreateEdgeDriver()
        {

            var service = EdgeDriverService.CreateDefaultService();
            //option.("-headless"); //https://github.com/SeleniumHQ/selenium/issues/5984

            return new EdgeDriver(service);

        }
    }
}
