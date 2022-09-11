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
        public IWebDriver OpenBrowser(string url)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            return driver;
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
        //public ChromeOptions DisableChorme()
        //{
        //    ChromeOptions chromeOptions = new ChromeOptions();
        //    chromeOptions.AddArguments("--disable-extensions"); // to disable extension  //*[@id="navbarButtonsExample"]/div/ul/li[3]/div
        //    chromeOptions.AddArguments("--disable-notifications"); // to disable notification
        //    chromeOptions.AddArguments("--disable-application-cache"); // to disable cache
        //    return chromeOptions;
        //}
        public IWebElement FindElementByxPath(string xPath)
        {
            return driver.FindElement(By.XPath(xPath));
        }

        public IWebElement FindById(string id)
        {
            var eleemnt = driver.FindElement(By.Id(id));
            awaiting(10);
            return eleemnt;
        }

        public IWebElement FindByName(string name)
        {
            var eleemnt = driver.FindElement(By.Name(name));
            awaiting(10);
            return eleemnt;
        }

        public Actions action(string keyAction) 
        {
            Actions act = new Actions(driver);
            act.SendKeys(keyAction).Build().Perform();
            return act;
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
