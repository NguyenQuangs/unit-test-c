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
            var email = "";
            var password = "";
            string expectedMsg = "Email is required!";

            TestSignInEmail(urlProduction, email, password, expectedMsg);
        }

        [TestMethod]
        [TestCategory("Sign In Email")]
        public void SignInEmail_Blank_Email()
        {
            var email = "";
            var password = "123456789";
            string expectedMsg = "Email is required!";

            TestSignInEmail(urlProduction, email, password, expectedMsg);
        }
        [TestMethod]
        [TestCategory("Sign In Email")]
        public void SignInEmail_Blank_Password()
        {
            var email = "nguyenvanquang2k.00@gmail.com";
            var password = "";
            string expectedMsg = "Password is required!";

            TestSignInEmail(urlProduction, email, password, expectedMsg);
        }

        [TestMethod]
        [TestCategory("Sign In Email")]
        public void SignInEmail_Very_Short_Password()
        {
            var email = "nguyenvanquang2k.00@gmail.com";
            var password = "123456";
            string expectedMsg = "Invalid Nickname or Password is incorrect.4try left!";

            TestSignInEmail(urlProduction, email, password, expectedMsg);
        }

        [TestMethod]
        [TestCategory("Sign In Email")]
        public void SignInEmail_Char_Special_Email()
        {
            var email = "dwadaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa12312321!!!!!.00@gmail @.com";
            var password = "123456Aa@";
            string expectedMsg = "";

            TestSignInEmail(urlProduction, email, password, expectedMsg);
        }

        [TestMethod]
        [TestCategory("Sign In Mobile")]
        public void SignInMobile_BlankInput_ExpectErrorMessage()
        {
            var mobile = "";
            var password = "";
            string expectedMsg = "Password is required!";

            TestSignInMobile(urlProduction, mobile, password, expectedMsg);
        }

        [TestMethod]
        [TestCategory("Sign Up Mobile")]
        public void SignInMobile_Blank_Mobile()
        {
            var mobile = "";
            var password = "123456789";
            string expectedMsg = "Mobile is required!";

            TestSignInMobile(urlProduction, mobile, password, expectedMsg);
        }
        [TestMethod]
        [TestCategory("Sign In Mobile")]
        public void SignInMobile_Blank_Password()
        {
            var mobile = "0326589654";
            var password = "";
            string expectedMsg = "Password is required!";

            TestSignInMobile(urlProduction, mobile, password, expectedMsg);
        }

        [TestMethod]
        [TestCategory("Sign In Mobile")]
        public void SignInMobile_Very_Short_Password()
        {
            var mobile = "326566732";
            var password = "123456";
            string expectedMsg = "Invalid Nickname or Password is incorrect.4try left!";

            TestSignInMobile(urlProduction, mobile, password, expectedMsg);
        }

        [TestMethod]
        [TestCategory("Sign In Mobile")]
        public void SignInMobile_Char_Special_Mobile()
        {
            var mobile = "0326589654";
            var password = "123456Aa@";

            string expectedMsg = "";

            TestSignInMobile(urlProduction, mobile, password, expectedMsg);
        }

        [TestMethod]
        [TestCategory("Core Function")]
        public void TestSignInEmail(string url, string email, string password, string expectedMsg)
        {
            OpenBrowser(url);
            clickElement(driver.FindElement(By.CssSelector("a[class='btn btn-log-in']")));
            Thread.Sleep(1000);
            FindById("email").SendKeys(email);
            FindById("password").SendKeys(password);
            Thread.Sleep(1000);
            FindById("keepsign").Click();
            Thread.Sleep(1000);
            FindElementByxPath("//button[normalize-space()='Sign In']").Click();
            Thread.Sleep(3000);
            var actualMsg = FindElementByxPath("//div[@class='error-blade']").Text;
            //Kết quả
            //SignUpAsserMessage(expectedMsg, actualMsg);
            Thread.Sleep(1000);
            driver.Quit();
        }

        [TestMethod]
        [TestCategory("Core Function")]
        public void TestSignInMobile(string url, string mobile, string password, string expectedMsg)
        {
            OpenBrowser(url);
            clickElement(driver.FindElement(By.CssSelector("a[class='btn btn-log-in']")));
            clickElement(driver.FindElement(By.CssSelector("a[class='deactive']")));
            Thread.Sleep(1000);
            FindById("mobile").SendKeys(mobile);
            FindByName("password").SendKeys(password);
            Thread.Sleep(1000);
            FindById("keepsign").Click();
            Thread.Sleep(1000);
            FindElementByxPath("//button[normalize-space()='Sign In']").Click();
            string actualMsg = FindElementByxPath("//div[@class='error-blade']").Text;
            //Kết quả
            SignUpAsserMessage(expectedMsg, actualMsg);
            Thread.Sleep(1000);
            driver.Quit();
        }
    }
}
