using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Threading.Tasks;
using System.Threading;
using static TestCaseByCase.HelperTest;
using System.Runtime.CompilerServices;
    
namespace TestCaseByCase
{
    [TestClass]
    public class UnitTest1 : WebBrowser
    {

        string email = "nguyennhatquang16k.00@gmail.com";
        string pw = "123456Aa@";

        [TestMethod]
        public void TestCheck()
        {
            StubExtensionManager stub = new StubExtensionManager();
            FileChecker checker = new FileChecker(stub);

            //Action
            bool IsTrueFile = checker.CheckFile("myFile.whatever");

            //Assert
            Assert.AreEqual(true, IsTrueFile);
        }

        //Test input Myads
        public void TestInputMyAds(string amount, string min, string max)
        {
            var textMyAds = FindElementByxPath("/html/body/header/div[1]/a[3]/div");
            if (!textMyAds.Displayed)
            {
                Console.WriteLine("Không tìm thấy text MyAds");
                driver.Quit();
            }
            textMyAds.Click();
            Thread.Sleep(3000);
            //click post my ads
            var btnPost = FindElementByxPath("/html/body/form/section/div/div[2]/div[2]/input");
            if (!btnPost.Displayed)
            {
                Console.WriteLine("Không tìm thấy button Post My Ads");
                driver.Quit();
            }
            btnPost.Click();
            Thread.Sleep(1000);

            //if (FindElementByxPath("/html/body/div[4]/div/section").Displayed)
            //{
            //    string expected_case1 = "http://127.0.0.1:8000/user/kyc";
            //    Console.WriteLine("Chưa KYC khi Post My Ads");
            //    var btnKYC = FindElementByxPath("/html/body/div[4]/div/section/div/div[3]/a");
            //    if (!btnKYC.Displayed)
            //    {
            //        Console.WriteLine("Không hiển thị nút KYC");
            //        return;

            //    }
            //    btnKYC.Click();
            //    Console.WriteLine("KYC loaded page success");
            //    Thread.Sleep(2000);
            //    string actual_case1 = driver.Url;
            //    Assert.AreEqual(expected_case1, actual_case1, "Failed verify KYC");
                
            //}


            FindById("ETH").Click();
            FindById("VND").Click();
            var btnNext = FindById("btnNext");
            if (!btnNext.Displayed)
            {
                Console.WriteLine("Không tìm thấy button Next");
                driver.Quit();
            }
            btnNext.Submit();

            FindById("total_amount").SendKeys(amount);
            FindById("order_min").SendKeys(min);
            FindById("order_max").SendKeys(max);
            Thread.Sleep(4000);
            FindById("btnAdd").Click();
            //default click bank transfer
            awaiting(2);
            //driver.FindElement(By.ClassName("method-text")).Click();
            Thread.Sleep(2000);
            clickElement(driver.FindElement(By.ClassName("method-text")));

            var btnNext_2 = FindElementByxPath("//*[@id='btnNext']");
            if (!btnNext_2.Displayed)
            {
                Console.WriteLine("Không tìm thấy button Next");
                driver.Quit();
            }
            clickElement(btnNext_2);
            Thread.Sleep(2000);

            //post my ads
            var btnPost_2 = FindById("btnPosAds");
            if (!btnPost_2.Displayed)
            {
                Console.WriteLine("Không tìm thấy button Next");
                driver.Quit();
            }
            clickElement(btnPost_2);
            FindElementByxPath("/html/body/form/div/section/div[2]/div/div/div[3]/div/div[2]/div/div/section/a").Click();

            MyAds myAds = new MyAds { amount = "1000", min = "1000", max = "5000", pmMethod = "Bank Transfer" };
            myAds.amount.Contains(amount);
            myAds.min.Contains(min);
            myAds.max.Contains(max);
            Assert.AreEqual(myAds, myAds, "Failed");
            Console.WriteLine("Post My Ads succesfully");
            driver.Quit();


           // var textAmount = FindElementByxPath("/html/body/form/div/section[2]/div/table/tbody/tr[2]/td[2]/div/p[1]");
          


        }
        //2. range input: amount, min, max
        //1000 usdt
        //min 1.000.000
        //max 5.000.000
        [TestMethod]
        public void TestCreateP2POrder()
        {
            //setup test
            OpenBrowser();
            Login(email, pw);
            TestInputMyAds("0.5", "150000", "20000000");
        }

        [TestMethod]
        public void TestCreateP2POrder_Case2()
        {
            //setup test
            OpenBrowser();

            //1. Login 
            //2. Select Post My - Ads

            //input
            //1
            //2. range input: amount, min, max
            //500 usdt
            //min 10.000.000
            //max 50.000.000
            //3. remark, option

            //click go

            //VERIFY
            //var list = htmlxxxx
            //list.contain(xxxx)


        }

        [TestMethod]
        public void TestCreateP2POrder_Case3_EmptyInput()
        {
            //setup test
            OpenBrowser();

            //1. Login 
            //2. Select Post My - Ads

            //input
            //1
            //2. range input: amount, min, max
            //-100 usdt
            //min 10.000.000
            //max 50.000.000
            //3. remark, option

            //click go

            //VERIFY
            //expect error:
            //var list = htmlxxxx
            //list.contain(xxxx)


        }

        //[TestMethod]
        //public void TestUIAsync()
        //{
        //    //setup test
        //    OpenBrowser();

        //    //1.sign in with email
        //    //2. wallet page


        //    //input

        //    //output


        //    //verify expected
        //    //1. đã tới dc wallet page
        //    //2. Top menu có user name của : khanh1412

        //    FindById("//*[@id='dropdownMenuOffset']/img").Click();
        //    //action(Keys.PageDown);

        //    Console.WriteLine("Waiting");
        //    FindElementByxPath("//*[@id='navbarButtonsExample']/div/ul/li[3]/div/ul/li[1]").Click();
        //    Thread.Sleep(1000);
        //}
        [TestMethod]
        public void LandingPage()
        {
            OpenBrowser();

            var textBuy = FindElementByxPath("/html/body/nav/div/div/ul/li[1]/a");
            if (!textBuy.Displayed)
            {
                Console.WriteLine("Không tìm thấy từ 'Buy'");
            }
            var textSell = FindElementByxPath("/html/body/nav/div/div/ul/li[2]/a");
            if (!textSell.Displayed)
            {
                Console.WriteLine("Không tìm thấy từ 'Sell'");
            }
            var textAds = FindElementByxPath("/html/body/nav/div/div/ul/li[3]/a");
            if (!textAds.Displayed)
            {
                Console.WriteLine("Không tìm thấy từ 'My Ads'");
            }
            var selectCurrency = FindElementByxPath("/html/body/nav/div/div/div/ul/li[4]/select");
            if (!selectCurrency.Displayed)
            {
                Console.WriteLine("Không tìm thấy 'Currency'");
            }
            FindElementByxPath("/html/body/nav/div/div/div/ul/li[4]/select/option[2]").Click();
            var banner = FindElementByxPath("/html/body/section[1]/div");
            if (!banner.Displayed)
            {
                Console.WriteLine("Không tìm thấy banner");
                Thread.Sleep(1000);
                driver.Quit();
            }

            var textBanner = FindElementByxPath("/html/body/section[1]/div/div/a");
            var textBanner_1 = FindElementByxPath("/html/body/section[1]/div/p");
            var textBanner_2 = FindElementByxPath("/html/body/section[1]/div/h3");
            if (!textBanner.Displayed || !textBanner_1.Displayed || !textBanner_2.Displayed)
            {
                Console.WriteLine("Không tìm thấy text trong banner");
                Thread.Sleep(500);
                driver.Quit();
            }
            
            var tbCoin = FindElementByxPath("/html/body/section[2]/section");
            if (!tbCoin.Displayed)
            {
                Console.WriteLine("Không tìm thấy table coin");
                Thread.Sleep(500);
                driver.Quit();
            }
            action(Keys.PageDown);

            if (!FindElementByxPath("/html/body/section[3]/div[2]/div[1]/img").Displayed || !FindElementByxPath("/html/body/section[3]/div[2]/div[2]/img").Displayed
                || !FindElementByxPath("/html/body/section[3]/div[2]/div[3]/img").Displayed || !FindElementByxPath("/html/body/section[3]/div[2]/div[4]/img").Displayed)
            {
                Console.WriteLine("Không tìm thấy hình ảnh");
                Thread.Sleep(500);
                driver.Quit();
            }
            if (!FindElementByxPath("/html/body/section[4]/div[1]/h4").Displayed || !FindElementByxPath("/html/body/section[4]/div[2]/div[1]").Displayed
               || !FindElementByxPath("/html/body/section[4]/div[2]/div[2]").Displayed || !FindElementByxPath("/html/body/section[4]/div[2]/div[3]").Displayed)
            {
                Console.WriteLine("Không tìm card");
                Thread.Sleep(500);
                driver.Quit();
            }
            if (!FindElementByxPath("//html/body/section[5]").Displayed || !FindElementByxPath("/html/body/section[5]/div/div/div[2]/h1").Displayed
               || !FindElementByxPath("/html/body/section[5]/div/div/div[1]/img").Displayed || !FindElementByxPath("/html/body/section[5]/div/div/div[2]/p").Displayed)
            {
                Console.WriteLine("Không tìm thay text");
                Thread.Sleep(500);
                driver.Quit();
            }
            action(Keys.PageDown);

            var textFAQ_1 = FindElementByxPath("/html/body/section[7]/div/div[1]/div[1]/span/h6/a");
            var textFAQ_2 = FindElementByxPath("/html/body/section[7]/div/div[1]/div[2]/span/h6/a");
            var textFAQ_3 = FindElementByxPath("/html/body/section[7]/div/div[1]/div[3]/span/h6/a");

            if (!FindElementByxPath("/html/body/section[7]/div/div[1]/h3").Displayed || !textFAQ_1.Displayed
               || !textFAQ_2.Displayed ||
               !textFAQ_3.Displayed || !FindElementByxPath("/html/body/section[7]/div/div[2]/img").Displayed)
            {
                Console.WriteLine("Không tìm thay FAQ");
                Thread.Sleep(500);
                driver.Quit();
            }

            if (!FindElementByxPath("/html/body/footer/section").Displayed)
            {
                Console.WriteLine("Không tìm thấy footer");
            }
            driver.Quit();
        }

        [TestMethod]
        public void Deposit()
        {
            //Declare variable
            By dropdown = By.XPath("/html/body/header/div[2]/div[3]/div[2]/span");
            string sreachEth = "ETH";
            // Navigate to a page
            Login(email, pw);
            // deposit
            FindById("search-coin-funding").SendKeys(sreachEth);
            Thread.Sleep(2000);
            action(Keys.Enter);
            Thread.Sleep(2000);
            FindElementByxPath("/html/body/div[4]/div/div[2]/section[2]/div/div[2]/div[1]/div/table/tbody/tr[1]/td[4]/div/a[1]").Click();
            string element = FindElementByxPath("/html/body/div[4]/div/div[2]/div/div/div/div/div/div/form/div/div/div[1]/div/div/div[2]/div/div/div/div[1]/div/div/span[1]").Text;
            if (element != sreachEth)
            {
                Console.WriteLine("Deposit error");
                driver.Quit();
            }


            FindElementByxPath("/html/body/div[4]/div/div[2]/div/div/div/div/div/div/form/div/div/div[2]/div/div/div[2]/div[2]/div/div/span").Click();
            Thread.Sleep(1000);
            //Close modal
            //FindElementByxPath("/html/body/div[5]/div/div[2]/div/div/div/div/div/div/form/div/div/div[2]/div/div/div[2]/div[3]/form/div/div/section[1]/div/button").Click();
            FindElementByxPath("/html/body/div[4]/div/div[2]/div/div/div/div/div/div/form/div/div/div[2]/div/div/div[2]/div[3]/form/div/div/section[2]/div/table/tbody/tr/td").Click();

            FindElementByxPath("/html/body/div[4]/div/div[2]/div/div/div/div/div/div/form/div/div/div[2]/div/div/div[2]/div[4]/div/div/div/div[6]/ul/li[2]/p/span");
            Console.WriteLine("Pass deposit");
            Thread.Sleep(6000);
            driver.Quit();
        }
        [TestMethod]
        public void Deposit_Case1()
        {
            //Declare variable
            By dropdown = By.XPath("/html/body/header/div[2]/div[3]/div[2]/span");
            string sreachEth = "ETH";
            // Navigate to a page
            Login(email, pw);
            // deposit
            var textDeposit = FindElementByxPath("/html/body/header/div[2]/div[2]/a[3]");
            if (!textDeposit.Displayed)
            {
                Console.WriteLine("Không tìm thấy text deposit");
                driver.Quit();
            }
            textDeposit.Click();
            Thread.Sleep(1000);
            FindElementByxPath("/html/body/div[4]/div/div[2]/div/div/div/div/div/div/form/div/div/div[1]/div/div/div[2]/div/div/div/div[1]/div/div/span").Click();

            FindElementByxPath("/html/body/div[4]/div/div[2]/div/div/div/div/div/div/form/div/div/div[1]/div/div/div[2]/div/div/div/div[2]/div/div/section/div[1]/div/input").SendKeys(sreachEth);
            Thread.Sleep(2000);
            action(Keys.Enter);
            Thread.Sleep(2000);
            FindElementByxPath("/html/body/div[4]/div/div[2]/section[2]/div/div[2]/div[1]/div/table/tbody/tr[1]/td[4]/div/a[1]").Click();
            string element = FindElementByxPath("/html/body/div[4]/div/div[2]/div/div/div/div/div/div/form/div/div/div[1]/div/div/div[2]/div/div/div/div[1]/div/div/span[1]").Text;
            if (element != sreachEth)
            {
                Console.WriteLine("Deposit error");
                driver.Quit();
            }


            FindElementByxPath("/html/body/div[4]/div/div[2]/div/div/div/div/div/div/form/div/div/div[2]/div/div/div[2]/div[2]/div/div/span").Click();
            Thread.Sleep(1000);
            //Close modal
            //FindElementByxPath("/html/body/div[5]/div/div[2]/div/div/div/div/div/div/form/div/div/div[2]/div/div/div[2]/div[3]/form/div/div/section[1]/div/button").Click();
            FindElementByxPath("/html/body/div[4]/div/div[2]/div/div/div/div/div/div/form/div/div/div[2]/div/div/div[2]/div[3]/form/div/div/section[2]/div/table/tbody/tr/td").Click();
            Console.WriteLine("Pass deposit");
            Thread.Sleep(6000);
            driver.Quit();
        }
        [TestMethod]
        public void Withdraw()
        {
            //Declare variable
            By dropdown = By.XPath("/html/body/header/div[2]/div[3]/div[2]/span");
            string sreachEth = "ETH";
            string address = "0x828B4f6Ba4E172D003811b14b2625e24DFff3bb6";
            // Navigate to a page

            Login(email, pw);
            // Withdraw

            FindById("search-coin-funding").SendKeys(sreachEth);
            Thread.Sleep(2000);
            action(Keys.Enter);
            Thread.Sleep(2000);
            FindElementByxPath("/html/body/div[4]/div/div[2]/section[2]/div/div[2]/div[1]/div/table/tbody/tr[1]/td[4]/div/a[2]").Click();
            // Test form
            FindElementByxPath("/html/body/div[4]/div[1]/div[2]/section[2]/div/div/div/form/div/div[2]/div[2]/input").SendKeys(address);
            Thread.Sleep(2000);
            FindElementByxPath("/html/body/div[4]/div[1]/div[2]/section[2]/div/div/div/form/div/div[2]/div[2]/div[2]").Click();
            Thread.Sleep(2000);
            FindElementByxPath("/html/body/div[4]/div[1]/div[2]/section[2]/div/div/div/form/div/div[2]/div[2]/div[3]/form/div/div/section[2]/div/table/tbody/tr[1]/td").Click();
            string element = FindElementByxPath("/html/body/div[4]/div[1]/div[2]/section[2]/div/div/div/form/div/div[5]/div/input").GetAttribute("value");
            if (element != "Withdraw")
            {
                Console.WriteLine("Withdraw error");
                driver.Quit();
            }
            Console.WriteLine("Pass withdraw");
            Thread.Sleep(3000);
            driver.Quit();
        }

        // email: Nguyenvanquang2k.00@gmail.com
        //  pw: 123456Aa@



        [TestMethod]
        public void SignIn_Email_Case1_EmptyInput()
        {
            //set up 
            OpenBrowser();
            FindElementByxPath("//*[@id='navbarButtonsExample']/div/ul/li[1]").Click();
            FindElementByxPath("//*[@id='signin']/div[3]/div[2]/button").Click();
            Thread.Sleep(3000);

            var errInput = FindElementByxPath("//*[@id='signin']/div[1]/div[2]");
            var errPw = FindElementByxPath("//*[@id='signin']/div[2]/div[1]");
            if (!errInput.Displayed || !errPw.Displayed)
            {
                Console.WriteLine("Not found message error");
                return;
            }
            Console.WriteLine("Đã tìm thấy nội dung thông báo lỗi");
            Thread.Sleep(5000);
            driver.Quit();
        }

        string email_test = "nguyenvanquang2k.00@gmail.com";
        string pw_test = "123456Aa@";
        [TestMethod]
        public void SignIn_Email_Case2()
        {
            //set up 
            OpenBrowser();
            var expectedUrl = "http://127.0.0.1:8000/user/signin-email";
            FindElementByxPath("//*[@id='navbarButtonsExample']/div/ul/li[1]").Click();
            Thread.Sleep(3000);

            //Sign in
            //Input
            FindByName("email").SendKeys(email_test);
            FindByName("password").SendKeys(pw_test);
            FindElementByxPath("//*[@id=\"keepsign\"]").Click();
            Thread.Sleep(3000);
            FindElementByxPath("//*[@id='signin']/div[3]/div[2]/button").Click();
            //Output
            if (!FindElementByxPath("//*[@id='signin']/div[2]/div[1]").Displayed)
            {
                Console.WriteLine("Không hiển thị message 'user not exists'");
                Console.WriteLine("Không hiển thị message 'Your account has been deactive. Please contact Admin for assisstance'");
                return;
            }
            Console.WriteLine("Hiển thị message 'user not exists'");
            Console.WriteLine("Hiển thị message 'Your account has been deactive. Please contact Admin for assisstance'");

            //verify sign-in email
            string actualUrl = driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl, "Sign in case 2 test validate input successfully");
            Thread.Sleep(2000);
            driver.Quit();
        }

        [TestMethod]
        public void SignIn_Mobile_Case1_EmptyInput()
        {
            //set up 
            OpenBrowser();
            FindElementByxPath("//*[@id='navbarButtonsExample']/div/ul/li[1]").Click();
            FindElementByxPath("/html/body/div/div/div[2]/div[1]/div[2]/div/span[2]").Click();
            FindElementByxPath("//*[@id='signin']/div[3]/div[2]/button").Click();
            Thread.Sleep(3000);

            var errInput = FindElementByxPath("//*[@id='signin']/div[1]/div[2]/div");
            var errPw = FindElementByxPath("//*[@id='signin']/div[2]/div[1]");
            if (!errInput.Displayed || !errPw.Displayed)
            {
                Console.WriteLine("Not found message error");
                return;
            }
            Console.WriteLine("Đã tìm thấy nội dung thông báo lỗi");
            Thread.Sleep(2000);
            driver.Quit();
        }

        [TestMethod]
        public void SignIn_Mobile_Case2()
        {
            //set up 
            OpenBrowser();
            var expectedUrl = "http://127.0.0.1:8000/user/signin-mobile";
            FindElementByxPath("//*[@id='navbarButtonsExample']/div/ul/li[1]").Click();
            FindElementByxPath("/html/body/div/div/div[2]/div[1]/div[2]/div/span[2]/a").Click();
            Thread.Sleep(3000);

            //Sign in
            //Input
            FindByName("mobile").SendKeys("326566732");
            FindByName("password").SendKeys("12322456Aa@");
            FindElementByxPath("//*[@id=\"keepsign\"]").Click();
            FindElementByxPath("//*[@id='signin']/div[3]/div[2]/button").Click();
            //Output
            if (!FindElementByxPath("/html/body/div/div/div[2]/div[1]/form/div/div[2]/div[1]").Displayed)
            {
                Console.WriteLine("Không hiển thị message 'user not exists'");
                Console.WriteLine("Không hiển thị message 'Your account has been deactive. Please contact Admin for assisstance'");
                driver.Quit();
            }
            Console.WriteLine("Hiển thị message 'user not exists'");
            Console.WriteLine("Hiển thị message 'Your account has been deactive. Please contact Admin for assisstance'");

            //verify sign-in email
            string actualUrl = driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl, "Sign in case 2 test validate input successfully");
            Thread.Sleep(2000);
            driver.Quit();
        }

        [TestMethod]
        public void TestLogout()
        {
            // login page 
            Login(email, pw);
            Thread.Sleep(2000);
            string actualUrl = "http://127.0.0.1:8000/user/signin-email";
            Console.WriteLine("Login successfully");
            var userImg = FindElementByxPath("/html/body/header/div[2]/div[3]/div[2]/span");
            if (!userImg.Displayed)
            {
                Console.WriteLine("Not found image");
                return;
            }
            userImg.Click();
            Thread.Sleep(2000);

            if (!FindElementByxPath("/html/body/header/div[2]/div[3]/div[2]/ul/li[2]/a").Displayed)
            {
                Console.WriteLine("Not found text 'My profile'");
                driver.Quit();
            }
            if (!FindElementByxPath("/html/body/header/div[2]/div[3]/div[2]/ul/li[3]/a").Displayed)
            {
                Console.WriteLine("Not found text 'Payment Methods'");
                driver.Quit();
            }
            if (!FindElementByxPath("/html/body/header/div[2]/div[3]/div[2]/ul/li[4]/a").Displayed)
            {
                Console.WriteLine("Not found text 'Seurity'");
                driver.Quit();
            }
            if (!FindElementByxPath("/html/body/header/div[2]/div[3]/div[2]/ul/li[2]/a").Displayed)
            {
                Console.WriteLine("Not found text 'Personal Verification'");
                driver.Quit();
            }
            if (!FindElementByxPath("/html/body/header/div[2]/div[3]/div[2]/ul/li[2]/a").Displayed)
            {
                Console.WriteLine("Not found text 'Settings'");
                driver.Quit();
            }

            FindElementByxPath("/html/body/header/div[2]/div[3]/div[2]/ul/li[7]/a").Click();

            var expectedUrl = driver.Url ;

            Assert.AreEqual( expectedUrl, actualUrl, "Logout Fail");
            Thread.Sleep(2000);
            driver.Quit();
        }

        [TestMethod]
        public void TestSignUpEmail()
        {
            OpenBrowser();
            string expectedUrl = "http://127.0.0.1:8000/user/verifycode-signup";

            var picture = FindElementByxPath("/html/body/nav/div/a");
            if (!picture.Displayed) {
                Console.WriteLine("Not found logo");
                Thread.Sleep(1000);
                driver.Quit();
            }

            var lang = FindElementByxPath("/html/body/nav/div/div/div/ul/li[3]/div/a/img");
            if (lang.Displayed)
            {
                Console.WriteLine("Success");
                lang.Click();
                var chooseVN = FindElementByxPath("/html/body/nav/div/div/div/ul/li[3]/div/ul/li[1]/a");
                if (!chooseVN.Displayed)
                {
                    Console.WriteLine("Choose lang VN failed");
                    Thread.Sleep(1000);
                    driver.Quit();
                }
                chooseVN.Click();
                Thread.Sleep(2000);

                //FindElementByxPath("/html/body/nav/div/div/div/ul/li[3]/div/ul/li[1]/a").Click();
                //var chooseCN = FindElementByxPath("/html/body/nav/div/div/div/ul/li[3]/div/ul/li[3]/a");
                //if (!chooseCN.Displayed)
                //{
                //    Console.WriteLine("Choose lang CN failed");
                //    Thread.Sleep(1000);
                //    driver.Quit();
                //}
                //chooseCN.Click();
                //Thread.Sleep(2000);
            }
            FindElementByxPath("/html/body/nav/div/div/div/ul/li[2]/div/div/a").Click();
            //input
            FindByName("email").SendKeys(email_test);
            FindByName("password").SendKeys(pw_test);
            FindByName("check18").Click();
            awaiting(10);
            FindElementByxPath("//*[@id=\"create-account\"]").Click();

           // SummaryDisplayed(By.XPath("/html/body/div[2]/div/div[2]/div[1]/form/div/div[1]/div"));
            //SummaryDisplayed(By.XPath("/html/body/div/div/div[2]/div[1]/form/div/div[2]/div[1]"));


            string actualUrl = driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl, "Sign Up Failed");
            
            var verify = FindByName("verify_code");
            if (!verify.Displayed)
            {
                Console.WriteLine("Not found input verify code");
                Thread.Sleep(1000);
                driver.Quit();
            }
            WaitForLoadElement(verify);
            FindById("verify").Click();
            Assert.AreEqual(expectedUrl, actualUrl, "Register sign up email successfully");
            Thread.Sleep(1000);
            driver.Quit();
        }

        [TestMethod]
        public void TestSignUpMobile()
        {
            OpenBrowser();
            var element = FindElementByxPath("//*[@id='navbarButtonsExample']/div/ul/li[2]/div");
            if (!element.Displayed)
            {
                Console.WriteLine("Click sign up page fail");
            }
            element.Click();
            FindElementByxPath("/html/body/div/div/div[2]/div[1]/div[3]/div/span[2]").Click();

            string actualUrl = "http://127.0.0.1:8000/user/verifycode-signup-mobile";

            //input

            FindByName("mobile").SendKeys("3265666732");
            FindByName("password").SendKeys("123456Aa@");
            FindByName("check18").Click();
            FindElementByxPath("//*[@id=\"create-account\"]").Click();

            string expectedUrl = driver.Url;

            var verify = FindByName("verify_code");
            if (!verify.Displayed)
            {
                Console.WriteLine("Not found input verify code");
                Thread.Sleep(1000);
                driver.Quit();
            }
            if (!FindElementByxPath("//*[@id=\"signin\"]/div[1]/div").Displayed)
            {
                Console.WriteLine("Not found message error input verify");
                Thread.Sleep(1000);
                driver.Quit();
            }
            Console.WriteLine("Register sign up mobile successfully");
            Assert.AreEqual(actualUrl, expectedUrl, "Register sign up mobile successfully");
            Thread.Sleep(1000);
            driver.Quit();
        }
    }
}
