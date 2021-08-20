using System;
using System.Collections.Generic;
using System.Threading;
using MyProteinAutomationSolution.PageObjects.InputData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MyProteinAutomationSolution.PageObjects
{
    public class AddressPage
    {
        private IWebDriver driver;

        public AddressPage(IWebDriver browser)
        {
            driver = browser;
        }
        private By NewAddress = By.XPath("//a[@class='addressBook_addAddress_button']");
        public IWebElement BtnNewAddress => driver.FindElement(NewAddress);

        private By CardFullName = By.ClassName("addressBook_card_fullName");
        public IList<IWebElement> LstCardFullNames => driver.FindElements(CardFullName);

        private By AddAddress2 = By.ClassName("addressBook_addAddress_button_empty");
        public IWebElement BtnAddAddress => driver.FindElement(AddAddress2);

        private By DeleteAddress = By.ClassName("addressBook_card_deleteAddress_button_wrapper");
        public IList<IWebElement> BtnDeleteAddress => driver.FindElements(DeleteAddress);

        private By EditAddress1 = By.XPath("//a[@class='addressBook_card_editAddress_button']");
        public IList<IWebElement> BtnEditAddress => driver.FindElements(EditAddress1);

        private By EditAddress2 = By.CssSelector("button[class=editAddress_card_submitButton]");
        public IWebElement BtnEditAddressSubmit => driver.FindElement(EditAddress2);

        private By NumarTelefon = By.Id("phoneNumber");
        public IWebElement TxtNumarTel => driver.FindElement(NumarTelefon);

        private By AdresaLivrare1 = By.Id("streetName");
        public IWebElement TxtAdresaLivrare1 => driver.FindElement(AdresaLivrare1);

        private By CardAddress = By.ClassName("addressBook_card_address");
        public IList<IWebElement> TxtCardAddress => driver.FindElements(CardAddress);

        private By CodPostal = By.Id("postCode");
        public IWebElement TxtCodPostal => driver.FindElement(CodPostal);

        private By HouseNumber = By.Id("houseNumber");
        public IWebElement TxtHouseNumber => driver.FindElement(HouseNumber);

        private By Oras = By.Id("addressLine3");
        public IWebElement TxtOras => driver.FindElement(Oras);

        public NewAddressPage NavigateToNewAddressPage()
        {
            if(LstCardFullNames.Count < 1)
            {
                BtnAddAddress.Click();
            }
            else
            {
                BtnNewAddress.Click();
            }
            
            return new NewAddressPage(driver);
        }

        public string matchString(NewAddressBO newAddressBO)
        {
            string str = null;
            foreach (var element in LstCardFullNames)
            {
                if (element.Text == newAddressBO.NumePrenume)
                {
                    str = element.Text;
                }
            }
            return str;
        }

        public string checkAdresaLivrare(NewAddressBO newAddressBO)
        {
            string str = newAddressBO.NrCasei + newAddressBO.AdresaLivrare1 + ", " + newAddressBO.Oras
                           + ", " + newAddressBO.CodPostal;
            driver.Navigate().Refresh();

            foreach (var element in TxtCardAddress)
            {
                if (element.Text.Contains(str))
                    break;
            }
            return str;
        }
        
        public void StergeAdresaLivrare(NewAddressBO newAddressBO)
        {
            List<string> txts = new List<string>();

            foreach (var element in LstCardFullNames)
            {
                txts.Add(element.Text);
            }
            //int index = txts.IndexOf(newAddressBO.NumePrenume);
            //BtnDeleteAddress[index].Click();

            foreach (var str in txts)
            {
                if(str == newAddressBO.NumePrenume)
                {
                    int ind = txts.IndexOf(str);
                    BtnDeleteAddress[ind].Click();
                }
            }
        }
        
        public void ModificaAdresaLivrare(NewAddressBO newAddressBO)
        {
            List<string> txts = new List<string>();
            foreach(var element in LstCardFullNames)
            {
                txts.Add(element.Text);
            }
            foreach(var elem in txts)
            {
                if(elem == newAddressBO.NumePrenume)
                {
                    int idx = txts.IndexOf(elem);
                    BtnEditAddress[idx].Click();
                    TxtCodPostal.Clear();
                    TxtHouseNumber.Clear();
                    TxtAdresaLivrare1.Clear();
                    TxtOras.Clear();

                    TxtCodPostal.SendKeys(newAddressBO.CodPostal);
                    TxtHouseNumber.SendKeys(newAddressBO.NrCasei);
                    TxtAdresaLivrare1.SendKeys(newAddressBO.AdresaLivrare1);
                    TxtOras.SendKeys(newAddressBO.Oras);

                    BtnEditAddressSubmit.Click();
                }
            }
        }

    }
}
