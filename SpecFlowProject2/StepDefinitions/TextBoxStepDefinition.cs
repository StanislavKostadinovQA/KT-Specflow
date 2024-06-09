using OpenQA.Selenium;
using SpecFlowProject2.Hooks;
using SpecFlowProject2.PageObjects;
using TechTalk.SpecFlow;

namespace SpecFlowProject2.StepDefinitions
{
    [Binding]
    public class TextBoxStepDefinition 
    {
        private IWebDriver driver;
        private WaitHelper.WaitHelper _waitHelper;
        private  TextBoxPage  _textBoxPage;
        private Urls _url;

        public TextBoxStepDefinition()
        {
            driver = DriverManager.GetDriver();
            _waitHelper = new WaitHelper.WaitHelper();
            _url = new Urls();
            _textBoxPage = new TextBoxPage();

        }

        [Given(@"I Navigate to Text Box Page")]
        public void GivenINavigateToTextBoxPage()
        {
            _textBoxPage.NavigateTo(driver, _url.TextBoxUrl);
            
        }
       
        [When(@"I enter my Full Name as '(.*)'")]
        public void WhenIEnterMyFullNameAs(string fullName)
        {
            _textBoxPage.SendKeysToElement(_textBoxPage.FullNameInput, fullName);
        }

        [When(@"I enter my Email as '(.*)'")]
        public void WhenIEnterMyEmailAs(string email)
        {
            _textBoxPage.SendKeysToElement(_textBoxPage.EmailInput, email);
        }

        [When(@"I enter my current address as '(.*)'")]
        public void WhenIEnterMyCurrentAddressAs(string currentAddress)
        {
            _textBoxPage.SendKeysToElement(_textBoxPage.CurrentAdressInput, currentAddress);
        }

        [When(@"i Enter my Permanent address as '(.*)'")]
        public void WhenIEnterMyPermanentAddressAs(string permanentAddress)
        {
            _textBoxPage.SendKeysToElement(_textBoxPage.PermanentAdressInput, permanentAddress);
        }

        [Then(@"i see my details displayed")]
        public void ThenISeeMyDetailsDisplayed()
        {
            _waitHelper.WaitForElementToBeVisible(driver,_textBoxPage.OutPutWindows);
            _textBoxPage.IsElementDisplayed(_textBoxPage.OutPutWindows);
        }

        [When(@"I send '(.*)' to '(.*)' ")]
        public void WhenISendKeysToField(string keys, IWebElement element)
        {
            _textBoxPage.ClearTextBoxElement(element);
            _textBoxPage.SendKeysToElement(element,keys);
        }
       
    }
}
