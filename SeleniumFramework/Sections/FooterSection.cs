using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumFramework.Locators;

namespace SeleniumFramework.Sections
{
    public class FooterSection
    {
        private readonly IWebDriver _driver;
        private readonly FooterSectionLocators _locators;
        private readonly WebDriverWait _wait;
        
        public const string CopyrightText = "© NextLevel Solutions USA, LLC";

        public FooterSection(IWebDriver driver)
        {
            _driver = driver;
            _locators = new FooterSectionLocators();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5))
            {
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };
        }

        public bool IsFooterLogoVisible()
        {
            var logoElement = _wait.Until(ExpectedConditions.ElementIsVisible(_locators.Logo));
            return logoElement.Displayed; 
        }

        public string GetCopyrightText()
        {
            var copyrightElement = _wait.Until(ExpectedConditions.ElementIsVisible(_locators.CopyrightText));
            return copyrightElement.Text;
        }
        
        
        public bool IsTermsAndConditionsVisible()
        {
            var termsElement = _wait.Until(ExpectedConditions.ElementIsVisible(_locators.TermsAndConditionsLink));
            return termsElement.Displayed; 
        }

        public bool IsPrivacyPolicyVisible()
        {
            var privacyElement = _wait.Until(ExpectedConditions.ElementIsVisible(_locators.PrivacyPolicyLink));
            return privacyElement.Displayed; 
        }
        
        public void ClickTermsAndConditions()
        {
            var termsElement = _wait.Until(ExpectedConditions.ElementToBeClickable(_locators.TermsAndConditionsLink));
            termsElement.Click();
        }

        public void ClickPrivacyPolicy()
        {
            var privacyElement = _wait.Until(ExpectedConditions.ElementToBeClickable(_locators.PrivacyPolicyLink));
            privacyElement.Click();
        }
    }
}