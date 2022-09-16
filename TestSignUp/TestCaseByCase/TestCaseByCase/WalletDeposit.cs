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
    public class WalletDeposit: WebBrowser
    {
        [TestMethod]
        [TestCategory("Deposit")]
        public void Deposit_Happy_Case()
        {
            var email = "nguyenvanquang2k1.00@gmail.com";
            var password = "123456Aa@";
            var search = "ETH";
            var actualMsg = "Ethereum (ERC20)";
            TestDepositWallet(email, password, search, actualMsg);
        }

        [TestCategory("Core Function")]
        public void TestDepositWallet(string email, string password, string search, string actualMsg)
        {
            OpenBrowser();
            Login(email, password);
            //Declare variable
            By dropdown = By.XPath("/html/body/header/div[2]/div[3]/div[2]/span");
            // Navigate to a page
            // deposit
            FindById("search-coin-funding").SendKeys(search);
            Thread.Sleep(2000);
            action(Keys.Enter);
            Thread.Sleep(1000);
            FindElementByxPath("//a[@href='/user/deposit?symbol=ETH']").Click();
            Thread.Sleep(6000);

            FindById("currentNetworks").Click();
            Thread.Sleep(1000);
            FindByClassName("text-network").Click();
            Thread.Sleep(1000);
            string expectedMsg = FindElementByxPath("//span[@value='1'][normalize-space()='Ethereum (ERC20)']").Text.ToString();
            SignUpAsserMessage(actualMsg, expectedMsg);

            Thread.Sleep(2000);
            driver.Quit();
        }
    }
}
