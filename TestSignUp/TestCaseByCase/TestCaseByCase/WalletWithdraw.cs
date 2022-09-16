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
    public class WalletWithdraw : WebBrowser
    {
        [TestMethod]
        public void Withdraw_Happy_Case()
        {
            var email = "nguyenvanquang2k1.00@gmail.com";
            var password = "123456Aa@";
            var search = "ETH";
            var amount = "0.01";
            var address = "0x828B4f6Ba4E172D003811b14b2625e24DFff3bb6";
            var actualMsg = "0.01 ETH";

            TestWithdrawWallet(email, password, search, address, amount, actualMsg);
        }

        [TestCategory("Core Function")]
        public void TestWithdrawWallet(string email, string password, string search, string address, string amount, string actualMsg)
        {
            OpenBrowser();
            Login(email, password);
            FindById("search-coin-funding").SendKeys(search);
            Thread.Sleep(2000);
            action(Keys.Enter);
            Thread.Sleep(1000);
            FindElementByxPath("//a[@href='/user/withdraw?symbol=ETH']").Click();
            Thread.Sleep(2000);
            FindById("address").SendKeys(address);
            Thread.Sleep(1000);
            FindById("currentNetworks").Click();
            Thread.Sleep(1000);
            FindByClassName("text-network").Click();
            Thread.Sleep(1000);
            FindById("amount").SendKeys(amount);
            Thread.Sleep(2000);
            FindElementByxPath("//input[@value='Withdraw']").Click();
            Thread.Sleep(1000);
            FindElementByxPath("//a[normalize-space()='Confirm']").Click();
            Thread.Sleep(1000);
            string expectedMsg = FindElementByxPath("//p[@class='text-wrap fw-normal text-break'][contains(text(),'0.01')]").Text.ToString();
            SignUpAsserMessage(actualMsg, expectedMsg);
            Thread.Sleep(2000);
            driver.Quit();
        }

        [TestCategory("Core Function")]
        public void TestWithdrawConfirmOrder(string code, string authGGCode, string actualMsg)
        {
            FindById("verify_code_send_mail").SendKeys(code);
            Thread.Sleep(60000);
            FindById("getcodesendmail").Click();
            Thread.Sleep(1000);
            FindById("verify_code_2fa").SendKeys(authGGCode);
            Thread.Sleep(2000);
            FindById("btnSubmit").Click();
            Thread.Sleep(1000);

            string expectedMsg = FindElementByxPath("//span[@value='1'][normalize-space()='Ethereum (ERC20)']").Text.ToString();
            SignUpAsserMessage(actualMsg, expectedMsg);

            Thread.Sleep(2000);
            driver.Quit();
        }
    }
}
