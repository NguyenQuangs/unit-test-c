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
    public class TestUI :WebBrowser
    {
        [TestMethod]
        public void Click_NavBar()
        {
            var expected = "Payme- Signin Email";
            var expectedSignup = "Payme- Signup Email";
            var expectedCheckLang = "Nền tảng giao dịch P2P an toàn nhất thế giới";
            var expectedCheckLangEN = "The world's most secure P2P trading platform";

            var expectedCheckLangCN = "全球最安全的P2P交易平台";
            OpenBrowser();

            FindLinkText("Buy").Click();
            string actualBuy = driver.Title;
            SignUpAssert(actualBuy, expected);
            Thread.Sleep(10000);
            driver.Navigate().Back();

            FindLinkText("Sell").Click();
            string actualSell = driver.Title;
            SignUpAssert(actualSell, expected);
            Thread.Sleep(10000);
            driver.Navigate().Back();

            FindElementByxPath("(//a[contains(@class,'')][normalize-space()='My Ads'])[1]").Click();
            string actualMyAds = driver.Title;
            SignUpAssert(actualMyAds, expected);
            Thread.Sleep(10000);
            driver.Navigate().Back();

            FindElementByxPath("//a[normalize-space()='Sign In']").Click();
            string actualSignIn = driver.Title;
            SignUpAssert(actualSignIn, expected);
            Thread.Sleep(10000);
            driver.Navigate().Back();

            FindLinkText("Sign Up").Click();
            string actualSignUp = driver.Title;
            SignUpAssert(actualSignUp, expectedSignup);
            Thread.Sleep(10000);
            driver.Navigate().Back();

            FindElementByxPath("//a[@id='dropdownMenuOffset']//img").Click();
            Thread.Sleep(1000);
            FindElementByxPath("//li[1]//a[1]//img[1]").Click();
            Thread.Sleep(1000);
            string actualLang = FindByCssSelector("div[class='pm-banner-text'] h3").Text;
            SignUpAssert(actualLang, expectedCheckLang);
            Thread.Sleep(10000);

            FindElementByxPath("//a[@id='dropdownMenuOffset']//img").Click();
            Thread.Sleep(1000);
            FindElementByxPath("//span[contains(text(),'中國人')]").Click();
            Thread.Sleep(1000);
            string actualLangCN = FindByCssSelector("div[class='pm-banner-text'] h3").Text;
            SignUpAssert(actualLangCN, expectedCheckLangCN);
            Thread.Sleep(10000);

            FindElementByxPath("//a[@id='dropdownMenuOffset']//img").Click();
            Thread.Sleep(1000);
            FindElementByxPath("(//span[contains(@class,'px-3')][normalize-space()='English'])[1]").Click();
            Thread.Sleep(1000);
            string actualLangEN = FindByCssSelector("div[class='pm-banner-text'] h3").Text;
            SignUpAssert(actualLangEN, expectedCheckLangEN);
            Thread.Sleep(10000);
            driver.Navigate().Refresh();

            FindLinkText("Register Now").Click();
            Thread.Sleep(1000);
            SignUpAssert(actualSignUp, expectedSignup);
            Thread.Sleep(10000);

            // 
            driver.Quit();
        }

        public void TestUILandingPage(string ac)
        {
            driver.Quit();
        }


        [TestMethod]
        public void Click_LinkHrefFooter()
        {
            OpenBrowser();
            string expectedF = "Payme- FAQ";
            mouseAction(FindElementByxPath("//h3[normalize-space()='FAQS']"));
            Thread.Sleep(10000);
            Thread.Sleep(1000);
            FindElementByxPath("//a[normalize-space()='Glossary of Payme trading terms']").Click();
            action(Keys.PageDown);
            string actualFAQ1 = driver.Title;

            Thread.Sleep(10000);
            SignUpAssert(actualFAQ1, expectedF);
            action(Keys.PageDown);
            Thread.Sleep(10000);
            driver.Navigate().Back();


            mouseAction(FindElementByxPath("//h3[normalize-space()='FAQS']"));
            Thread.Sleep(1000);
            FindElementByxPath("//a[normalize-space()='Payme P2P Trading Guidelines']").Click();
            action(Keys.PageDown);
            string actualFAQ2 = driver.Title;

            Thread.Sleep(10000);
            SignUpAssert(actualFAQ2, expectedF);
            Thread.Sleep(10000);
            driver.Navigate().Back();

            mouseAction(FindElementByxPath("//h3[normalize-space()='FAQS']"));
            action(Keys.PageDown);
            Thread.Sleep(10000);
            Thread.Sleep(1000);
            FindElementByxPath("//a[normalize-space()='Payme trading FAQ']").Click();
            action(Keys.PageDown);
            string actualFAQ3 = driver.Title;

            Thread.Sleep(10000);
            SignUpAssert(actualFAQ3, expectedF);
            action(Keys.PageDown);
            Thread.Sleep(10000);
            driver.Navigate().Back();

            mouseAction(FindLinkText("Terms"));
            FindLinkText("Terms").Click();
            action(Keys.PageDown);
            Thread.Sleep(10000);
            string actualFAQ4 = driver.Title;

            SignUpAssert(actualFAQ4, expectedF);
            action(Keys.PageDown);
            Thread.Sleep(10000);
            driver.Navigate().Back();

            mouseAction(FindLinkText("Privacy"));
            FindLinkText("Privacy").Click();
            action(Keys.PageDown);
            Thread.Sleep(10000);
            string actualFAQ5 = driver.Title;

            SignUpAssert(actualFAQ5, expectedF);
            Thread.Sleep(10000);
            driver.Navigate().Back();

            mouseAction(FindLinkText("FAQS"));
            FindLinkText("FAQS").Click();
            action(Keys.PageDown);
            Thread.Sleep(10000);
            string actualFAQ6 = driver.Title;
            SignUpAssert(actualFAQ6, expectedF);
            action(Keys.PageDown);
            Thread.Sleep(10000);
            driver.Navigate().Back();

            mouseAction(FindLinkText("Announcement"));
            FindLinkText("Announcement").Click();

            action(Keys.PageDown);
            Thread.Sleep(10000);
            action(Keys.PageDown);
            string actualFAQ7 = driver.Title;
            SignUpAssert(actualFAQ7, expectedF);
            action(Keys.PageDown);
            Thread.Sleep(10000);

            driver.Quit();
        }
    }
}
