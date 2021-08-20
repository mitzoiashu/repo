using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProteinAutomationSolution.PageObjects;
using MyProteinAutomationSolution.PageObjects.InputData;
using MyProteinAutomationSolution.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace MyProteinAutomationSolution
{
    [TestClass]
    public class LoginTests
    {
        //declare IWebDriver instance
        private IWebDriver driver;
        //declare LoginPage class
        private LoginPage loginPage;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.myprotein.ro");
            var homePage = new HomePage(driver);
            WaitHelpers.WaitElementIsVisible(driver, homePage.Cookies);
            WaitHelpers.WaitElementToBeClickable(driver, homePage.Cookies);
            homePage.BtnCookie.Click();
            homePage.btnCont.Click();
        }
        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }

        [TestMethod]
        public void Should_login_with_valid_credentials()
        {
            var newLoginBO = new NewLoginBO();
            var homePage = loginPage.LoginApplication(newLoginBO);
            Thread.Sleep(2000);
            Assert.AreEqual(homePage.LblLogin.Text, newLoginBO.LblLogin);
        }

        //[TestMethod]
        //public void Should_fail_login_with_invalid_credentials()
        //{
        //    var homePage = loginPage.LoginApplication("tavi_mihail@yahoo.com", "teijtsokos");
        //    Assert.AreEqual(homePage.LblLoginFailed.Text, "Adresa de email sau parola sunt incorecte");
        //}

        //[TestMethod]
        //public void Should_open_browser()
        //{
        //    //open driver
        //    driver = new ChromeDriver();
        //    //maximize window
        //    driver.Manage().Window.Maximize();
        //    //acces URL of the system under test(SUT)
        //    driver.Navigate().GoToUrl("https://www.myprotein.ro");

        //    //Actions action = new Actions(driver);


        //    driver.FindElement(By.CssSelector("input[name=search]")).SendKeys("unt");
        //    driver.FindElement(By.CssSelector("button[class=headerSearch_button]")).Click();
        //    Thread.Sleep(2000);
        //}
    }
}
