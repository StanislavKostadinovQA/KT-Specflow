using OpenQA.Selenium;

namespace SpecFlowProject2.PageObjects
{
    internal class ButtonsPage : BasePage.BasePage
    {
        public ButtonsPage() : base() { }
        private static IWebDriver driver = DriverManager.GetDriver();

        public IWebElement ButtonsLabel => driver.FindElement(By.XPath("//h1"));
        public IWebElement DoubleClickButton => driver.FindElement(By.XPath("//*[@id='doubleClickBtn']"));
        public IWebElement RightClickButton => driver.FindElement(By.XPath("//*[@id='rightClickBtn']"));
        public IWebElement ClickMeButton => driver.FindElement(By.XPath("//button[text()='Click Me']")); 
        // Messages when buttons are clicked.
        public IWebElement DoubleClickMessage => driver.FindElement(By.XPath("//*[@id='doubleClickMessage']"));
        public IWebElement RightClickMessage => driver.FindElement(By.XPath("//*[@id='rightClickMessage']"));
        public IWebElement ClickMeMessage => driver.FindElement(By.XPath("//*[@id='dynamicClickMessage']"));

        public override IWebElement ReturnElement(string elementName)
        {
            return elementName switch
            {
                "ButtonsLabel" => ButtonsLabel,
                "DoubleClickButton" => DoubleClickButton,
                "RightClickButton" => RightClickButton,
                "ClickMeButton" => ClickMeButton,
                "DoubleClickMessage" => DoubleClickMessage,
                "RightClickMessage" => RightClickMessage,
                "ClickMeMessage" => ClickMeMessage,
                _ => throw new NoSuchElementException("Element not found: " + elementName)
            };
        }
    }
}
