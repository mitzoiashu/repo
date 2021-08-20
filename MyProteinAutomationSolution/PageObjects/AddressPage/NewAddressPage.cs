using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MyProteinAutomationSolution.PageObjects
{
    public class NewAddressPage
    {
        public IWebDriver driver;

        public NewAddressPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By AdresaNumePrenume = By.Id("fullName");
        public IWebElement TxtAdresaNumePrenume => driver.FindElement(AdresaNumePrenume);

        private By Tara = By.Id("country");
        public IWebElement DdlTara => driver.FindElement(Tara);

        private By CodPostal = By.Id("postCode");
        public IWebElement TxtCodPostal => driver.FindElement(CodPostal);

        private By HouseNumber = By.Id("houseNumber");
        public IWebElement TxtHouseNumber => driver.FindElement(HouseNumber);

        private By AdresaLivrare1 = By.Id("streetName");
        public IWebElement TxtAdresaLivrare1 => driver.FindElement(AdresaLivrare1);

        private By Oras = By.Id("addressLine3");
        public IWebElement TxtOras => driver.FindElement(Oras);

        private By NumarTelefon = By.Id("phoneNumber");
        public IWebElement TxtNumarTel => driver.FindElement(NumarTelefon);

        private By AddAddress1 = By.CssSelector("button[class=editAddress_card_submitButton]");
        public IWebElement BtnAddAddressSubmit => driver.FindElement(AddAddress1);

        private By CardFullName = By.ClassName("addressBook_card_fullName");
        public IList<IWebElement> LstCardFullNames => driver.FindElements(CardFullName);

        
        public void SelectTara()
        {
            var selectTara = new SelectElement(DdlTara);
            selectTara.SelectByText("Italy");
        }

        public void AdaugaAdresaLivrare(NewAddressBO newAddressBO)
        {
            TxtAdresaNumePrenume.SendKeys(newAddressBO.NumePrenume);
            SelectTara();
            TxtCodPostal.SendKeys(newAddressBO.CodPostal);
            TxtHouseNumber.SendKeys(newAddressBO.NrCasei);
            TxtAdresaLivrare1.SendKeys(newAddressBO.AdresaLivrare1);
            TxtOras.SendKeys(newAddressBO.Oras);
            TxtNumarTel.SendKeys(newAddressBO.NumarTelefon);

            BtnAddAddressSubmit.Click();

        }
        
    }
}
