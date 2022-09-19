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
    public class ForgotPassword : WebBrowser
    {
        //error:  Verify code is required
        //confirm_password: The confirm password field is required.
        //password: Password is required
        //least password:  The passwords must be at least 8 characters!
        //not match:  The confirm password and password must match.
       
        //Forgot email
        [TestMethod]
        [TestCategory("Core Function")]
        public void TestForgotPasswordEmail(string email, string actualMsg)
        {
            OpenBrowser(urlProduction);
            clickElement(driver.FindElement(By.CssSelector("a[href='/user/reset-password']")));
            Thread.Sleep(1000);
            FindByName("email").SendKeys(email);
            Thread.Sleep(1000);
            clickElement(driver.FindElement(By.CssSelector("body")));
            clickElement(driver.FindElement(By.CssSelector("button[type='submit']")));
            string expectedMsg = FindByClassName("input-error").Text.ToString();
            //Kết quả
            SignUpAsserMessage(actualMsg, expectedMsg);
            Thread.Sleep(1000);
            driver.Quit();
        }
        //Verify code
        [TestMethod]
        [TestCategory("Core Function")]
        public void TestForgotVerify(string code, string actualMsg)
        {
            FindById("forgot-password-verify-code").SendKeys(code);
            Thread.Sleep(1000);
            FindByClassName("pm-prinary sign-in-button").Click();
            string expectedMsg = FindByClassName("error-blade").Text.ToString();
            //Kết quả
            SignUpAsserMessage(actualMsg, expectedMsg);
            Thread.Sleep(1000);
            driver.Quit();
        }
        //Chang password
        [TestMethod]
        [TestCategory("Core Function")]
        public void TestChangePassword(string password, string confirm_password, string actualMsg)
        {
            FindByName("password").SendKeys(password);
            Thread.Sleep(500);
            FindByName("confirm_password").SendKeys(confirm_password);
            Thread.Sleep(1000);
            FindByClassName("pm-prinary sign-in-button").Click();
            string expectedMsg = FindByClassName("input-error").Text.ToString();
            //Kết quả
            SignUpAsserMessage(actualMsg, expectedMsg);
            Thread.Sleep(1000);
            driver.Quit();
        }

        [TestMethod]
        [TestCategory("Core Function")]
        public void loginGoogleAccount()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--profile-directory=Default");
            options.AddArguments("--whitelisted-ips");
            options.AddArguments("--start-maximized");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-plugins-discovery");
            options.AddArguments("--disable-popup-blocking");
            options.AddArguments("--ignore-certificate-errors");


            WebDriver webDriver = new ChromeDriver(options);
            webDriver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?uilel=3&hl=en&passive=true&service=youtube&continue=https%3A%2F%2Fwww.youtube.com%2Fsignin%3Fhl%3Den%26next%3D%252F%26action_handle_signin%3Dtrue%26app%3Ddesktop&flowName=GlifWebSignIn&flowEntry=ServiceLogin");
            Thread.Sleep(3000);

            var email = webDriver.FindElement(By.XPath("//input[@type='email']"));
            email.SendKeys("nguyenvanquang2k.00@gmail.com");
            Thread.Sleep(1000);

            var emailNext = webDriver.FindElement(By.Id("identifierNext"));
            emailNext.Click();
            Thread.Sleep(1000);

            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("identifierNext")));

            Thread.Sleep(3000);
            var passwordElement = webDriver.FindElement(By.XPath("//input[@type='password']"));
            passwordElement.SendKeys("555644");

            Thread.Sleep(1000);
            var passwordNext = webDriver.FindElement(By.Id("passwordNext"));
            passwordNext.Click();


        }
        
        [TestCategory("Core Function")]
        public void loginGmail()
        {

            //get row handle
            string currentUser = System.Environment.UserName;
            var driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--incognito");
                options.AddArgument(@"--start-maximized");
                options.AddArguments(@"user-data-dir=C:\Users\" + currentUser + @"\AppData\Local\Google\Chrome\User Data");

            var driver = new ChromeDriver(driverService, options);


                driver.Navigate().GoToUrl("https://stackoverflow.com/users/login");
            //driver.Manage().Window.Minimize();
                driver.FindElement(By.CssSelector(".flex--item.s-btn.s-btn__icon.s-btn__google.bar-md.ba.bc-black-100")).Click();
                var query = driver.FindElement(By.CssSelector("input[type='email']"));
                query.SendKeys("nguyenvanquang2k.00@gmail.com");
                query = driver.FindElement(By.CssSelector("div#identifierNext"));
                query.Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                query = driver.FindElement(By.CssSelector("input[name='password']"));
                query.SendKeys("2655255");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                Thread.Sleep(500);

                query = driver.FindElement(By.XPath(".//*[@id='passwordNext']//content//span"));
                query.Click();
                Thread.Sleep(1000);

        }
    }
}
