using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProteinAutomationSolution.PageObjects;
using MyProteinAutomationSolution.PageObjects.InputData;
using MyProteinAutomationSolution.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyProteinAutomationSolution
{
    [TestClass]
    public class AccountTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private AccountPage accountPage;
        private NewAccountMessagePage newAccountMessagePage;

        [TestInitialize]
        public void AccountSetup()
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
        public void AccountCleanup()
        {
            driver.Quit();
        }
        [TestMethod]
        public void Should_successfully_modify_birthdate()
        {
            var newLoginBO = new NewLoginBO();
            var newAccountBO = new NewAccountBO()
            {
                DataNasterii = "2000-01-05"
            };
            var homePage = loginPage.LoginApplication(newLoginBO);

            accountPage = loginPage.NavigateToAccountPage();
            accountPage.ModificareDetaliiCont(newAccountBO);
            Assert.AreEqual(newAccountBO.DataNasterii, accountPage.returnDateValue());
        }
        [TestMethod]
        public void Should_successfully_add_a_file()
        {
            var newLoginBO = new NewLoginBO();
            var newAccountBO = new NewAccountBO()
            {
                TipPaginaAccount = "Mesaj",
            };
            var newAccountMessageBO = new NewAccountMessageBO()
            {
                CategorieMesaj = "Returnări și rambursări",
                Mesaj = "Vreau sa returnez o serie de produse cumparate de pe site-ul dvs.",
                FilePath = "/Users/octavianmorarita/Desktop/ASL c&s v2.docx",
                DenumireFisier = "ASL c&s v2.docx",
                MarimeFisier = "19.5kB"
            };
            
            var homePage = loginPage.LoginApplication(newLoginBO);
            var accountPage = loginPage.NavigateToAccountPage();
            newAccountMessagePage = accountPage.NavigateToNewAccountMessagePage();
            
            newAccountMessagePage.TrimiteMesaj(newAccountBO, newAccountMessageBO);
            Assert.AreEqual(newAccountMessagePage.returnStringFileName(newAccountMessageBO),newAccountMessagePage.checkStringLabelUpload());
        }
        [TestMethod]
        public void Should_successfully_change_language_on_website()
        {
            var newLoginBO = new NewLoginBO();
            var homePage = loginPage.LoginApplication(newLoginBO);
            var accountPage = loginPage.NavigateToAccountPage();
            var newLanguageWebsiteBO = new NewLanguageWebsiteBO()
            {
                LimbaTaraTextComplet = "Myprotein China"
            };

            accountPage.SchimbaLimbaWebsite(newLanguageWebsiteBO);
            Assert.AreEqual(newLanguageWebsiteBO.LimbaTaraTextComplet, accountPage.checkLanguageSite());
        }
        [TestMethod]
        public void Should_successfully_change_delivery_country_on_top()
        {
            var newLoginBO = new NewLoginBO();
            var homePage = loginPage.LoginApplication(newLoginBO);
            var accountPage = loginPage.NavigateToAccountPage();
            var newDeliverySettingsBO = new NewDeliverySettingsBO()
            {
                TaraLivrare = "Bahrain",
                RegiuneLimba = "United Arab Emirates",
                ValutaTara = "AED AED",
                LblVerificareSetare = "ae - AED"
            };
            accountPage.SchimbaLimbaWebsiteTop(newDeliverySettingsBO);
            Assert.AreEqual(newDeliverySettingsBO.LblVerificareSetare, accountPage.checkDeliverySettingsTopSite());
        }
    }
}
