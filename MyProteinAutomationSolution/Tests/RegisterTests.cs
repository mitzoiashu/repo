using System;
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
    public class RegisterTests
    {
        private IWebDriver driver;
        //private LoginPage loginPage;
        private RegisterPage registerPage;

        [TestInitialize]
        public void RegisterSetup()
        {
            driver = new ChromeDriver();
            //loginPage = new LoginPage(driver);
            registerPage = new RegisterPage(driver);

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.myprotein.ro");
            var homePage = new HomePage(driver);
            WaitHelpers.WaitElementIsVisible(driver, homePage.Cookies);
            WaitHelpers.WaitElementToBeClickable(driver, homePage.Cookies);
            homePage.BtnCookie.Click();

            registerPage.hoverMouse();

            homePage.BtnRegister.Click();
        }
        [TestCleanup]
        public void RegisterCleanUp()
        {

            driver.Quit();
        }

        [TestMethod]
        public void Should_successfully_register_new_account()
        {
            var newRegisterBO = new NewRegisterBO()
            {
                NumePrenume = "Roxana Tester",
                Email = "roxana@unu.unu",
                LblRegister = "Salut Roxana"
            };
            var homePage = registerPage.RegisterApplication(newRegisterBO);
            Assert.AreEqual(homePage.LblRegister.Text, newRegisterBO.LblRegister);
        }
    }
}
