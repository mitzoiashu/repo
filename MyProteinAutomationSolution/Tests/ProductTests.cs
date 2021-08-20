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
    public class ProductTests
    {
        private IWebDriver driver;
        private ProductPage productPage;
        private LoginPage loginPage;
        //private MethodHelpers methodHelpers;

        [TestInitialize]
        public void ProductSetup()
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
        public void ProductCleanUp()
        {
            driver.Quit();
        }

        [TestMethod]
        public void Should_successfully_add_products_in_wishlist()
        {
            var newLoginBO = new NewLoginBO();
            var homePage = loginPage.LoginApplication(newLoginBO);
            var newProductBO = new NewProductBO()
            {
                CategorieProdus = "Alimente si gustari",
                SubcategorieProdus = "Unturi",
                DenumireProdus = "Crema tartinabilă proteică",
                CantitateProdus = "360g",
                AromaProdus = "Ciocolata cu lapte"
            };

            homePage.NavigateToProductPage();
            productPage = homePage.NavigateToProductPage();

            productPage.hoverMouseProducts(newProductBO);
            productPage.AddProductInWishlist(newProductBO);
            Assert.AreEqual(MethodHelpers.stringProductNameWishList(newProductBO), productPage.checkhProductWishList(newProductBO));
        }
        [TestMethod]
        public void Should_successfully_delete_products_from_wishlist()
        {
            var newLoginBO = new NewLoginBO();
            var homePage = loginPage.LoginApplication(newLoginBO);
            var newProductBO = new NewProductBO()
            {
                DenumireProdus = "Crema tartinabilă proteică",
                CantitateProdus = "360g",
                AromaProdus = "Ciocolata cu lapte"
            };

            homePage.NavigateToProductPage();
            productPage = homePage.NavigateToProductPage();

            productPage.DeleteProductFromWishlist(newProductBO);
            Assert.AreNotSame(productPage.checkhProductWishList(newProductBO), MethodHelpers.stringProductNameWishList(newProductBO));
        }

        [TestMethod]
        public void Should_successfully_add_products_in_basket()
        {
            var newLoginBO = new NewLoginBO();
            var homePage = loginPage.LoginApplication(newLoginBO);
            var newProductBO = new NewProductBO();

            homePage.NavigateToProductPage();
            productPage = homePage.NavigateToProductPage();

            productPage.hoverMouseProducts(newProductBO);
            productPage.AddProductInBasket(newProductBO);
            Assert.AreEqual(MethodHelpers.stringProductNameWishList(newProductBO), productPage.checkProductNameBasket(newProductBO));
        }
        [TestMethod]
        public void Should_successfully_remove_products_from_basket()
        {
            var newLoginBO = new NewLoginBO();
            var homePage = loginPage.LoginApplication(newLoginBO);
            var newProductBO = new NewProductBO()
            {
                //DenumireProdus = "Unt de arahide 100% natural",
                //CantitateProdus = "1kg",
                //AromaProdus = "Original - Crocant"
                DenumireProdus = "Crema tartinabilă proteică",
                CantitateProdus = "360g",
                AromaProdus = "Ciocolata cu lapte"
            };

            homePage.NavigateToProductPage();
            productPage = homePage.NavigateToProductPage();

            productPage.RemoveProductFromBasket(newProductBO);
            Assert.AreNotEqual(MethodHelpers.stringProductNameWishList(newProductBO), productPage.checkProductNameBasketIsFalse(newProductBO));
        }
        [TestMethod]
        public void Should_successfully_add_products_in_basket_v2()
        {
            var newLoginBO = new NewLoginBO();
            var homePage = loginPage.LoginApplication(newLoginBO);
            var newProductBO = new NewProductBO()
            {
                CategorieProdus = "Imbracaminte",
                SubcategorieProdus = "Maiouri barbati",
                DenumireProdus = "MP Men's Outline Graphic Tank - White",
                Culoare = "Washed Oxblood",
                CuloareIdx = 1,
                MarimeImbracaminte = "XXXL",
                PretProdus = "55.00RON"
            };

            homePage.NavigateToProductPage();
            productPage = homePage.NavigateToProductPage();
            productPage.hoverMouseProducts(newProductBO);

            productPage.AddProductInBasket_v2(newProductBO);
            Assert.AreNotSame(newProductBO.PretProdus, productPage.TxtBasketSubtotalPrice.Text);
        }
        [TestMethod]
        public void Should_successfully_check_filter_on_product_page()
        {
            var newLoginBO = new NewLoginBO();
            var homePage = loginPage.LoginApplication(newLoginBO);
            var newProductBO = new NewProductBO()
            {
                CategorieProdus = "Imbracaminte",
                SubcategorieProdus = "Maiouri barbati",
            };
            var newProductFiltersBO = new NewProductFiltersBO();

            homePage.NavigateToProductPage();
            productPage = homePage.NavigateToProductPage();
            productPage.hoverMouseProducts(newProductBO);

            productPage.Check_filters_for_products(newProductFiltersBO.ImbracaminteSportiva);
            Assert.AreEqual(newProductFiltersBO.ImbracaminteSportiva, productPage.LblFilterValue.Text);
        }
    }
}
