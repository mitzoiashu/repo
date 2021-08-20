using System;
namespace MyProteinAutomationSolution.PageObjects.InputData
{
    public class NewProductBO
    {
        public string CategorieProdus { get; set; } = "Alimente si gustari";
        public string SubcategorieProdus { get; set; } = "Unturi";
        public string DenumireProdus { get; set; } = "Crema tartinabilă proteică";
        public string CantitateProdus { get; set; } = "360g";
        public string AromaProdus { get; set; } = "Ciocolata cu lapte";
        public string MarimeImbracaminte { get; set; } = "XXS";
        public string Culoare { get; set; } = "Alb";
        public int CuloareIdx { get; set; } = 1;
        public string PretProdus { get; set; } = "55.00RON";

    }
}
