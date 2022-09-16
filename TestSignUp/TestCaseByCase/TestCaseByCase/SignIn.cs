using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace TestCaseByCase
{
    [TestClass]
    public class SignIn :WebBrowser
    {

        [TestMethod]
        [TestCategory("Sign In Email")]
        public void SignInEmail_BlankInput_ExpectErrorMessage()
        {
            //environment Test DEV
            var url = "http://127.0.0.1:8000/user/signup-email";
            var email = "";
            var password = "";
            string actualMsg = "Email is required!";

            TestSignInEmail(url, email, password, actualMsg);
        }

        [TestMethod]
        [TestCategory("Sign In Email")]
        public void SignInEmail_Blank_Email()
        {
            //environment Test DEV
            var url = "http://127.0.0.1:8000/user/signup-email";
            var email = "";
            var password = "123456789";
            string actualMsg = "Email is required!";

            TestSignInEmail(url, email, password, actualMsg);
        }
        [TestMethod]
        [TestCategory("Sign In Email")]
        public void SignInEmail_Blank_Password()
        {
            //environment Test DEV
            var url = "http://127.0.0.1:8000/user/signup-email";
            var email = "nguyenvanquang2k.00@gmail.com";
            var password = "";
            string actualMsg = "Password is required!";

            TestSignInEmail(url, email, password, actualMsg);
        }

        [TestMethod]
        [TestCategory("Sign In Email")]
        public void SignInEmail_Very_Short_Password()
        {
            //environment Test DEV
            var url = "http://127.0.0.1:8000/user/signup-email";

            var email = "nguyenvanquang2k.00@gmail.com";
            var password = "123456";
            string actualMsg = "Invalid Nickname or Password is incorrect.4try left!";

            TestSignInEmail(url, email, password, actualMsg);
        }

        [TestMethod]
        public void SignInEmail_Char_Special_Email()
        {
            //environment Test DEV
            var url = "http://127.0.0.1:8000/user/signup-email";
           
            var email = "dwadaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa12312321!!!!!.00@gmail @.com";
            var password = "123456Aa@";
            string actualMsg = "";

            TestSignInEmail(url, email, password, actualMsg);
        }

        [TestMethod]
        [TestCategory("Sign In Mobile")]
        public void SignInMobile_BlankInput_ExpectErrorMessage()
        {
            //environment Test DEV
            var url = "http://127.0.0.1:8000/user/signup-email";
            var mobile = "";
            var password = "";
            string actualMsg = "Mobile is required!";

            TestSignInMobile(url, mobile, password, actualMsg);
        }

        [TestMethod]
        [TestCategory("Sign Up Mobile")]
        public void SignInMobile_Blank_Mobile()
        {
            //environment Test DEV
            var url = "http://127.0.0.1:8000/user/signup-email";

            var mobile = "";
            var password = "123456789";
            string actualMsg = "Mobile is required!";

            TestSignInMobile(url, mobile, password, actualMsg);
        }
        [TestMethod]
        [TestCategory("Sign In Mobile")]
        public void SignInMobile_Blank_Password()
        {
            //environment Test DEV
            var url = "http://127.0.0.1:8000/user/signup-email";
            var mobile = "0326589654";
            var password = "";
            string actualMsg = "Password is required!";

            TestSignInMobile(url, mobile, password, actualMsg);
        }

        [TestMethod]
        [TestCategory("Sign In Mobile")]
        public void SignInMobile_Very_Short_Password()
        {
            //environment Test DEV
            var url = "http://127.0.0.1:8000/user/signup-email";

            var mobile = "0326589654";
            var password = "123456";
            string actualMsg = "Invalid Nickname or Password is incorrect.4try left!";

            TestSignInMobile(url, mobile, password, actualMsg);
        }

        [TestMethod]
        [TestCategory("Sign In Mobile")]
        public void SignInMobile_Char_Special_Mobile()
        {
            //environment Test DEV
            var url = "http://127.0.0.1:8000/user/signup-email";

            var mobile = "0326589654";
            var password = "123456Aa@";

            string actualMsg = "";

            TestSignInMobile(url, mobile, password, actualMsg);
        }

        [TestCategory("Core Function")]
        public void TestSignInEmail(string url, string email, string password, string actualMsg)
        {
            OpenBrowser();
            clickElement(driver.FindElement(By.CssSelector("a[class='btn btn-log-in']")));
            Thread.Sleep(1000);
            FindById("email").SendKeys(email);
            FindById("password").SendKeys(password);
            Thread.Sleep(1000);
            FindById("keepsign").Click();
            Thread.Sleep(1000);
            FindByClassName("btn-pm-primary-sign-in col-12 text-uppercase").Click();
            string expectedMsg = FindByClassName("error-blade").Text.ToString();
            //Kết quả
            SignUpAsserMessage(actualMsg, expectedMsg);
            Thread.Sleep(1000);
            driver.Quit();
        }

        [TestCategory("Core Function")]
        public void TestSignInMobile(string url, string mobile, string password, string actualMsg)
        {
            OpenBrowser();
            clickElement(driver.FindElement(By.CssSelector("a[class='btn btn-log-in']")));
            clickElement(driver.FindElement(By.CssSelector("a[class='deactive']")));
            Thread.Sleep(1000);
            FindById("mobile").SendKeys(mobile);
            FindById("password").SendKeys(password);
            Thread.Sleep(1000);
            FindById("keepsign").Click();
            Thread.Sleep(1000);
            FindByClassName("btn-pm-primary-sign-in col-12 text-uppercase").Click();
            string expectedMsg = FindByClassName("error-blade").Text.ToString();
            //Kết quả
            SignUpAsserMessage(actualMsg, expectedMsg);
            Thread.Sleep(1000);
            driver.Quit();
        }
    }
}
