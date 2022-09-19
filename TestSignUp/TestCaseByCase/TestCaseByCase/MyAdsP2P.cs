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
        [TestCategory("MyAds P2P")]
        public void TestMethod1()
        {
        }

        //2. range input: amount, min, max
        //1000 usdt
        //min 1.000.000
        //max 5.000.000
        [TestMethod]
        [TestCategory("MyAds P2P")]
        public void TestCreateP2POrder_Case2()
        {
            //setup test
            OpenBrowser();

            //1. Login 
            //2. Select Post My - Ads

            //input
            //1
            //2. range input: amount, min, max
            //500 usdt
            //min 10.000.000
            //max 50.000.000
            //3. remark, option

            //click go
            var email = "nguyenvanquang2k.00@gmail.com";
            var password = "123456Aa@";
            var amount = "50";
            var min = "10000000";
            var max = "50000000";
            TestMyAdsIWantBuy(urlProduction, email, password, amount, min, max);


        }

        //2. Select Post My - Ads

        //input
        //1
        //2. range input: amount, min, max
        //-100 usdt
        //min 10.000.000
        //max 50.000.000
        //3. remark, option
        [TestMethod]
        [TestCategory("MyAds P2P")]
        public void TestCreateP2POrder_Case3_EmptyInput()
        {
            var email = "nguyenvanquang2k.00@gmail.com";
            var password = "123456Aa@";
            var amount = "0.5";
            var min = "150000";
            var max = "20000000";
            TestMyAdsIWantBuy(urlProduction, email, password, amount, min, max); 
        }

        [TestMethod]
        [TestCategory("Core Function")]
        //Remind đã KYC rồi
        public void TestMyAdsIWantBuy(string urlProduction, string email, string password, string amount, string min, string max)
        {
            OpenBrowser(urlProduction);
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

        [TestMethod]
        [TestCategory("Core Function")]
        //Remind đã KYC rồi
        public void TestMyAdsIWantSell(string email, string password, string amount, string min, string max)
        {
            OpenBrowser(urlProduction);
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

        [TestMethod]
        [TestCategory("Core Function")]
        //Remind chưa KYC rồi
        public void TestMyAdsKYCIWantSell(string email, string password, string amount, string min, string max)
        {
            OpenBrowser(urlProduction);
            Login(email, password);
            var textMyAds = FindElementByxPath("/html/body/header/div[1]/a[3]/div");
            textMyAds.Click();
            Thread.Sleep(3000);
            //click post my ads
            var btnPost = FindElementByxPath("/html/body/form/section/div/div[2]/div[2]/input");
            btnPost.Click();
            Thread.Sleep(1000);
                var btnKYC = FindElementByxPath("/html/body/div[4]/div/section/div/div[3]/a");
                btnKYC.Click();
                Thread.Sleep(2000);
                string actual_case1 = driver.Url;
                Assert.AreEqual(urlProduction + "/user/kyc", actual_case1, "Failed verify KYC");
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
