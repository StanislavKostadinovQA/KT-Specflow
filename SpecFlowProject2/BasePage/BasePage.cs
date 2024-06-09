using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SpecFlowProject2.BasePage
{
    public abstract class BasePage
    {
        private static IWebDriver driver;
        private static WaitHelper.WaitHelper _waitHelper;

        public BasePage()
        {
            GetDriver();
            _waitHelper = new WaitHelper.WaitHelper();
        }

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                driver = DriverManager.GetDriver();
            }

            return driver;
        }
        
        public abstract IWebElement ReturnElement(string elementName);

        public static IWebElement ReturnElement(IWebElement elementName)
        {
            return elementName;
        }

        public void NavigateTo(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public bool IsElementDisplayed(IWebElement elementName)
        {
            try
            {
                _waitHelper.WaitForElementToBeVisible(driver, elementName);
                return elementName.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public void ClearTextBoxElement(IWebElement element) => element.Clear();


        public void ClickElement(string element)
        {
            var webElement = ReturnElement(element);
            _waitHelper.WaitForElementToBeClickable(driver, webElement);
            webElement.Click();
        }

        // Need refactor
        public void ClickOnElementWithText(string elementName)
        {
            var webElement = ReturnElement(elementName);
            _waitHelper.WaitForElementToBeVisible(driver, webElement);
            ScrollIntoView(elementName);
            ClickElement(elementName);
        }

        public void SendKeysToElement(IWebElement element, string keys)
        {
            ClearTextBoxElement(element);
            foreach (char c in keys)
            {
                element.SendKeys(c.ToString());
                Thread.Sleep(20);
            }
        }

        public string GetElementText(IWebElement element) => ReturnElement(element).Text;

        public void ScrollIntoView(string element)
        {
            var webElement = ReturnElement(element);
            _waitHelper.WaitForElementToBeVisible(driver,webElement);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
        }

        public bool IsConsentButtonVisible(IWebDriver driver)
        {
            try
            {
                IWebElement consentButton = driver.FindElement(By.Id("consent-button"));
                return consentButton.Displayed && consentButton.Enabled;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void ClickButtonBasedOnType(string elementName)
        {
            var webElement = ReturnElement(elementName);

            if (webElement != null)
            {
                Actions actions = new Actions(driver);

                switch (elementName)
                {
                    case "DoubleClickButton":
                        actions.DoubleClick(webElement).Build().Perform();
                        break;
                    case "RightClickButton":
                        actions.ContextClick(webElement).Build().Perform();
                        break;
                    case "ClickMeButton":
                        ScrollUp(200);
                        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                        wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
                        webElement.Click();
                        break;
                    default:
                        throw new NotSupportedException("Unsupported button type.");
                }
            }
            else
            {
                throw new NotFoundException($"Button with identifier '{elementName}' not found.");
            }
        }

        public bool DoesElementContainText(string elementName, string textToFind)
        {
            var webElement = ReturnElement(elementName);
            string elementText = webElement.Text;
            return elementText.Contains(textToFind);
        }

        public bool TextIsNotDisplayed(string element,string text) {
            var webElement = ReturnElement(element);
            string elementText = webElement.Text;
            return !elementText.Contains(text);
        }

        public static void ScrollUp(int pixelsToScroll)
        {
            if (driver == null)
            {
                throw new InvalidOperationException("WebDriver is null.");
            }

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0, -" + pixelsToScroll + ")");
        }

        public void ScrollToCenter()
        {
            if (driver == null)
            {
                throw new InvalidOperationException("WebDriver is null.");
            }

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            long viewportHeight = (long)js.ExecuteScript("return window.innerHeight || document.documentElement.clientHeight || document.body.clientHeight;");
            long centerY = viewportHeight / 2;
            js.ExecuteScript($"window.scrollTo(0, {centerY});");
        }

    }
}