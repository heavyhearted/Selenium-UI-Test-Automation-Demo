using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumFramework.Locators;

namespace SeleniumFramework.Sections
{
    public class HeaderSection
    {
        private readonly IWebDriver _driver;
        private readonly HeaderSectionLocators _locators;
        private readonly WebDriverWait _wait;

        public HeaderSection(IWebDriver driver)
        {
            _driver = driver;
            _locators = new HeaderSectionLocators();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5))
            {
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };
        }

        public bool IsHeaderLogoVisible()
        {
            try
            {
                var logoElement = _wait.Until(ExpectedConditions.ElementIsVisible(_locators.Logo));
                return logoElement.Displayed; 
            }
            catch (WebDriverTimeoutException)
            {
                return false; 
            }
        }
    }
}