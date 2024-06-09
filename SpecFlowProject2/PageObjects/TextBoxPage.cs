using OpenQA.Selenium;

namespace SpecFlowProject2.PageObjects
{
    public class TextBoxPage : BasePage.BasePage
    {
        private static IWebDriver driver = DriverManager.GetDriver();

        public IWebElement TextBoxLabel => driver.FindElement(By.XPath("//h1"));
        public IWebElement FullNameInput => driver.FindElement(By.Id("userName"));
        public IWebElement EmailInput => driver.FindElement(By.Id("userEmail"));
        public IWebElement CurrentAdressInput => driver.FindElement(By.Id("currentAddress"));
        public IWebElement PermanentAdressInput => driver.FindElement(By.Id("permanentAddress"));
        public IWebElement SubmitButton => driver.FindElement(By.Id("submit"));
        public IWebElement OutPutWindows => driver.FindElement(By.Id("output"));

        public override IWebElement ReturnElement(string elementName)
        {
            return elementName switch
            {
                "TextBoxLabel" => TextBoxLabel,
                "FullNameInput" => FullNameInput,
                "EmailInput" => EmailInput,
                "CurrentAdressInput" => CurrentAdressInput,
                "PermanentAdressInput" => PermanentAdressInput,
                "SubmitButton" => SubmitButton,
                "OutPutWindows" => OutPutWindows,
                _ => throw new NoSuchElementException("Element not found: " + elementName)
            };
        }
    }
}
   


       

