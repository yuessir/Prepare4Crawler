using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPrepare4Crawler
{
    [TestClass]
    public class SearchTest
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //    IWebDriver webDriver=new FirefoxDriver();
        //    webDriver.Navigate().GoToUrl("https://www.google.com");
        //    IWebElement webElement = webDriver.FindElement(By.Name("q"));
        //    webElement.SendKeys("facebook");
        //    webElement.Submit();
        //    System.Threading.Thread.Sleep(1000);
        //    webDriver.Quit();

        //}

        //[TestMethod]
        //public void TestEdge()
        //{

        //    IWebDriver driver = new EdgeDriver();
        //    driver.Navigate().GoToUrl("https://www.bing.com");
        //    var src = driver.PageSource;
        //    IWebElement webElement = driver.FindElement(By.Name("q"));
        //    webElement.SendKeys("facebook");
        //    webElement.Submit();
        //    System.Threading.Thread.Sleep(1000);
        //   // driver.Quit();
        //}

        //[TestMethod]
        //public void TestYahooAutoLogin()
        //{
        //    IWebDriver driver = new EdgeDriver();
        //    driver.Navigate().GoToUrl("https://login.yahoo.com/");
        //    IWebElement webElement = driver.FindElement(By.Id("login-username"));
        //    webElement.SendKeys("account");//account field
        //    System.Threading.Thread.Sleep(1000);
        //    driver.FindElement(By.Id("login-signin")).Click();

        //    driver.FindElement(By.Id("login-passwd")).SendKeys("password123");//password field
        //    driver.FindElement(By.Id("login-signin")).Click();
        //    webElement.Submit();
        //    driver.Close();

        //}

        /// <summary>
        /// Tests the flip automatic chat.
        /// </summary>
        [TestMethod]
        public void TestFlipAutoChat()
        {
            IWebDriver webDriver = new FirefoxDriver();
            webDriver.Navigate().GoToUrl("https://fleep.io/chat");
            webDriver.FindElement(By.XPath("//input[@placeholder='Username or email address']")).SendKeys("account");
            webDriver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("passwd");

            webDriver.FindElement(By.XPath("//button[contains(text(), 'SIGN IN')]")).Click();

            //System.Threading.Thread.Sleep(9000);// the waiting for a threading time is not ideal
            //webDriver.FindElement(By.XPath("//div[contains(text(),'微軟mvp讀書會')]")).Click();
            //WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            //webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var elem = FindElement(webDriver,By.XPath("//div[contains(text(),'!華陰街阿婆麵攤好吃')]"),10);
             ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].click();", elem);

             elem = webDriver.FindElement(By.XPath("//textarea[@placeholder='Type your message']"));
            
            elem.SendKeys("bootstrap " + DateTime.Now.ToLongDateString());
            elem.FindElement(By.XPath("//div[contains(text(), 'Send')]")).Click();
            webDriver.Quit();
            //var elems = webDriver.FindElements(By.ClassName("conversation"));
            //foreach (var elem in elems)
            //{
            //    if (elem.GetAttribute("data-id") == "8ac9096d-41cf-476f-a666-15ef3a469a84")
            //    {
            //        elem.Click();
            //        // ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].click();", elem);
            //    }
            //}

        }

        /// <summary>
        /// Finds the element.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="by">The by.</param>
        /// <param name="timeoutInSeconds">The timeout in seconds.</param>
        /// <returns>IWebElement.</returns>
        public IWebElement FindElement( IWebDriver driver, By by, int timeoutInSeconds)
            {
                if (timeoutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    return wait.Until(drv => drv.FindElement(by));
                }
                return driver.FindElement(by);
            }

    }
}
