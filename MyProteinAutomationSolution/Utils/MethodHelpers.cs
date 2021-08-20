using System;
using MyProteinAutomationSolution.PageObjects;
using MyProteinAutomationSolution.PageObjects.InputData;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace MyProteinAutomationSolution.Utils
{
    public static class MethodHelpers
    {
        public static string stringProductNameWishList(NewProductBO newProductBO)
        {
            string str = newProductBO.DenumireProdus + " - " + newProductBO.CantitateProdus + " - " +
                                    newProductBO.AromaProdus;
            return str;
        }
        public static string stringAdresaLivrare(NewAddressBO newAddressBO)
        {
            string str = newAddressBO.NrCasei + newAddressBO.AdresaLivrare1 + ", " + newAddressBO.Oras
                           + ", " + newAddressBO.CodPostal;

            return str;
        }
    }
}
