using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowProject2.WaitHelper
{
    public  class WaitHelper
    {
        private  int DEFAULT_WAIT_TIME_SECONDS = 30;

        public void WaitForElementToBeVisible(IWebDriver driver, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(DEFAULT_WAIT_TIME_SECONDS));
            wait.Until(driver => element.Displayed && element.Enabled);
        }
        public void WaitForElementToBeClickable(IWebDriver driver, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(DEFAULT_WAIT_TIME_SECONDS));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public void WaitForPageToLoad(IWebDriver driver, int timeoutInSeconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

    }
}
