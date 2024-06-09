using OpenQA.Selenium;
using SpecFlowProject2.Hooks;
using SpecFlowProject2.PageObjects;
using TechTalk.SpecFlow;

namespace SpecFlowProject2.StepDefinitions
{
    [Binding]
    public class CheckBoxStepDefinition
    {
        private IWebDriver _driver;
        private WaitHelper.WaitHelper _waitHelper;
        private  CheckBoxPage _checkBoxPage;
        private Urls _url;

        public CheckBoxStepDefinition()
        {
            _driver = BasePage.BasePage.GetDriver();
            _waitHelper = new WaitHelper.WaitHelper();
            _url = new Urls();
            _checkBoxPage = new CheckBoxPage();
        }

        [Given(@"I navigate to Check Box page")]
        public void GivenINavigateToCheckBoxPage()
        {
            _checkBoxPage.NavigateTo(_driver,_url.CheckBoxUrl);
        }

        [When(@"I am on the CheckBox page")]
        public void WhenIAmOnTheCheckBoxPage()
        {
            _checkBoxPage.IsElementDisplayed(_checkBoxPage.CheckBoxLabel);
        }


        [When(@"The document tree is expanded")]
        public void WhenTheDocumentTreeIsExpanded()
        {
            _waitHelper.WaitForElementToBeVisible(_driver, _checkBoxPage.DesktopFolderLabel);
            _checkBoxPage.IsElementDisplayed(_checkBoxPage.DesktopFolderLabel);
        }
        
        [When(@"I select document with name '(.*)'")]
        public void WhenISelectDocumentWithName(string elementText)
        {
            _checkBoxPage.ClickOnElementWithText(elementText);
        }

        [Then(@"I Should see an output Message")]
        public void ThenIShouldSeeAnOutputMessage()
        {
            _waitHelper.WaitForElementToBeVisible(_driver, _checkBoxPage.OutputMessage);
            _checkBoxPage.IsElementDisplayed(_checkBoxPage.OutputMessage);
        }

        [When(@"I click the '([^']*)' button on Checkbox Page")]
        public void WhenIClickTheButtonOnCheckboxPage(string button)
        {
            _checkBoxPage.ScrollIntoView(button);
            _checkBoxPage.ClickElement(button);
        }

    }
}
