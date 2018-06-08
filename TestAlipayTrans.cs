using System;
using System.Collections.ObjectModel;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPrepare4Crawler
{
    [TestClass]
    public class TestAlipayTrans
    {
  
        [TestMethod]
        public void TestAlipayLogin()
        {
            IWebDriver driver = new InternetExplorerDriver();
    
             driver.Navigate().GoToUrl("https://consumeprod.alipay.com/record/advanced.htm");

             WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            //IWebElement elemDatetimSelect = wait.Until(d=>d.FindElement(By.Id("J-datetime-select")));
               IWebElement elemRealRange = wait.Until(d=>d.FindElement(By.Id("J-select-range")));
            Thread.Sleep(new Random().Next(1000, 5000));
            ((IJavaScriptExecutor)driver).ExecuteScript("document.getElementById('J-select-range').style.display='inline';", elemRealRange);

               SelectElement selectElementReal=new SelectElement(elemRealRange);
               selectElementReal.SelectByText("最近三个月");

            Thread.Sleep(new Random().Next(1000, 5000));
            IWebElement queryButton = driver.FindElement(By.Id("J-set-query-form"));//to find the 搜索 <input>

            //  ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", queryButton);
            Actions builder = new Actions(driver);
            builder.Click(queryButton).Perform();
            Thread.Sleep(new Random().Next(5000, 10000));
            //driver.Close();

            IWebElement tradeRecords = driver.FindElement(By.Id("tradeRecordsIndex")).FindElement(By.Id("J-item-1"));
            string htmlStr = (String)tradeRecords.Text;
    
        }
    }
}
