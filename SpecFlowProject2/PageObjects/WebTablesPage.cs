using OpenQA.Selenium;

namespace SpecFlowProject2.PageObjects
{
    internal class WebTablesPage : BasePage.BasePage
    {
        private static IWebDriver driver = DriverManager.GetDriver();

        public IWebElement WebTableLabel => driver.FindElement(By.XPath("//h1"));
        public IWebElement AddUserButton => driver.FindElement(By.Id("addNewRecordButton"));
        public IWebElement SubmitButton => driver.FindElement(By.Id("submit"));
        public IWebElement RegistrationFormLabel => driver.FindElement(By.Id("registration-form-modal"));
        //Registration Form
        public IWebElement FirstName => driver.FindElement(By.Id("firstName"));
        public IWebElement LastName => driver.FindElement(By.Id("lastName"));
        public IWebElement UserEmail => driver.FindElement(By.Id("userEmail"));
        public IWebElement Age => driver.FindElement(By.Id("age"));
        public IWebElement Salary => driver.FindElement(By.Id("salary"));
        public IWebElement Department => driver.FindElement(By.Id("department"));
        public IWebElement EditButton => driver.FindElement(By.XPath("//*[@id='edit-record-1']"));
        public IWebElement WebTableRoll => driver.FindElement(By.XPath("//*[@class='rt-tbody']"));
        public IWebElement DeleteButton => driver.FindElement(By.XPath("//*[@id='delete-record-1']"));

        public override IWebElement ReturnElement(string elementName)
        {
            return elementName switch

            {
                "WebTableLabel" => WebTableLabel,
                "AddUserButton" => AddUserButton,
                "SubmitButton" => SubmitButton,
                "RegistrationFormLabel" => RegistrationFormLabel,
                "FirstName" => FirstName,
                "LastName" => LastName,
                "UserEmail" => UserEmail,
                "Age" => Age,
                "Salary" => Salary,
                "Department" => Department,
                "EditButton" => EditButton,
                "WebTableRoll" => WebTableRoll,
                "DeleteButton" => DeleteButton,
                _ => throw new NoSuchElementException("Element not found: " + elementName)

            };
        }
    }

}
