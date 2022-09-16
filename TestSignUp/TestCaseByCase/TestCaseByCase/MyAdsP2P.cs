using System;
using System.IO;
using System.Reflection;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestCaseByCase
{
    [TestClass]
    public class MyAdsP2P :WebBrowser
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestCategory("Core Function")]
        //Remind đã KYC rồi
        public void TestMyAdsIWantBuy(string email, string password, string amount, string min, string max)
        {
            OpenBrowser();
            Login(email, password);
            var textMyAds = FindElementByxPath("/html/body/header/div[1]/a[3]/div");
            textMyAds.Click();
            Thread.Sleep(3000);
            //click post my ads
            var btnPost = FindElementByxPath("/html/body/form/section/div/div[2]/div[2]/input");
            btnPost.Click();
            Thread.Sleep(1000);

            FindById("ETH").Click();
            FindById("VND").Click();
            var btnNext = FindById("btnNext");
            btnNext.Submit();

            FindById("total_amount").SendKeys(amount);
            FindById("order_min").SendKeys(min);
            FindById("order_max").SendKeys(max);
            Thread.Sleep(4000);
            FindById("btnAdd").Click();
            Thread.Sleep(2000);
            clickElement(driver.FindElement(By.ClassName("method-text")));

            var btnNext_2 = FindElementByxPath("//*[@id='btnNext']");
            clickElement(btnNext_2);
            Thread.Sleep(2000);

            //post my ads
            var btnPost_2 = FindById("btnPosAds");
            clickElement(btnPost_2);
            FindElementByxPath("//a[normalize-space()='Confirm']").Click();
            driver.Quit();
        }

        [TestCategory("Core Function")]
        //Remind đã KYC rồi
        public void TestMyAdsIWantSell(string email, string password, string amount, string min, string max)
        {
            OpenBrowser();
            Login(email, password);
            var textMyAds = FindElementByxPath("/html/body/header/div[1]/a[3]/div");
            textMyAds.Click();
            Thread.Sleep(3000);
            //click post my ads
            var btnPost = FindElementByxPath("/html/body/form/section/div/div[2]/div[2]/input");
            btnPost.Click();
            Thread.Sleep(1000);

            FindById("ETH").Click();
            FindById("VND").Click();
            var btnNext = FindById("btnNext");
            btnNext.Submit();

            FindById("total_amount").SendKeys(amount);
            FindById("order_min").SendKeys(min);
            FindById("order_max").SendKeys(max);
            Thread.Sleep(4000);
            FindById("btnAdd").Click();
            Thread.Sleep(2000);
            clickElement(driver.FindElement(By.ClassName("method-text")));

            var btnNext_2 = FindElementByxPath("//*[@id='btnNext']");
            clickElement(btnNext_2);
            Thread.Sleep(2000);

            //post my ads
            var btnPost_2 = FindById("btnPosAds");
            clickElement(btnPost_2);
            FindElementByxPath("//a[normalize-space()='Confirm']").Click();
            driver.Quit();
        }

        [TestCategory("Core Function")]
        //Remind chưa KYC rồi
        public void TestMyAdsKYCIWantSell(string email, string password, string amount, string min, string max)
        {
            OpenBrowser();
            Login(email, password);
            var textMyAds = FindElementByxPath("/html/body/header/div[1]/a[3]/div");
            textMyAds.Click();
            Thread.Sleep(3000);
            //click post my ads
            var btnPost = FindElementByxPath("/html/body/form/section/div/div[2]/div[2]/input");
            btnPost.Click();
            Thread.Sleep(1000);

                string expected_case1 = "http://127.0.0.1:8000/user/kyc";
                var btnKYC = FindElementByxPath("/html/body/div[4]/div/section/div/div[3]/a");
                btnKYC.Click();
                Thread.Sleep(2000);
                string actual_case1 = driver.Url;
                Assert.AreEqual(expected_case1, actual_case1, "Failed verify KYC");
            FindById("ETH").Click();
            FindById("VND").Click();
            var btnNext = FindById("btnNext");
            btnNext.Submit();

            FindById("total_amount").SendKeys(amount);
            FindById("order_min").SendKeys(min);
            FindById("order_max").SendKeys(max);
            Thread.Sleep(4000);
            FindById("btnAdd").Click();
            Thread.Sleep(2000);
            clickElement(driver.FindElement(By.ClassName("method-text")));

            var btnNext_2 = FindElementByxPath("//*[@id='btnNext']");
            clickElement(btnNext_2);
            Thread.Sleep(2000);

            //post my ads
            var btnPost_2 = FindById("btnPosAds");
            clickElement(btnPost_2);
            FindElementByxPath("//a[normalize-space()='Confirm']").Click();
            driver.Quit();
        }
      
    }
}
