using System;
namespace MyProteinAutomationSolution.PageObjects.InputData
{
    public class NewRegisterBO
    {
        public string NumePrenume { get; set; } = "Testter Unom";
        public string Email { get; set; } = "testter@unom.test";
        public string Password { get; set; } = "testing";
        public int MktOptions { get; set; } = 1;
        public string LblRegister { get; set; } = "Salut Testter";
    }
}
