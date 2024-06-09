using OpenQA.Selenium;
using SpecFlowProject2.Hooks;
using SpecFlowProject2.PageObjects;
using TechTalk.SpecFlow;

namespace SpecFlowProject2.StepDefinitions
{

    [Binding]
    public class WebTablesDefinition
    {
        private IWebDriver driver;
        private WaitHelper.WaitHelper _waitHelper;
        private WebTablesPage _webTablesPage;
        private Urls _url;

        public WebTablesDefinition()
        {
            driver = DriverManager.GetDriver();
            _waitHelper = new WaitHelper.WaitHelper();
            _url = new Urls();
            _webTablesPage = new WebTablesPage();
        }

        [Given(@"I Navigate to Web Table Page")]
        public void GivenINavigateToWebTablePage()
        {
            _webTablesPage.NavigateTo(driver,_url.WebTables);
        }

        [When(@"I am on Web table page")]
        public void WhenIAmOnWebTablePage()
        {
            _webTablesPage.IsElementDisplayed(_webTablesPage.WebTableLabel);
        }

        [When(@"I click the Add button")]
        public void WhenIClickTheAddButton()
        {
            _webTablesPage.ClickElement("AddUserButton");
        }

        [When(@"i should see the registration form")]
        public void WhenIShouldSeeTheRegistrationForm()
        {
            _webTablesPage.IsElementDisplayed(_webTablesPage.RegistrationFormLabel);
        }

        [When(@"I enter a valid '([^']*)', '([^']*)' , '([^']*)' , '([^']*)' , '([^']*)' , '([^']*)'")]
        public void WhenIEnterAValid(string firstName, string lastName, string email, string age, string salary, string department)
        {
            _webTablesPage.SendKeysToElement(_webTablesPage.FirstName,firstName);
            _webTablesPage.SendKeysToElement(_webTablesPage.LastName,lastName);
            _webTablesPage.SendKeysToElement(_webTablesPage.UserEmail,email);
            _webTablesPage.SendKeysToElement(_webTablesPage.Age,age);
            _webTablesPage.SendKeysToElement(_webTablesPage.Salary,salary);
            _webTablesPage.SendKeysToElement(_webTablesPage.Department,department);
        }

        [When(@"I click the '([^']*)' button")]
        public void WhenIClickTheButton(string button)
        {
            _webTablesPage.ScrollIntoView(button);
            _webTablesPage.ClickElement(button);
        }

        [When(@"I Change the firstname as '([^']*)'")]
        public void WhenIChangeTheFirstnameAs(string firstName)
        {
            _webTablesPage.SendKeysToElement(_webTablesPage.FirstName,firstName);
        }

        [Then(@"I should see the '([^']*)' into the '([^']*)' element")]
        public void ThenIShouldSeeTheIntoTheElement(string text, string element)
        {
            Thread.Sleep(3000); // TODO - for testing purporeses
            _webTablesPage.DoesElementContainText(element, text);   
        }

        [Then(@"the user should be deleted")]
        public void ThenTheUserShouldBeDeleted()
        {
            _webTablesPage.TextIsNotDisplayed("WebTableRoll", "Cierra");

        }
    }
}
