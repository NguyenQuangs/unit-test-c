﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Threading.Tasks;
using System.Threading;
using static TestCaseByCase.HelperTest;
using System.Runtime.CompilerServices;

namespace TestCaseByCase
{
    [TestClass]
    public class UnitTest1 : WebBrowser
    {

        string email = "nguyennhatquang16k.00@gmail.com";
        string pw = "123456Aa@";

        [TestMethod]
        public void TestCheck()
        {
            StubExtensionManager stub = new StubExtensionManager();
            FileChecker checker = new FileChecker(stub);

            //Action
            bool IsTrueFile = checker.CheckFile("myFile.whatever");

            //Assert
            Assert.AreEqual(true, IsTrueFile);
        }

     
        //2. range input: amount, min, max
        //1000 usdt
        //min 1.000.000
        //max 5.000.000
        [TestMethod]
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

            //VERIFY
            //var list = htmlxxxx
            //list.contain(xxxx)


        }

        [TestMethod]
        public void TestCreateP2POrder_Case3_EmptyInput()
        {
            //setup test
            OpenBrowser();

            //1. Login 
            //2. Select Post My - Ads

            //input
            //1
            //2. range input: amount, min, max
            //-100 usdt
            //min 10.000.000
            //max 50.000.000
            //3. remark, option

            //click go

            //VERIFY
            //expect error:
            //var list = htmlxxxx
            //list.contain(xxxx)


        }

        //[TestMethod]
        //public void TestUIAsync()
        //{
        //    //setup test
        //    OpenBrowser();

        //    //1.sign in with email
        //    //2. wallet page


        //    //input

        //    //output


        //    //verify expected
        //    //1. đã tới dc wallet page
        //    //2. Top menu có user name của : khanh1412

        //    FindById("//*[@id='dropdownMenuOffset']/img").Click();
        //    //action(Keys.PageDown);

        //    Console.WriteLine("Waiting");
        //    FindElementByxPath("//*[@id='navbarButtonsExample']/div/ul/li[3]/div/ul/li[1]").Click();
        //    Thread.Sleep(1000);
        //}
        [TestMethod]
        public void LandingPage()
        {
            OpenBrowser();

            var textBuy = FindElementByxPath("/html/body/nav/div/div/ul/li[1]/a");
            if (!textBuy.Displayed)
            {
                Console.WriteLine("Không tìm thấy từ 'Buy'");
            }
            var textSell = FindElementByxPath("/html/body/nav/div/div/ul/li[2]/a");
            if (!textSell.Displayed)
            {
                Console.WriteLine("Không tìm thấy từ 'Sell'");
            }
            var textAds = FindElementByxPath("/html/body/nav/div/div/ul/li[3]/a");
            if (!textAds.Displayed)
            {
                Console.WriteLine("Không tìm thấy từ 'My Ads'");
            }
            var selectCurrency = FindElementByxPath("/html/body/nav/div/div/div/ul/li[4]/select");
            if (!selectCurrency.Displayed)
            {
                Console.WriteLine("Không tìm thấy 'Currency'");
            }
            FindElementByxPath("/html/body/nav/div/div/div/ul/li[4]/select/option[2]").Click();
            var banner = FindElementByxPath("/html/body/section[1]/div");
            if (!banner.Displayed)
            {
                Console.WriteLine("Không tìm thấy banner");
                Thread.Sleep(1000);
                driver.Quit();
            }

            var textBanner = FindElementByxPath("/html/body/section[1]/div/div/a");
            var textBanner_1 = FindElementByxPath("/html/body/section[1]/div/p");
            var textBanner_2 = FindElementByxPath("/html/body/section[1]/div/h3");
            if (!textBanner.Displayed || !textBanner_1.Displayed || !textBanner_2.Displayed)
            {
                Console.WriteLine("Không tìm thấy text trong banner");
                Thread.Sleep(500);
                driver.Quit();
            }

            var tbCoin = FindElementByxPath("/html/body/section[2]/section");
            if (!tbCoin.Displayed)
            {
                Console.WriteLine("Không tìm thấy table coin");
                Thread.Sleep(500);
                driver.Quit();
            }
            action(Keys.PageDown);

            if (!FindElementByxPath("/html/body/section[3]/div[2]/div[1]/img").Displayed || !FindElementByxPath("/html/body/section[3]/div[2]/div[2]/img").Displayed
                || !FindElementByxPath("/html/body/section[3]/div[2]/div[3]/img").Displayed || !FindElementByxPath("/html/body/section[3]/div[2]/div[4]/img").Displayed)
            {
                Console.WriteLine("Không tìm thấy hình ảnh");
                Thread.Sleep(500);
                driver.Quit();
            }
            if (!FindElementByxPath("/html/body/section[4]/div[1]/h4").Displayed || !FindElementByxPath("/html/body/section[4]/div[2]/div[1]").Displayed
               || !FindElementByxPath("/html/body/section[4]/div[2]/div[2]").Displayed || !FindElementByxPath("/html/body/section[4]/div[2]/div[3]").Displayed)
            {
                Console.WriteLine("Không tìm card");
                Thread.Sleep(500);
                driver.Quit();
            }
            if (!FindElementByxPath("//html/body/section[5]").Displayed || !FindElementByxPath("/html/body/section[5]/div/div/div[2]/h1").Displayed
               || !FindElementByxPath("/html/body/section[5]/div/div/div[1]/img").Displayed || !FindElementByxPath("/html/body/section[5]/div/div/div[2]/p").Displayed)
            {
                Console.WriteLine("Không tìm thay text");
                Thread.Sleep(500);
                driver.Quit();
            }
            action(Keys.PageDown);

            var textFAQ_1 = FindElementByxPath("/html/body/section[7]/div/div[1]/div[1]/span/h6/a");
            var textFAQ_2 = FindElementByxPath("/html/body/section[7]/div/div[1]/div[2]/span/h6/a");
            var textFAQ_3 = FindElementByxPath("/html/body/section[7]/div/div[1]/div[3]/span/h6/a");

            if (!FindElementByxPath("/html/body/section[7]/div/div[1]/h3").Displayed || !textFAQ_1.Displayed
               || !textFAQ_2.Displayed ||
               !textFAQ_3.Displayed || !FindElementByxPath("/html/body/section[7]/div/div[2]/img").Displayed)
            {
                Console.WriteLine("Không tìm thay FAQ");
                Thread.Sleep(500);
                driver.Quit();
            }

            if (!FindElementByxPath("/html/body/footer/section").Displayed)
            {
                Console.WriteLine("Không tìm thấy footer");
            }
            driver.Quit();
        }

        [TestMethod]
        public void Withdraw()
        {
            //Declare variable
            By dropdown = By.XPath("/html/body/header/div[2]/div[3]/div[2]/span");
            string sreachEth = "ETH";
            string address = "0x828B4f6Ba4E172D003811b14b2625e24DFff3bb6";
            // Navigate to a page

            Login(email, pw);
            // Withdraw

            FindById("search-coin-funding").SendKeys(sreachEth);
            Thread.Sleep(2000);
            action(Keys.Enter);
            Thread.Sleep(2000);
            FindElementByxPath("/html/body/div[4]/div/div[2]/section[2]/div/div[2]/div[1]/div/table/tbody/tr[1]/td[4]/div/a[2]").Click();
            // Test form
            FindElementByxPath("/html/body/div[4]/div[1]/div[2]/section[2]/div/div/div/form/div/div[2]/div[2]/input").SendKeys(address);
            Thread.Sleep(2000);
            FindElementByxPath("/html/body/div[4]/div[1]/div[2]/section[2]/div/div/div/form/div/div[2]/div[2]/div[2]").Click();
            Thread.Sleep(2000);
            FindElementByxPath("/html/body/div[4]/div[1]/div[2]/section[2]/div/div/div/form/div/div[2]/div[2]/div[3]/form/div/div/section[2]/div/table/tbody/tr[1]/td").Click();
            string element = FindElementByxPath("/html/body/div[4]/div[1]/div[2]/section[2]/div/div/div/form/div/div[5]/div/input").GetAttribute("value");
            if (element != "Withdraw")
            {
                Console.WriteLine("Withdraw error");
                driver.Quit();
            }
            Console.WriteLine("Pass withdraw");
            Thread.Sleep(3000);
            driver.Quit();
        }

        // email: Nguyenvanquang2k.00@gmail.com
        //  pw: 123456Aa@

        [TestMethod]
        public void TestLogout()
        {
            // login page 
            Login(email, pw);
            Thread.Sleep(2000);
            string actualUrl = "http://127.0.0.1:8000/user/signin-email";
            Console.WriteLine("Login successfully");
            var userImg = FindElementByxPath("/html/body/header/div[2]/div[3]/div[2]/span");
            if (!userImg.Displayed)
            {
                Console.WriteLine("Not found image");
                return;
            }
            userImg.Click();
            Thread.Sleep(2000);

            if (!FindElementByxPath("/html/body/header/div[2]/div[3]/div[2]/ul/li[2]/a").Displayed)
            {
                Console.WriteLine("Not found text 'My profile'");
                driver.Quit();
            }
            if (!FindElementByxPath("/html/body/header/div[2]/div[3]/div[2]/ul/li[3]/a").Displayed)
            {
                Console.WriteLine("Not found text 'Payment Methods'");
                driver.Quit();
            }
            if (!FindElementByxPath("/html/body/header/div[2]/div[3]/div[2]/ul/li[4]/a").Displayed)
            {
                Console.WriteLine("Not found text 'Seurity'");
                driver.Quit();
            }
            if (!FindElementByxPath("/html/body/header/div[2]/div[3]/div[2]/ul/li[2]/a").Displayed)
            {
                Console.WriteLine("Not found text 'Personal Verification'");
                driver.Quit();
            }
            if (!FindElementByxPath("/html/body/header/div[2]/div[3]/div[2]/ul/li[2]/a").Displayed)
            {
                Console.WriteLine("Not found text 'Settings'");
                driver.Quit();
            }

            FindElementByxPath("/html/body/header/div[2]/div[3]/div[2]/ul/li[7]/a").Click();

            var expectedUrl = driver.Url;

            Assert.AreEqual(expectedUrl, actualUrl, "Logout Fail");
            Thread.Sleep(2000);
            driver.Quit();
        }

        string email_test = "dwadaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa12312321.00@gmail.com";
        string pw_test = "123456Aa@";
    

        [TestMethod]
        public void TestSignUpMobile()
        {
            OpenBrowser();
            var element = FindElementByxPath("//*[@id='navbarButtonsExample']/div/ul/li[2]/div");
            if (!element.Displayed)
            {
                Console.WriteLine("Click sign up page fail");
            }
            element.Click();
            FindElementByxPath("/html/body/div/div/div[2]/div[1]/div[3]/div/span[2]").Click();

            string actualUrl = "http://127.0.0.1:8000/user/verifycode-signup-mobile";

            //input

            FindByName("mobile").SendKeys("3265666732");
            FindByName("password").SendKeys("123456Aa@");
            FindByName("check18").Click();
            FindElementByxPath("//*[@id=\"create-account\"]").Click();

            string expectedUrl = driver.Url;

            var verify = FindByName("verify_code");
            if (!verify.Displayed)
            {
                Console.WriteLine("Not found input verify code");
                Thread.Sleep(1000);
                driver.Quit();
            }
            if (!FindElementByxPath("//*[@id=\"signin\"]/div[1]/div").Displayed)
            {
                Console.WriteLine("Not found message error input verify");
                Thread.Sleep(1000);
                driver.Quit();
            }
            Console.WriteLine("Register sign up mobile successfully");
            Assert.AreEqual(actualUrl, expectedUrl, "Register sign up mobile successfully");
            Thread.Sleep(1000);
            driver.Quit();
        }

        void TestSignUp(string url, string email, string password, string code, IWebDriver driver)
        {
            // Quang 
        }

        void SignupAssert(IWebDriver driver, string errorMessage)
        {
            //
        }
    }
}
