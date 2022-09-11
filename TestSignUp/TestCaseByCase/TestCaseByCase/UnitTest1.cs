using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Threading.Tasks;
using System.Threading;
using static TestCaseByCase.HelperTest;

namespace TestCaseByCase
{
    [TestClass]
    public class UnitTest1 : WebBrowser
    {
        public IWebDriver driver = null;
        public ChromeOptions chromeOptions;

        [TestMethod]
        public void TestMethod2()
        {
            StubExtensionManager stub = new StubExtensionManager();
            FileChecker checker = new FileChecker(stub);

            //Action
            bool IsTrueFile = checker.CheckFile("myFile.whatever");

            //Assert
            Assert.AreEqual(true, IsTrueFile);
        }
        public IWebDriver OpenBrowser(string url)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            return driver;
        }

        private void Login(string email, string password)
        {
            By inputPw = By.Name("password");
            By btnSubmit = By.TagName("button");

            OpenBrowser("http://127.0.0.1:8000");
            // Get the current URL
            string url = driver.Url;
            // Get the current page HTML source
            string html = driver.PageSource;
            FindElementByxPath("//*[@id='navbarButtonsExample']/div/ul/li[3]/div/ul/li[1]").SendKeys(email);
            driver.FindElement(inputPw).SendKeys(password);
            driver.FindElement(btnSubmit).Click();

            string title = driver.Title;
            if (title == "Payme - Wallet")
            {
                Console.WriteLine("Pass login");
            }
            else
            {
                Console.WriteLine("error");
                driver.Quit();
            }
        }



        [TestMethod]
        public async Task TestUIAsync()
        {



            

            //string actualUrl = "http://127.0.0.1:8000/user";
            Actions act = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver,
            TimeSpan.FromSeconds(30));
            act.SendKeys(Keys.PageDown).Build().Perform();
            //string expectedUrl = driver.Url;
            FindById("//*[@id='dropdownMenuOffset']/img").Click();
            Console.WriteLine("Waiting");
            //var _result = await TakesALongTimeToProcess("Test");
            wait.Timeout.Minutes.ToString("1");
            driver.FindElement(By.XPath("//*[@id='navbarButtonsExample']/div/ul/li[3]/div/ul/li[1]")).Click();
            Thread.Sleep(1000);
            //Assert.AreEqual(actualUrl, expectedUrl);
            //

            driver.Quit();

        }

      

        //private Task<string> TakesALongTimeToProcess(
        //    string word)
        //{
        //    return Task.Run(() =>
        //    {
        //        Task.Delay(1000);
        //        return word;

        //    });
        //}


        [TestMethod]
        public void TestMethod1()
        {
            By inputEmail = By.Name("email");
            By inputPw = By.Name("password");
            By btnSubmit = By.TagName("button");
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-extensions"); // to disable extension
            options.AddArguments("--disable-notifications"); // to disable notification
            options.AddArguments("--disable-application-cache"); // to disable cache

            //ChromeDriverService chormeDriverService = ChromeDriverService.CreateDefaultService();
            //chormeDriverService.HideCommandPromptWindow = true;
            IWebDriver driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://127.0.0.1:8000/user/signin-email");
            string actualUrl = "http://127.0.0.1:8000/user";

            Login("nguyenvanquang2k.00@gmail.com", "123456Aa@");
            Console.WriteLine("Hello");

            string expectedUrl = driver.Url;
            driver.FindElement(By.XPath("/html/body/header/div[2]/div[3]/div[2]")).Click();
            driver.FindElement(By.XPath("/html/body/header/div[2]/div[3]/div[2]/ul/li[7]/a")).Click();
            Assert.AreEqual(actualUrl, expectedUrl);

            driver.Quit();

        }

        [TestMethod]
        public void TestSignInMobile()
        {
            By inputMobile = By.Name("mobile");
            By inputPw = By.Name("password");
            By btnSubmit = By.TagName("button");
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-extensions"); // to disable extension
            options.AddArguments("--disable-notifications"); // to disable notification
            options.AddArguments("--disable-application-cache"); // to disable cache

            //ChromeDriverService chormeDriverService = ChromeDriverService.CreateDefaultService();
            //chormeDriverService.HideCommandPromptWindow = true;
            IWebDriver driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://127.0.0.1:8000/user/signin-mobile");
            string actualUrl = "http://127.0.0.1:8000/user";

            driver.FindElement(inputMobile).SendKeys("326566732");
            driver.FindElement(inputPw).SendKeys("123456Aa@");
            driver.FindElement(btnSubmit).Click();

            string expectedUrl = driver.Url;
            driver.FindElement(By.XPath("/html/body/header/div[2]/div[3]/div[2]")).Click();
            driver.FindElement(By.XPath("/html/body/header/div[2]/div[3]/div[2]/ul/li[7]/a")).Click();

            Assert.AreEqual(actualUrl, expectedUrl);

            driver.Quit();

        }

        [TestMethod]
        public void TestSignUpEmail()
        {
            By inputEmail = By.Name("email");
            By inputPw = By.Name("password");
            By btnSubmit = By.TagName("button");
            By inputVerify = By.Name("verify_code");
            By inputChecked = By.Name("check18");

            // ChromeDriverService chormeDriverService = ChromeDriverService.CreateDefaultService();
            // chormeDriverService.HideCommandPromptWindow = false;
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://127.0.0.1:8000/user/signup-email");
            string actualUrl = "http://127.0.0.1:8000/user";


            driver.FindElement(inputEmail).SendKeys("ngyenvanquang2k.00@gmail.com");
            driver.FindElement(inputPw).SendKeys("123456Aa@");

            driver.FindElement(inputChecked).Click();
            driver.FindElement(btnSubmit).Click();
            // SignUp.Form1.ReferenceEquals.inputVerify
            driver.FindElement(inputVerify).SendKeys("");

            String expectedUrl = driver.Url;

            //driver.FindElement(By.XPath("/html/body/header/div[2]/div[3]/div[2]")).Click();
            //driver.FindElement(By.XPath("/html/body/header/div[2]/div[3]/div[2]/ul/li[7]/a")).Click();

            Assert.AreEqual(actualUrl, expectedUrl);

            driver.Quit();

        }

        [TestMethod]
        public void TestSignUpMobile()
        {
            By inputEmail = By.Name("mobile");
            By inputPw = By.Name("password");
            By btnSubmit = By.TagName("button");
            By inputVerify = By.Name("verify_code");
            By inputChecked = By.Name("check18");

            // ChromeDriverService chormeDriverService = ChromeDriverService.CreateDefaultService();
            // chormeDriverService.HideCommandPromptWindow = false;
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://127.0.0.1:8000/user/signup-email");
            string actualUrl = "http://127.0.0.1:8000/user";
            string val = Convert.ToString(Console.ReadLine());
            string email = Convert.ToString(Console.ReadLine());
            string pw = Convert.ToString(Console.ReadLine());


            driver.FindElement(inputEmail).SendKeys(email);
            driver.FindElement(inputPw).SendKeys(pw);

            driver.FindElement(inputChecked).Click();
            driver.FindElement(btnSubmit).Click();
            driver.FindElement(inputVerify).SendKeys("");

            string expectedUrl = driver.Url;

            //driver.FindElement(By.XPath("/html/body/header/div[2]/div[3]/div[2]")).Click();
            //driver.FindElement(By.XPath("/html/body/header/div[2]/div[3]/div[2]/ul/li[7]/a")).Click();
            Assert.AreEqual(actualUrl, expectedUrl);

            driver.Quit();

        }
    }
}
