using OpenQA.Selenium;
using SpecFlowProject2.WaitHelper;
using TechTalk.SpecFlow;

namespace SpecFlowBDDAutomationFramework.Hooks
{
    [Binding]
    public class Hooks { 

        private static IWebDriver driver;
        private readonly WaitHelper _waitHelper;

        public Hooks()
        {
            driver = DriverManager.GetDriver();
            _waitHelper = new WaitHelper();
        }

        [BeforeScenario(Order = 1)]
        public void BeforeScenario()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/elements");
           _waitHelper.WaitForPageToLoad(driver);
            ClickConsentButton();
        }

        [AfterTestRun]
        public static void AfterTestRun() {

            driver.Close();
            driver.Dispose(); 
        }
        
        private void ClickConsentButton()
        {
                try
                {
                    IWebElement consentButton = driver.FindElement(By.XPath("//p[text()='Consent']"));
                    _waitHelper.WaitForElementToBeVisible(driver, consentButton);
                    consentButton.Click();
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("Consent button not found. Skipping click.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occurred while clicking consent button: {ex.Message}");
                }
        }
    }
}
