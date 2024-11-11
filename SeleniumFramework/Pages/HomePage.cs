using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SeleniumFramework.Locators;
using SeleniumFramework.Sections;
using static SeleniumFramework.CoreFramework.TestUrlConstants;

namespace SeleniumFramework.Pages
{
    public class HomePage : BasePage
    {
        private const string PageUnderTestUrl = HomePageUrl;
        private readonly HomePageLocators _locators;  
        private readonly HeaderSection _headerSection;
        private readonly FooterSection _footerSection;

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
        
        public void Open()
        {
            Driver.Navigate().GoToUrl(PageUnderTestUrl); 
        }
        
        public bool IsHeaderLogoVisible() => _headerSection.IsHeaderLogoVisible();
        
        public bool IsFooterLogoVisible() => _footerSection.IsFooterLogoVisible();
        
        public string GetCopyrightText() => _footerSection.GetCopyrightText(); 
        
        public FooterSection FooterSection => _footerSection;
        
    }
}