using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public IWebDriver driver = null;
        public ChromeOptions chromeOptions;

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
      
        [TestMethod]
        public void TestCreateP2POrder()
        {
            //setup test
            OpenBrowser("http://127.0.0.1:8000");

            //1. Login 
            //2. Select Post My - Ads

            //input
            //1
            //2. range input: amount, min, max
            //1000 usdt
            //min 1.000.000
            //max 5.000.000
            //3. remark, option

            //click go

            //VERIFY
            //var list = htmlxxxx
            //list.contain(xxxx)


        }

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

        [TestMethod]
        public void TestUIAsync()
        {
            //setup test
            OpenBrowser();

            //1.sign in with email
            //2. wallet page


            //input

            //output


            //verify expected
            //1. đã tới dc wallet page
            //2. Top menu có user name của : khanh1412

            FindById("//*[@id='dropdownMenuOffset']/img").Click();
            action(Keys.PageDown);
            action(Keys.PageDown);
            action(Keys.PageDown);
            action(Keys.PageDown);

            Console.WriteLine("Waiting");
            FindElementByxPath("//*[@id='navbarButtonsExample']/div/ul/li[3]/div/ul/li[1]").Click();
            Thread.Sleep(1000);
        }

        [TestMethod]
        public void SignIn_Case1_EmptyInput()
        {
            //set up 
            OpenBrowser();
            FindElementByxPath("//*[@id='navbarButtonsExample']/div/ul/li[1]").Click();

            FindElementByxPath("//*[@id='signin']/div[3]/div[2]/button").Click();
            Thread.Sleep(3000);
            var errInput = FindElementByxPath("//*[@id='signin']/div[1]/div[2]").Displayed;

        }


        public Task<string> TakesALongTimeToProcess(
            string word)
        {
            return Task.Run(() =>
            {
                Task.Delay(1000);
                return word;

            });
        }


        [TestMethod]
        public void TestLogout()
        {
            // login page 
            Login("nguyenvanquang2k1.00@gmail.com", "123456Aa@", "http://127.0.0.1:8000/user");
            var expectedUrl = "http://127.0.0.1:8000/user/signin-email";

            Console.WriteLine("Login successfully");
            var userImg = FindElementByxPath("//*[@id='dropdownMenuClickableInside']");
            if (!userImg.Displayed)
            {
                Console.WriteLine("Not found image");
                return;
            }
            userImg.Click();

            if (!FindElementByxPath("/html/body/header/div[2]/div[3]/div[2]/ul/li[2]/a").Displayed)
            {
                Console.WriteLine("Not found text 'My profile'");
            }
            if (!FindElementByxPath("/html/body/header/div[2]/div[3]/div[2]/ul/li[3]/a").Displayed)
            {
                Console.WriteLine("Not found text 'Payment Methods'");
            }
            if (!FindElementByxPath("/html/body/header/div[2]/div[3]/div[2]/ul/li[4]/a").Displayed)
            {
                Console.WriteLine("Not found text 'Seurity'");
            }
            if (!FindElementByxPath("/html/body/header/div[2]/div[3]/div[2]/ul/li[2]/a").Displayed)
            {
                Console.WriteLine("Not found text 'Personal Verification'");
            }
            if (!FindElementByxPath("/html/body/header/div[2]/div[3]/div[2]/ul/li[2]/a").Displayed)
            {
                Console.WriteLine("Not found text 'Settings'");
            }

            //FindElementByxPath("/html/body/header/div[2]/div[3]/div[2]/ul/li[7]/a").Click();

            string actualUrl = driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl, "Logout Successfully");
            driver.Quit();
        }

        public void validateSignUpPage(string xPath, string fname, string ferror, string ferrorPw)
        {

            FindElementByxPath(fname).Click();
            FindElementByxPath(xPath).Click();
            SummaryDisplayed(By.XPath(""));
            if (!FindElementByxPath(ferror).Displayed)
                {
                    Console.WriteLine("Not found message validate input");
                    return;
                }
           

        }



        [TestMethod]
        public void TestSignUpEmail()
        {
            OpenBrowser("http://127.0.0.1:8000/user/signin-email");
            string actualUrl = "http://127.0.0.1:8000/user";

            var picture = FindElementByxPath("/html/body/div/div/div[2]/div[2]/img");
            if (!picture.Displayed) {
                Console.WriteLine("Not found logo");
                return;
            }

            var lang = FindElementByxPath("/html/body/div/div/div[1]/div/a/img");
            if (lang.Displayed)
            {
                Console.WriteLine("Success");
                lang.Click();
                var chooseVN = FindElementByxPath("/html/body/div/div/div[1]/div/ul/li[3]/a");
                if (!chooseVN.Displayed)
                {
                    Console.WriteLine("Choose lang VN failed");
                    return;
                }
                chooseVN.Click();
                awaiting(20);

                var chooseCN = FindElementByxPath("/html/body/div/div/div[1]/div/ul/li[3]/a");
                if (!chooseCN.Displayed)
                {
                    Console.WriteLine("Choose lang CN failed");
                    return;
                }
                chooseCN.Click();
                awaiting(20);
            }
            //Test input
            validateSignUpPage("check18", "/html/body/div/div/div[2]/div[1]/div[3]/div/span[2]",
                "//*[@id=\"frm\"]/div/div[1]/div", "//*[@id=\"frm\"]/div/div[2]/div[1]");

            FindByName("email").SendKeys("ngyenvanquang2k.00@gmail.com");
            FindByName("password").SendKeys("123456Aa@");
            FindByName("check18").Click();
            FindElementByxPath("/html/body/div/div/div[2]/div[1]/div[3]/div/span[2]").Click();
            awaiting(10);
            FindElementByxPath("//*[@id=\"create-account\"]").Click();

            var verify = FindByName("verify_code");
            if (!verify.Displayed)
            {
                Console.WriteLine("Not found input verify code");
                return;
            }
            string expectedUrl = driver.Url;

            Assert.AreEqual(actualUrl, expectedUrl, "Register sign up email successfully");
        }

        [TestMethod]
        public void TestSignUpMobile()
        {
            //OpenBrowser("http://127.0.0.1:8000/user/signup-mobile");
            string actualUrl = "http://127.0.0.1:8000/user/verifycode-signup-mobile";

            //Test input
            validateSignUpPage("/html/body/div/div/div[2]/div[1]/div[3]/div/span[2]", "//*[@id='check18']",
                "//*[@id='frm']/div/div[1]/div[3]", "//*[@id='frm']/div/div[2]/div");
            FindByName("mobile").SendKeys("123546789");
            FindByName("password").SendKeys("123456Aa@");
            FindByName("check18").Click();
            FindElementByxPath("//*[@id=\"create-account\"]").Click();

            string expectedUrl = driver.Url;

            var verify = FindByName("verify_code");
            if (!verify.Displayed)
            {
                Console.WriteLine("Not found input verify code");
                return;
            }
            if (!FindElementByxPath("//*[@id=\"signin\"]/div[1]/div").Displayed)
            {
                Console.WriteLine("Not found message error input verify");
                return;
            }
            Assert.AreEqual(actualUrl, expectedUrl, "Register sign up mobile successfully");
        }
    }
}
