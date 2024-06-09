using OpenQA.Selenium;
using SpecFlowProject2.Hooks;
using SpecFlowProject2.PageObjects;
using TechTalk.SpecFlow;


namespace SpecFlowProject2.StepDefinitions
{
    [Binding]
    public class ButtonsStepDefinition 
    {
        private IWebDriver driver;
        private WaitHelper.WaitHelper _waitHelper;
        private ButtonsPage _buttonPageObject;
        private Urls _url;

        public ButtonsStepDefinition() {

            driver = BasePage.BasePage.GetDriver();
            _waitHelper = new WaitHelper.WaitHelper();
            _url = new Urls();
            _buttonPageObject = new ButtonsPage();
        }

        [Given(@"I navigate to Buttons page")]
        public void GivenINavigateToButtonsPage()
        {
            _buttonPageObject.NavigateTo(driver, _url.ButtonsUrl);
        }

        [When(@"I am on the Buttons page")]
        public void WhenIAmOnTheButtonsPage()
        {
            _waitHelper.WaitForElementToBeVisible(driver, _buttonPageObject.ButtonsLabel);
        }

        [Then(@"I should see the '(.*)'")]
        public void ThenIShouldSeeThe(string message)
        {
            var webElement = _buttonPageObject.ReturnElement(message);
            _waitHelper.WaitForElementToBeVisible(driver, webElement);
            _buttonPageObject.IsElementDisplayed(webElement);
        }

        [When(@"I click '([^']*)' on Buttons page")]
        public void WhenIClickOnButtonsPage(string button)
        {
             _buttonPageObject.ScrollToCenter();
             _buttonPageObject.ClickButtonBasedOnType(button);
        }
    }
}
