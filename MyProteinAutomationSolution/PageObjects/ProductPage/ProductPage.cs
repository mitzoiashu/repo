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
    public class ProductPage
    {
        private IWebDriver driver;

        public ProductPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By ProductName = By.CssSelector("h3[class='athenaProductBlock_productName']");
        public IList<IWebElement> LstProductNames => driver.FindElements(ProductName);

        private By ProductName2 = By.CssSelector("h3[class='athenaProductBlock_productName']");
        public IWebElement LblProductName2 => driver.FindElement(ProductName2);

        private By ProductName3 = By.CssSelector("h3[class='productName_title']");
        public IList<IWebElement> TxtProductName3 => driver.FindElements(ProductName3);

        private By ProductName4 = By.CssSelector("a[class='athenaAddedToBasketModal_itemName']");
        public IWebElement TxtProductName4 => driver.FindElement(ProductName4);

        private By ProductPrice1 = By.ClassName("productPrice_price");
        public IWebElement LblProductPrice => driver.FindElement(ProductPrice1);

        private By BasketSubtotalPrice = By.XPath("//div[@class='athenaBasket_bodyItem athenaBasket_bodyItem-subTotal']");
        public IWebElement TxtBasketSubtotalPrice => driver.FindElement(BasketSubtotalPrice);

        private By AddWishlist = By.ClassName("productAddToWishlist_text");
        public IWebElement BtnAddWishlist => driver.FindElement(AddWishlist);

        private By DeteleWishlistProduct = By.CssSelector("button[class='productAddToWishlist_deleteButton'][data-context='wishlistDelete']");
        public IList<IWebElement> BtnDeleteProductWishlist => driver.FindElements(DeteleWishlistProduct);

        private By WishListsMenu = By.XPath("//a[@data-context='headerWishlist']");
        public IWebElement BtnWishlistMenu => driver.FindElement(WishListsMenu);

        private By CloseNewsletterWishList = By.XPath("//button[@class='wishlistsNewsletterModal_close']");
        public IWebElement BtnCloseNewsletter => driver.FindElement(CloseNewsletterWishList);

        private By AddBasket = By.CssSelector("button[data-component='productAddToBasket']");
        public IWebElement BtnAddBasket => driver.FindElement(AddBasket);

        private By FinalizareComanda = By.CssSelector("//a[@data-view-basket]");
        public IWebElement BtnFinalizareComanda => driver.FindElement(FinalizareComanda);

        private By BasketMenu = By.XPath("//span[@class='responsiveFlyoutBasket_name']");
        public IWebElement BtnBasketMenu => driver.FindElement(BasketMenu);

        private By ProductItemBasket = By.CssSelector("p[class='athenaBasket_itemName']");
        public IList<IWebElement> LstProductItemBasket => driver.FindElements(ProductItemBasket);

        private By DeleteItemBasket = By.CssSelector("a[class='athenaBasket_removeItem']");
        public IList<IWebElement> BtnDeleteItemBasket => driver.FindElements(DeleteItemBasket);

        private By MarimeProdus = By.CssSelector("button[type='button'][data-variation-id='1']");
        public IList<IWebElement> LstMarimeProdus => driver.FindElements(MarimeProdus);

        private By Culoare = By.XPath("//span[@class='athenaProductVariations_colorSwatchInner']");
        public IList<IWebElement> ClCuloare => driver.FindElements(Culoare);

        private By QtyIncrease = By.XPath("//a[@class='athenaBasket_increaseQty']");
        public IList<IWebElement> LstQtyIncrease => driver.FindElements(QtyIncrease);

        private By FilterCheck = By.XPath("//span[@class='responsiveFacets_sectionItemValue ']");
        public IList<IWebElement> LstFilterCheck => driver.FindElements(FilterCheck);

        private By FilterValue = By.ClassName("responsiveFacets_selectionValue");


        public IWebElement LblFilterValue => driver.FindElement(FilterValue);

        public void hoverMouse()
        {
            Actions action = new Actions(driver);
            IWebElement btnCont = driver.FindElement(By.CssSelector("span[class=responsiveAccountHeader_openAccountPanelText"));
            action.MoveToElement(btnCont).Perform();
        }

        public void hoverMouseFinishOrder()
        {
            Actions action = new Actions(driver);
            IWebElement btnFinalizareComanda = driver.FindElement(By.XPath("//a[@class='athenaAddedToBasketModal_viewBasketButton js-e2e-quickView-basket']"));
            action.MoveToElement(btnFinalizareComanda).Perform();
            //WaitHelpers.WaitElementToBeClickable(driver, FinalizareComanda);
            btnFinalizareComanda.Click();
        }

        public void hoverMouseProducts(NewProductBO newProductBO)
        {
            if(newProductBO.CategorieProdus == "Vitamine")
            {
                //TEST Vitamine > Vitamine si minerale
                Actions action = new Actions(driver);
                IWebElement btnCont = driver.FindElement(By.CssSelector("[data-subnav-target='subnav-vitamins']"));
                Thread.Sleep(2000);
                action.MoveToElement(btnCont).Perform();
                Thread.Sleep(2000);
                if (newProductBO.SubcategorieProdus =="Vitamine si minerale")
                {
                    Actions action2 = new Actions(driver);
                    IWebElement btnCont2 = driver.FindElement(By.CssSelector("li[data-subnav-target='subnav-vitamins'] [data-subnav-target='subnav-vitamins-minerals']"));
                    action2.MoveToElement(btnCont2).Perform();

                    btnCont2.Click();
                }
            }

            else if (newProductBO.CategorieProdus == "Alimente si gustari")
            {
                //TEST Vitamine > Vitamine si minerale
                Actions action = new Actions(driver);
                IWebElement btnCont = driver.FindElement(By.CssSelector("li[class='responsiveFlyoutMenu_levelOneItem-slide']~[data-subnav-target='subnav-/myhealth-hub.list']"));
                //Thread.Sleep(2000);
                action.MoveToElement(btnCont).Perform();
                //Thread.Sleep(2000);
                if (newProductBO.SubcategorieProdus == "Unturi")
                {
                    Actions action2 = new Actions(driver);
                    IWebElement btnCont2 = driver.FindElement(By.CssSelector("li[data-subnav-target='subnav-/myhealth-hub.list'] [data-subnav-target='subnav-nut-butters']"));
                    action2.MoveToElement(btnCont2).Perform();

                    btnCont2.Click();
                }
            }
            else if(newProductBO.CategorieProdus == "Imbracaminte")
            {
                Actions action = new Actions(driver);
                IWebElement btnCategorie = driver.FindElement(By.CssSelector("li[data-subnav-target='subnav-clothing'][data-js-element='hasSubnav']"));
                action.MoveToElement(btnCategorie).Perform();
                if(newProductBO.SubcategorieProdus == "Maiouri barbati")
                {
                    Actions action2 = new Actions(driver);
                    IWebElement btnSubcategorie = driver.FindElement(By.CssSelector("li[class='responsiveFlyoutMenu_levelThreeItem'][data-subnav-target='subnav-stringers-tanks']"));
                    action2.MoveToElement(btnSubcategorie).Perform();
                    btnSubcategorie.Click();
                }

            }
        }

        public void AddProductInWishlist(NewProductBO newProductBO)
        {
            List<string> elements = new List<string>();
            foreach(var element in LstProductNames)
            {
                elements.Add(element.Text);
            }

            foreach(var str in elements)
            {
                if(str == newProductBO.DenumireProdus)
                {
                    int index = elements.IndexOf(str);
                    LstProductNames[index].Click();
                    BtnAddWishlist.Click();
                    driver.Navigate().Refresh();
                    //Thread.Sleep(3000);
                }
            }
            hoverMouse();
            BtnWishlistMenu.Click();
            BtnCloseNewsletter.Click();
        }

        public void DeleteProductFromWishlist(NewProductBO newProductBO)
        {
            string stringComplet = newProductBO.DenumireProdus + " - " + newProductBO.CantitateProdus + " - " +
                                    newProductBO.AromaProdus;
            hoverMouse();
            BtnWishlistMenu.Click();
            BtnCloseNewsletter.Click();
            List<string> txts = new List<string>();
            foreach (var element in LstProductNames)
            {
                txts.Add(element.Text);
            }
            foreach(var str in txts)
            {
                if (str == stringComplet)
                {
                    
                    int index = txts.IndexOf(str);
                    
                    BtnDeleteProductWishlist[index].Click();
                }
            }
        }

        public void AddProductInBasket(NewProductBO newProductBO)
        {
            List<string> elements = new List<string>();
            foreach (var element in LstProductNames)
            {
                elements.Add(element.Text);
            }

            foreach (var str in elements)
            {
                if (str == newProductBO.DenumireProdus)
                {
                    int index = elements.IndexOf(str);
                    LstProductNames[index].Click();
                    driver.Navigate().Refresh();
                    BtnAddBasket.Click();
                    hoverMouseFinishOrder();
                }
            }
        }

        public void AddProductInBasket_v2(NewProductBO newProductBO)
        {
            List<string> elements = new List<string>();
            foreach (var element in LstProductNames)
            {
                elements.Add(element.Text);
            }
            foreach(var str in elements)
            {
                if(str == newProductBO.DenumireProdus)
                {
                    int index = elements.IndexOf(str);
                    LstProductNames[index].Click();

                    LstMarime(newProductBO);

                    WaitHelpers.WaitElementIsVisible(driver, Culoare);
                    WaitHelpers.WaitElementToBeClickable(driver, Culoare);
                    ClCuloare[newProductBO.CuloareIdx].Click();
                    
                    WaitHelpers.WaitElementToBeClickable(driver, AddBasket);
                    BtnAddBasket.Click();
                    string elem = TxtProductName4.Text;
                    hoverMouseFinishOrder();
                    BtnLstQtyIncrease(elem);
                }
            }
        }

        public void Check_filters_for_products(string ceva1)
        {
            List<string> elements = new List<string>();
            foreach(var elem in LstFilterCheck)
            {
                elements.Add(elem.Text);
            }
            foreach(var str in elements)
            {
                if(str.Contains(ceva1))
                {
                    int idx = elements.IndexOf(str);
                    LstFilterCheck[idx].Click();
                    //Thread.Sleep(2000);
                    //driver.Navigate().Refresh();
                }
            }
        }

        public string returnStringItemName()
        {
            string kdos=null;
            foreach(var i in TxtProductName3)
            {
                kdos = TxtProductName3[1].Text;
            }
            return kdos;
        }

        public void BtnLstQtyIncrease(string str)
        {
            List<string> elements = new List<string>();
            foreach(var element in LstProductItemBasket)
            {
                elements.Add(element.Text);
            }
            foreach(var i in elements)
            {
                if(i.Contains(str))
                {
                    WaitHelpers.WaitElementToBeClickable(driver, QtyIncrease);
                    int idx = elements.IndexOf(i);
                    LstQtyIncrease[idx].Click();
                }
            }
        }

        public void LstMarime(NewProductBO newProductBO)
        {
            List<string> txts = new List<string>();
            foreach (var str1 in LstMarimeProdus)
            {
                txts.Add(str1.Text);
            }
            foreach(var elem in txts)
            {
                if (elem == newProductBO.MarimeImbracaminte)
                {
                    int ind = txts.IndexOf(elem);
                    LstMarimeProdus[ind].Click();
                }
            }
        }

        public void RemoveProductFromBasket(NewProductBO newProductBO)
        {
            BtnBasketMenu.Click();
            List<string> txts = new List<string>();
            foreach(var element in LstProductItemBasket)
            {
                txts.Add(element.Text);
            }
            foreach(var elem in txts)
            {
                if (elem == MethodHelpers.stringProductNameWishList(newProductBO))
                {
                    int ind = txts.IndexOf(elem);
                    BtnDeleteItemBasket[ind].Click();
                    //Thread.Sleep(3000);
                }
            }

        }

        public string checkProductNameBasket (NewProductBO newProductBO)
        {
            string stringComplet = newProductBO.DenumireProdus + " - " + newProductBO.CantitateProdus + " - " +
                                    newProductBO.AromaProdus;
            foreach (var element in LstProductItemBasket)
            {
                if (element.Text == stringComplet)
                    break;
            }
            return stringComplet;
        }

        public string checkProductNameBasketIsFalse(NewProductBO newProductBO)
        {
            string stringComplet = newProductBO.DenumireProdus + " - " + newProductBO.CantitateProdus + " - " +
                                    newProductBO.AromaProdus;
            foreach(var element in LstProductItemBasket)
            {
                if(element.Text != stringComplet)
                {
                    break;
                }
            }
            return null;
        }

        public string checkhProductWishList(NewProductBO newProductBO)
        {
            string stringComplet = newProductBO.DenumireProdus + " - " + newProductBO.CantitateProdus + " - " +
                                    newProductBO.AromaProdus;
            foreach (var element in LstProductNames)
            {
                if(element.Text == stringComplet)
                {
                    break;
                }
            }
            return stringComplet;
        }
    }
}
