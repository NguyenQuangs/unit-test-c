using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading.Tasks;
using System.Threading;


namespace TestCaseByCase
{
    [TestClass]
    public class WebBrowser
    {
        int waitingTime = 10;

        public IWebDriver driver = null;
        public ChromeOptions chromeOptions;
        //Environment project
        //local dev
        public string urlLocal = "http://127.0.0.1:8000/";
        // Production 
        public string urlProduction = "https://payme.thangovn.com/";
        // Dev
        public string urlDev = "http://payme-dev.thangovn.com/";


        public WebBrowser()
        {
            ChromeDriverService chormeDriverService = ChromeDriverService.CreateDefaultService();
            chormeDriverService.HideCommandPromptWindow = true;
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--disable-extensions"); // to disable extension  //*[@id="navbarButtonsExample"]/div/ul/li[3]/div
            chromeOptions.AddArguments("--disable-notifications"); // to disable notification
            chromeOptions.AddArguments("--disable-application-cache"); // to disable cache
            driver = new ChromeDriver(chromeOptions);
        }
        public IWebDriver OpenBrowser()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(urlLocal);
            return driver;
        }

        public IWebDriver OpenBrowser(string url)
        {
            //input staging / production environment

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            return driver;
        }

        public void Login(string email, string password)
        {
            FindElementByxPath("//*[@id=\"navbarButtonsExample\"]/div/ul/li[1]/a").Click();
            FindByName("email").SendKeys(email);
            FindByName("password").SendKeys(password);
            FindElementByxPath("//*[@id=\"keepsign\"]").Click();
            FindElementByxPath("//*[@id=\"signin\"]/div[3]/div[2]/button").Click();
            string actualUrl = driver.Url;
            Assert.AreEqual(urlProduction + "user", actualUrl, "Login Success");
        }

        public Task<IWebElement> TakesALongTimeToProcess(
        IWebElement element)
        {
            return Task.Run(() =>
            {
                Task.Delay(1000).Wait();
                return element;

            });
        }
        public WebDriverWait awaiting(int second)
        {
            WebDriverWait wait = new WebDriverWait(driver,
            TimeSpan.FromSeconds(second));
            wait.Until((x) =>
            {
                return ((IJavaScriptExecutor)driver).ExecuteScript(
                "return document.readyState").Equals("complete");
            });
            return wait;
        }

        public bool SummaryDisplayed(By element)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                var myElement = wait.Until(x => x.FindElement(element));
                return myElement.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public WebDriverWait webDriverAwait(int seconds, By by)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds)); //20 seconds
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
            return wait;
        }

        //Await class
        public IAlert WaitUntil_AlertIsPresent(int waitingTime)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitingTime));
            return wait.Until(ExpectedConditions.AlertIsPresent());
        }
        public IWebElement WaitUntil_ElementExists(By by, int waitingTime)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitingTime));
            return wait.Until(ExpectedConditions.ElementExists(by));
        }
        public IWebElement WaitUntil_ElementIsVisible(By by, int waitingTime)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitingTime));
            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }
        public bool WaitUntil_ElementSelectionStateToBe(By by, bool selected, int waitingTime)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitingTime));
            return wait.Until(ExpectedConditions.ElementSelectionStateToBe(by, selected));
        }
        public bool WaitUntil_ElementSelectionStateToBe(IWebElement element, bool expectedState, int waitingTime)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitingTime));
            return wait.Until(ExpectedConditions.ElementSelectionStateToBe(element, expectedState));
        }
        public IWebElement WaitUntil_ElementToBeClickable(IWebElement element, int waitingTime)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitingTime));
            return wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
        public IWebElement WaitUntil_ElementToBeClickable(By by, int waitingTime)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitingTime));
            return wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
        public bool WaitUntil_InvisibilityOfElementLocated(By by, int waitingTime)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitingTime));
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }
        public bool WaitUntil_InvisibilityOfElementWithText(By by, string text, int waitingTime)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitingTime));
            return wait.Until(ExpectedConditions.InvisibilityOfElementWithText(by, text));
        }
        public bool WaitUntil_StalenessOf(IWebElement element, int waitingTime)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitingTime));
            return wait.Until(ExpectedConditions.StalenessOf(element));
        }
        public bool WaitUntil_TextToBePresentInElement(IWebElement element, string str, int waitingTime)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitingTime));
            return wait.Until(ExpectedConditions.TextToBePresentInElement(element, str));
        }

        public IWebElement FindElementByxPath(string xPath)
        {
            return driver.FindElement(By.XPath(xPath));
        }

        public IWebElement FindById(string id)
        {
            return driver.FindElement(By.Id(id));
        }
        public IWebElement FindByCssSelector(string css)
        {
            return driver.FindElement(By.CssSelector(css));
        }

        public IWebElement FindByName(string name)
        {
            return driver.FindElement(By.Name(name));
        }
        public IWebElement FindByClassName(string className)
        {
            return driver.FindElement(By.ClassName(className));
        }

        public Actions action(string keyAction)
        {
            Actions act = new Actions(driver);
            act.SendKeys(keyAction).Build().Perform();
            return act;
        }

        //Using click Action Selenium
        public Actions mouseClickAction(IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Click().Build().Perform();
            return actions;
        }

        //Using click Action Selenium
        public void mouseAction(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
             js.ExecuteScript("arguments[0].scrollIntoView();", element);
        }

        public IWebElement FindLinkText(string linkTxt)
        {
        return driver.FindElement(By.LinkText(linkTxt));
        }

    //public Actions selectText(IWebElement findElementByName)
    //{
    //    //create select element object 
    //    SelectElement selectElement = new SelectElement(findElementByName);

    //    //select by value
    //    selectElement.SelectByValue("Jr.High");
    //    // select by text
    //    selectElement.SelectByText("HighSchool");
    //}

    //using javascript click
    public IJavaScriptExecutor clickElement(IWebElement element)
        {
            string javascript = "arguments[0].click()";
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript(javascript, element);
            return jsExecutor;
        }

        //using cuon toi 1 phan  tu trong trang
        public IJavaScriptExecutor scrollIntoViewElement(IWebElement element)
        {
            string javascript = "arguments[0].scrollIntoView(true)";
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript(javascript, element);
            Thread.Sleep(2000);
            return jsExecutor;
        }


        public IJavaScriptExecutor getValue(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
             js.ExecuteScript("return arguments[0].value", element).ToString();
            return js;
        }

        public void WaitForLoadElement(IWebElement element, int timeoutSec = 90)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSec));
            wait.Until(wd => js.ExecuteScript("return arguments[0].value", element).ToString());
        }

        //Ghi log file
        //Declaration of the file stream and format 
        private string _logFile = string.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        public StreamWriter stream = null;

        //Create a file that will be used to store the log information
        public void CreateLogFile()
        {
            //create a directory
            string filePath = @"C:\LogRecords\";

            if (Directory.Exists(filePath))
            {
                stream = File.AppendText(filePath + _logFile + ".log");
            }
            else
            {
                Directory.CreateDirectory(filePath);
                stream = File.AppendText(filePath + _logFile + ".log");
            }
        }

        //Create a method that can write the information into the log file
        public void WriteToFile(string Message)
        {
            stream.Write("{0} {1}\t", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            stream.Write("\\T{0}", Message);
            stream.Flush();
        }

        public void SignUpAssert(string expected, string actual)
        {
            Assert.AreEqual(expected, actual);
        }
        public void SignUpAsserMessage(string expectedMsg, string actualMsg)
        {
            Assert.AreEqual(expectedMsg, actualMsg);
        }
    }
}


    
