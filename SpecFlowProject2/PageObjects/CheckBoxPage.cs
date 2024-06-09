using OpenQA.Selenium;

namespace SpecFlowProject2.PageObjects
{
    public class CheckBoxPage : BasePage.BasePage
    {

        private static IWebDriver driver = DriverManager.GetDriver();

        public IWebElement CheckBoxLabel => driver.FindElement(By.XPath("//h1"));
        public IWebElement ExpandButton => driver.FindElement(By.XPath("//button[@title='Expand all']"));
        public IWebElement DesktopFolderLabel => driver.FindElement(By.XPath("//label[@for='tree-node-desktop']"));
        public IWebElement OutputMessage => driver.FindElement(By.XPath("//*[@id='result']"));
        public IWebElement DesktopFolder => driver.FindElement(By.XPath("//*[@class='rct-title' and text()='Desktop']"));
        public IWebElement WorkspaceFolder => driver.FindElement(By.XPath("//*[@class='rct-title' and text()='WorkSpace']"));
        public IWebElement OfficeFolder => driver.FindElement(By.XPath("//*[@class='rct-title' and text()='Office']"));

        public override IWebElement ReturnElement(string elementName)
        {
            return elementName switch
            {
                "CheckBoxLabel" => CheckBoxLabel,
                "ExpandButton" => ExpandButton,
                "DesktopFolderLabel" => DesktopFolderLabel,
                "OutputMessage" => OutputMessage,
                "DesktopFolder" => DesktopFolder,
                "WorkspaceFolder" => WorkspaceFolder,
                "OfficeFolder" => OfficeFolder,

                _ => throw new NoSuchElementException("Element not found: " + elementName)
            };
        }
    }
}
