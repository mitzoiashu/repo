using System;
using System.Collections.Generic;
using System.Threading;
using MyProteinAutomationSolution.PageObjects.InputData;
using MyProteinAutomationSolution.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace MyProteinAutomationSolution.PageObjects
{
    public class AccountPage
    {
        public IWebDriver driver;
        public NewLoginBO newLoginBO;
        public HomePage homePage;
        public AccountPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By ElemAccount = By.XPath("//p[@class='responsiveSettingsCard_title']");
        public IList<IWebElement> LstElemAccount => driver.FindElements(ElemAccount);

        private By DateOfBirth = By.Id("dateOfBirth");
        public IWebElement DBDateOfBirth => driver.FindElement(DateOfBirth);

        private By OldPassword = By.CssSelector("input[id='oldPassword']");
        public IWebElement TxtOldPassword => driver.FindElement(OldPassword);

        private By SalveazaModificarile = By.ClassName("accountDetailsCard_submitButton");
        public IWebElement BtnSalveazaModificarile => driver.FindElement(SalveazaModificarile);

        private By SelectLanguageText = By.CssSelector("button[class='footerSubsiteSelector_select']");
        public IWebElement BtnSelectLanguageText => driver.FindElement(SelectLanguageText);

        private By LimbaTara = By.CssSelector("a[role='option']");
        public IList<IWebElement> LstLimbaTara => driver.FindElements(LimbaTara);

        private By LimbaTaraSelectata = By.CssSelector("a[class='footerSubsiteSelector_link selected']");
        public IWebElement LblLimbaTaraSelectata => driver.FindElement(LimbaTaraSelectata);

        private By SelectareSetari = By.CssSelector("span[class='responsiveSubMenu_sessionSettingsCountry   ']");
        public IList<IWebElement> BtnSelectareSetari => driver.FindElements(SelectareSetari);

        private By TaraLivrare = By.ClassName("sessionSettings_shippingCountrySelect");
        public IWebElement DdlTaraLivrare => driver.FindElement(TaraLivrare);

        private By RegiuneLimba = By.ClassName("sessionSettings_countrySiteSelect");
        public IWebElement DdlRegiuneLimba => driver.FindElement(RegiuneLimba);

        private By Valuta = By.ClassName("sessionSettings_currencySelect");
        public IWebElement DdlValuta => driver.FindElement(Valuta);

        private By SalveazaSetariTop = By.XPath("//button[contains(@class, 'sessionSettings_saveButton js-sessionSettingsSave')]");
        public IWebElement BtnSalveazaSetariTop => driver.FindElement(SalveazaSetariTop);

        public NewAccountMessagePage NavigateToNewAccountMessagePage()
        {
            return new NewAccountMessagePage(driver);
        }

        public void SchimbaLimbaWebsite(NewLanguageWebsiteBO newLanguageWebsiteBO)
        {
            BtnSelectLanguageText.Click();

            SelectLanguageFromList(newLanguageWebsiteBO.LimbaTaraTextComplet);
            WaitHelpers.WaitElementToBeClickable(driver, SelectLanguageText);
            BtnSelectLanguageText.Click();
        }

        public void SchimbaLimbaWebsiteTop(NewDeliverySettingsBO newDeliverySettingsBO)
        {
            BtnSelectareSetari[0].Click();
            //Thread.Sleep(2000);
            SelectCountryDelivery(newDeliverySettingsBO.TaraLivrare);
            //Thread.Sleep(2000);
            SelectRegionLanguage(newDeliverySettingsBO.RegiuneLimba);
            //Thread.Sleep(2000);
            SelectCurrency(newDeliverySettingsBO.ValutaTara);
            //Thread.Sleep(2000);
            BtnSalveazaSetariTop.Click();
            driver.Navigate().Refresh();
            //Thread.Sleep(2000);
        }

        public void SelectCountryDelivery(string countryDelivery)
        {
            var selectCountryDelivery = new SelectElement(DdlTaraLivrare);
            selectCountryDelivery.SelectByText(countryDelivery);
        }
        public void SelectRegionLanguage(string regionLanguage)
        {
            var selectRegionLanguage = new SelectElement(DdlRegiuneLimba);
            selectRegionLanguage.SelectByText(regionLanguage);
        }
        public void SelectCurrency(string currency)
        {
            var selectValuta = new SelectElement(DdlValuta);
            selectValuta.SelectByText(currency);
        }

        public string checkDeliverySettingsTopSite()
        {
            driver.Navigate().Refresh();
            //WaitHelpers.WaitElementIsVisible(driver, SelectareSetari);
            string str = BtnSelectareSetari[0].Text;
            return str;
        }

        public void SelectLanguageFromList(string limba)
        {
            List<string> txts = new List<string>();
            foreach(var element in LstLimbaTara)
            {
                txts.Add(element.Text);
            }
            foreach(var str in txts)
            {
                if (str == limba)
                {
                    
                    int idx = txts.IndexOf(str);
                    LstLimbaTara[idx].Click();
                }
            }
        }

        public string checkLanguageSite()
        {
            string str = LblLimbaTaraSelectata.Text;
            return str;
        }

        public void ModificareDetaliiCont(NewAccountBO newAccountBO)
        {
            List<string> txtx = new List<string>();
            newLoginBO = new NewLoginBO();
            foreach(var element in LstElemAccount)
            {
                txtx.Add(element.Text);
            }
            foreach(var elem in txtx)
            {
                if(elem == newAccountBO.TipPaginaAccount)
                {
                    int index = txtx.IndexOf(elem);
                    LstElemAccount[index].Click();

                    var js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript("arguments[0].setAttribute('value', arguments[1])", DBDateOfBirth, newAccountBO.DataNasterii);
                    TxtOldPassword.SendKeys(newLoginBO.PasswordLogin);
                    BtnSalveazaModificarile.Click();
                    driver.Navigate().Refresh();
                    LstElemAccount[index].Click();

                    //scroll window down
                    IJavaScriptExecutor js2 = (IJavaScriptExecutor)driver;
                    js2.ExecuteScript("window.scrollBy(0,250)", "");


                    //Thread.Sleep(3000);

                }
            }
        }

        public string returnDateValue()
        {
            var elemVal = DBDateOfBirth.GetAttribute("value");
            return elemVal;
        }

    }
}
