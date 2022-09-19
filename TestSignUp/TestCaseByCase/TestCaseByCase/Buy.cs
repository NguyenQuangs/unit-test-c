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
    public class Buy : WebBrowser
    {
        //[TestMethod]
        public void Buy_By_VN_Happy_Case()
        {
            var email = "nguyenvanquang2k.00@gmail.com";
            var password = "123456Aa@";
            var amount = "200000";
            var content_chat = "Chuyen tien roi nhe ban";
            OpenBrowser(urlProduction);
            Login(email, password);

            Thread.Sleep(1000);
            FindElementByxPath("//div[normalize-space()='Buy']").Click();
            FindById("dropdownFiat").Click();
            Thread.Sleep(1000);
            FindElementByxPath("//div[@id='drop-list-fiat']//li[@value='1']").Click();

            BuyP2PNotify(email, password, amount, content_chat);
        }

        [TestMethod]
        [TestCategory("Core Function")]
        public void BuyP2PNotify(string email, string password, string amount, string content_chat)
        {
            Thread.SpinWait(3000);
            FindByCssSelector(".ms-2.bg-gradient-yellow-order.white-space-nowrap").Click();
            Thread.Sleep(2000);
            FindElementByxPath("(//span[contains(text(),'ETH')])[2]").Click();
            Thread.Sleep(2000);
            FindById("input-amount").SendKeys(amount);
            Thread.Sleep(1000);
            FindElementByxPath("//form[@method='post']").Click();
            Thread.Sleep(10000);
            string expectedMsg = FindById("input-usdt").Text.ToString();
            Thread.Sleep(2000);
            FindById("buy-now").Click();
            Thread.Sleep(1000);
            FindById("tranferred-btn").Click();
            Thread.Sleep(1000);
            FindById("comfirm-buy").Click();
            Thread.Sleep(2000);
            string actualMsg = FindByCssSelector("p[class='fs-18 fw-600']").Text.ToString();
            // so sanh 
            //SignUpAsserMessage(actualMsg, expectedMsg);

            Thread.Sleep(1000);
            FindByClassName("chat-window-message").SendKeys(content_chat);
            string expectedChatMsg = FindByClassName("chat-window-message").Text.ToString();
            Thread.Sleep(500);
            FindElementByxPath("//span[normalize-space()='send']").Click();
            Thread.Sleep(8000);
            string actualChatMsg = FindElementByxPath("//p[@class='message-text']").Text;
            FindElementByxPath("//a[@href='/user/orders'][normalize-space()='P2P Orders']").Click();
            Thread.Sleep(10000);
            driver.Quit();
            //Failed
            //so sanh noi dung chat
            SignUpAsserMessage(actualChatMsg, expectedChatMsg);

        }

    }
}
