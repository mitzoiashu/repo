using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MyProteinAutomationSolution.PageObjects
{
    public class NewAccountMessagePage
    {
        public IWebDriver driver;
        
        public NewAccountMessagePage(IWebDriver browser)
        {
            driver = browser;
        }

        private By ElemAccount2 = By.XPath("//p[@class='customerServiceCard_title']");
        public IList<IWebElement> LstElemAccount2 => driver.FindElements(ElemAccount2);

        private By CategorieMesaj = By.Id("queryCategoryId");
        public IWebElement DdlCategorieMesaj => driver.FindElement(CategorieMesaj);

        private By Mesaj => By.CssSelector("textarea[id='customerService_message']");
        public IWebElement TextareaMesaj => driver.FindElement(Mesaj);

        private By Upload = By.CssSelector("input[id='upload-button']");
        public IWebElement TxtUpload => driver.FindElement(Upload);

        private By UploadNoticeFile = By.ClassName("qq-upload-file");
        public IWebElement LblUploadNotice1 => driver.FindElement(UploadNoticeFile);

        private By UploadNoticeSize = By.ClassName("qq-upload-size");
        public IWebElement LblUploadNotice2 => driver.FindElement(UploadNoticeSize);

        public void TrimiteMesaj(NewAccountBO newAccountBO, NewAccountMessageBO newAccountMessageBO)
        {
            List<string> txtx = new List<string>();
            foreach (var element in LstElemAccount2)
            {
                txtx.Add(element.Text);
            }
            foreach(var elem in txtx)
            {
                if(elem == newAccountBO.TipPaginaAccount)
                {
                    int index = txtx.IndexOf(elem);
                    LstElemAccount2[index].Click();

                    SelectCategorie(newAccountMessageBO);
                    TextareaMesaj.SendKeys(newAccountMessageBO.Mesaj);

                    TxtUpload.SendKeys(newAccountMessageBO.FilePath);
                    Thread.Sleep(2000);

                }
            }
        }

        public void SelectCategorie(NewAccountMessageBO newAccountMessageBO)
        {
            var selectCateg = new SelectElement(DdlCategorieMesaj);
            selectCateg.SelectByText(newAccountMessageBO.CategorieMesaj);
        }

        public string returnStringFileName(NewAccountMessageBO newAccountMessageBO)
        {
            string str = newAccountMessageBO.DenumireFisier + " " + newAccountMessageBO.MarimeFisier;
            return str;
        }

        public string checkStringLabelUpload()
        {
            string str = LblUploadNotice1.Text + " " +LblUploadNotice2.Text;
            return str;
        }
    }
}
