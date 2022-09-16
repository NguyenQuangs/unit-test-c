using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace TestCaseByCase
{
    [TestClass]
    public class SignUp :WebBrowser
    {
        [TestMethod]
        [TestCategory("Sign Up Email")]
        public void SignUpEmail_BlankInput_ExpectErrorMessage()
        {
            //environment Test DEV
            var url = "http://127.0.0.1:8000/user/signup-email";
            var email = "";
            var password = "";
            var code = "";
            string actualMsg = "Your email is incorrect, please try again!";

            TestSignUpEmail(url, email, password, code, actualMsg);
        }

        [TestMethod]
        [TestCategory("Sign Up Email")]
        public void SignUpEmail_Blank_Email()
        {
            //environment Test DEV
            var url = "http://127.0.0.1:8000/user/signup-email";

            var email = "";
            var password = "123456789";
            var code = "";
            string actualMsg = "Your email is incorrect, please try again!";

            TestSignUpEmail(url, email, password, code, actualMsg);
        }
        [TestMethod]
        [TestCategory("Sign Up Email")]
        public void SignUpEmail_Blank_Password()
        {
            //environment Test DEV
            var url = "http://127.0.0.1:8000/user/signup-email";
            var email = "nguyenvanquang2k.00@gmail.com";
            var password = "";
            var code = "";
            string actualMsg = "Your password is incorrect, please try again!";

            TestSignUpEmail(url, email, password, code, actualMsg);
        }

        [TestMethod]
        [TestCategory("Sign Up Email")]
        public void SignUpEmail_Very_Short_Password()
        {
            //environment Test DEV
            var url = "http://127.0.0.1:8000/user/signup-email";

            var email = "nguyenvanquang2k.00@gmail.com";
            var password = "123456";
            var code = "";
            string actualMsg = "The passwords must be at least 8 characters!";

            TestSignUpEmail(url, email, password, code, actualMsg);
        }

        [TestMethod]
        public void SignUpEmail_Char_Special_Email()
        {
            //environment Test DEV
            var url = "http://127.0.0.1:8000/user/signup-email";

            var email = "dwadaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa12312321!!!!!.00@gmail @.com";
            var password = "123456Aa@";
            var code = "";
            string actualMsg = "";

            TestSignUpEmail(url, email, password, code, actualMsg);
        }

        [TestMethod]
        [TestCategory("Sign Up Mobile")]
        public void SignUpMobile_BlankInput_ExpectErrorMessage()
        {
            //environment Test DEV
            var url = "http://127.0.0.1:8000/user/signup-email";
            var mobile = "";
            var password = "";
            var code = "";
            string actualMsg = "Your mobile is incorrect, please try again!";

            TestSignUpEmail(url, mobile, password, code, actualMsg);
        }

        [TestMethod]
        [TestCategory("Sign Up Mobile")]
        public void SignUpMobile_Blank_Mobile()
        {
            //environment Test DEV
            var url = "http://127.0.0.1:8000/user/signup-email";

            var mobile = "";
            var password = "123456789";
            var code = "";
            string actualMsg = "Your mobile is incorrect, please try again!";

            TestSignUpEmail(url, mobile, password, code, actualMsg);
        }
        [TestMethod]
        [TestCategory("Sign Up Mobile")]
        public void SignUpMobile_Blank_Password()
        {
            //environment Test DEV
            var url = "http://127.0.0.1:8000/user/signup-email";
            var mobile = "0326589654";
            var password = "";
            var code = "";
            string actualMsg = "Your password is incorrect, please try again!";

            TestSignUpEmail(url, mobile, password, code, actualMsg);
        }

        [TestMethod]
        [TestCategory("Sign Up Mobile")]
        public void SignUpMobile_Very_Short_Password()
        {
            //environment Test DEV
            var url = "http://127.0.0.1:8000/user/signup-email";

            var mobile = "0326589654";
            var password = "123456";
            var code = "";
            string actualMsg = "The passwords must be at least 8 characters!";

            TestSignUpEmail(url, mobile, password, code, actualMsg);
        }

        [TestMethod]
        [TestCategory("Sign Up Mobile")]
        public void SignUpMobile_Char_Special_Mobile()
        {
            //environment Test DEV
            var url = "http://127.0.0.1:8000/user/signup-email";

            var mobile = "0326589654";
            var password = "123456Aa@";
            var code = "";
            string actualMsg = "";

            TestSignUpEmail(url, mobile, password, code, actualMsg);
        }

        [TestCategory("Core Function")]
        public void TestSignUpEmail(string url, string email, string password, string code, string actualMsg)
        {
            OpenBrowser();
            FindByClassName("btn-boxed").Click();
            //input
            FindById("email").SendKeys(email);
            FindById("password").SendKeys(password);
            Thread.Sleep(1000);
            FindById("check18").Click();
            Thread.Sleep(1000);
            FindById("create-account").Click();
            string expectedMsg = FindByClassName("error-blade").Text.ToString();

            //Kết quả
            SignUpAsserMessage(actualMsg, expectedMsg);
            Thread.Sleep(1000);
            driver.Quit();
        }

        [TestCategory("Core Function")]
        public void TestSignUpMobile(string url, string mobile, string password, string code, string actualMsg)
        {
            OpenBrowser();
            FindByClassName("btn-boxed").Click();
            clickElement(driver.FindElement(By.CssSelector("a[href='signup-mobile?ref=']")));
            //input
            FindById("mobile").SendKeys(mobile);
            FindById("password").SendKeys(password);
            Thread.Sleep(1000);
            FindById("check18").Click();
            Thread.Sleep(1000);
            FindById("create-account").Click();
            string expectedMsg = FindByClassName("error-blade").Text.ToString();

            //Kết quả
            SignUpAsserMessage(actualMsg, expectedMsg);
            Thread.Sleep(1000);
            driver.Quit();
        }

        public void verify_blank()
        {
            var verify = FindById("verify_code");
            WaitForLoadElement(verify);
            FindById("verify").Click();
        }
       
    }
}
