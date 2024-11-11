using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SeleniumFramework.CoreFramework;
using SeleniumFramework.Locators;
using SeleniumFramework.Sections;

namespace SeleniumFramework.Pages
{
    public class HomePage : BasePage
    {
        private readonly HomePageLocators _locators;  
        private readonly HeaderSection _headerSection;
        private readonly FooterSection _footerSection;
        
        public const string PageTitle = "Push Higher Quality Software To Market Faster";

        public HomePage(IWebDriver driver)
            : this(driver, new HomePageLocators())
        {
        }

        public HomePage(IWebDriver driver, HomePageLocators locators)
            : base(driver)
        {
            _locators = locators;
            _headerSection = new HeaderSection(driver); 
            _footerSection = new FooterSection(driver);
        }
        
        public override void Open()
        {
            Driver.Navigate().GoToUrl(WebAppTestUrls.HomePageUrl); 
        }
        
        public string GetMainTitleText()
        {
            var titleElement = Wait.Until(ExpectedConditions.ElementIsVisible(_locators.MainTitle));
            return titleElement.Text;
        }

        public bool IsHeaderLogoVisible() => _headerSection.IsHeaderLogoVisible();
        
        public bool IsFooterLogoVisible() => _footerSection.IsFooterLogoVisible();
        
        public string GetCopyrightText() => _footerSection.GetCopyrightText(); 
        
        public bool IsTermsAndConditionsVisible() => _footerSection.IsTermsAndConditionsVisible();
    
        public void ClickTermsAndConditions() => _footerSection.ClickTermsAndConditions();
    
        public bool IsPrivacyPolicyVisible() => _footerSection.IsPrivacyPolicyVisible();
    
        public void ClickPrivacyPolicy() => _footerSection.ClickPrivacyPolicy();
    }
}