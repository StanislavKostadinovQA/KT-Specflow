using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowBDDAutomationFramework.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer _container;
        private IWebDriver driver;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }
      
        [BeforeScenario(Order = 1)]
        public void BeforeScenario()
        {
            // Initialize ChromeDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
