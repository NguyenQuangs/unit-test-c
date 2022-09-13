using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using static TestCaseByCase.HelperTest;
using SeleniumExtras.WaitHelpers;
using System.Threading.Tasks;
using System.Threading;

namespace TestCaseByCase
{
    [TestClass]
    public static class HelperTest
    {

        private static TestContext testContextInstance;
        public interface IExtensionNanager
        {
            Boolean CheckExtension(string FileName);
        }
        public class ExtensionManager : IExtensionNanager
        {
            public bool CheckExtension(string FileName)
            {
                //Some complex business logic might goes here. May be DB operation or file system handling
                return false;
            }
        }

        public class StubExtensionManager : IExtensionNanager
        {
            public bool CheckExtension(string FileName)
            {
                return true;
            }
        }
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public static TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        public static void ShouldEqualWithDiff(this string actualValue, string expectedValue)
        {
            ShouldEqualWithDiff(actualValue, expectedValue, DiffStyle.Full);
        }

        public static void ShouldEqualWithDiff(this string actualValue, string expectedValue, DiffStyle diffStyle)
        {
            ShouldEqualWithDiff(actualValue, expectedValue, diffStyle);
        }

        
        public static void ShouldEqualWithDiff(this string actualValue, string expectedValue, DiffStyle diffStyle, TextWriter output)
        {
            if (actualValue == null || expectedValue == null)
            {
                //Assert.AreEqual(expectedValue, actualValue);
                Assert.Equals(expectedValue, actualValue);
                return;
            }

            if (actualValue.Equals(expectedValue, StringComparison.Ordinal)) return;

            output.WriteLine("  Idx Expected  Actual");
            output.WriteLine("-------------------------");
            int maxLen = Math.Max(actualValue.Length, expectedValue.Length);
            int minLen = Math.Min(actualValue.Length, expectedValue.Length);
            for (int i = 0; i < maxLen; i++)
            {
                if (diffStyle != DiffStyle.Minimal || i >= minLen || actualValue[i] != expectedValue[i])
                {
                    output.WriteLine("{0} {1,-3} {2,-4} {3,-3}  {4,-4} {5,-3}",
                        i < minLen && actualValue[i] == expectedValue[i] ? " " : "*", // put a mark beside a differing row
                        i, // the index
                        i < expectedValue.Length ? ((int)expectedValue[i]).ToString() : "", // character decimal value
                        i < expectedValue.Length ? expectedValue[i].ToString() : "", // character safe string
                        i < actualValue.Length ? ((int)actualValue[i]).ToString() : "", // character decimal value
                        i < actualValue.Length ? actualValue[i].ToString() : "" // character safe string
                    );
                }
            }
            output.WriteLine();

            //Assert.AreEqual(expectedValue, actualValue);
            Assert.Equals(expectedValue, actualValue);
        }

        /// <summary>
        /// Remove whitespace chars.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string StripWhitespace(string input)
        {
            return Regex.Replace(input, @"\s+", " ").Trim();
        }

        private static string ToSafeString(this char c)
        {
            if (Char.IsControl(c) || Char.IsWhiteSpace(c))
            {
                switch (c)
                {
                    case '\r':
                        return @"\r";
                    case '\n':
                        return @"\n";
                    case '\t':
                        return @"\t";
                    case '\a':
                        return @"\a";
                    case '\v':
                        return @"\v";
                    case '\f':
                        return @"\f";
                    default:
                        return String.Format("\\u{0:X};", (int)c);
                }
            }
            return c.ToString(CultureInfo.InvariantCulture);
        }

        public enum DiffStyle
        {
            Full,
            Minimal
        }
    }

    public class WebBrowser
    {
        public IWebDriver driver = null;
        public ChromeOptions chromeOptions;
        string url = "http://127.0.0.1:8000";
        string expectedUrl = "http://127.0.0.1:8000/user";



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
            driver.Navigate().GoToUrl(url);
            return driver;
        }

        public void Login(string email, string password)
        {
            OpenBrowser();
            FindElementByxPath("//*[@id=\"navbarButtonsExample\"]/div/ul/li[1]/a").Click();
            FindByName("email").SendKeys(email);
            FindByName("password").SendKeys(password);
            FindElementByxPath("//*[@id=\"keepsign\"]").Click();
            FindElementByxPath("//*[@id=\"signin\"]/div[3]/div[2]/button").Click();
            string actualUrl = driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl, "Login Success");
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
        public IAlert WaitUntil_AlertIsPresent(int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.AlertIsPresent());
        }
        public IWebElement WaitUntil_ElementExists(By by, int timeoutInSeconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementExists(by));
        }
        public IWebElement WaitUntil_ElementIsVisible(By by, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }
        public bool WaitUntil_ElementSelectionStateToBe(By by, bool selected, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementSelectionStateToBe(by, selected));
        }
        public bool WaitUntil_ElementSelectionStateToBe(IWebElement element, bool expectedState, int timeoutInSeconds = 90)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementSelectionStateToBe(element, expectedState));
        }
        public IWebElement WaitUntil_ElementToBeClickable(IWebElement element, int timeoutInSeconds = 90)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
        public IWebElement WaitUntil_ElementToBeClickable(By by, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
        public bool WaitUntil_InvisibilityOfElementLocated(By by, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }
        public bool WaitUntil_InvisibilityOfElementWithText(By by, string text, int timeoutInSeconds = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.InvisibilityOfElementWithText(by, text));
        }
        public bool WaitUntil_StalenessOf(IWebElement element, int timeoutInSeconds = 90)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.StalenessOf(element));
        }
        public bool WaitUntil_TextToBePresentInElement(IWebElement element, string str, int timeoutInSeconds = 90)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
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

        public IWebElement FindByName(string name)
        {
            return driver.FindElement(By.Name(name));
        }

        public Actions action(string keyAction)
        {
            Actions act = new Actions(driver);
            act.SendKeys(keyAction).Build().Perform();
            return act;
        }

        //Using click Action Selenium
        public Actions mouseAction(IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Click().Build().Perform();
            return actions;
        }

        //using javascript click
        public IJavaScriptExecutor clickElement(IWebElement element)
        {
            string javascript = "arguments[0].click()";
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript(javascript, element);
            Thread.Sleep(2000);
            return jsExecutor;
        }

        //Ghi log file
        //Declaration of the file stream and format 
        private static string _logFile = string.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        public static StreamWriter stream = null;

        //Create a file that will be used to store the log information
        public static void CreateLogFile()
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
        public static void WriteToFile(string Message)
        {
            stream.Write("{0} {1}\t", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            stream.Write("\\T{0}", Message);
            stream.Flush();
        }
    }

}


    public class FileChecker
    {
        IExtensionNanager objmanager = null;
        //Default constructor
        public FileChecker()
        {
            objmanager = new ExtensionManager();
        }
        //parameterized constructor
        public FileChecker(IExtensionNanager tmpManager)
        {
            objmanager = tmpManager;
        }

        public Boolean CheckFile(String FileName)
        {
            return objmanager.CheckExtension(FileName);
        }
    }
}
