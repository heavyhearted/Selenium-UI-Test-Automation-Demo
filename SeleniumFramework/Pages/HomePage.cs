using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SeleniumFramework.CoreFramework.Utilities;
using SeleniumFramework.Locators;

namespace SeleniumFramework.Pages
{
    public class HomePage : BasePage
    {
        private readonly HomePageLocators _locators;  
        
        public const string PageTitle = "Push Higher Quality Software To Market Faster";

        public HomePage(IWebDriver driver)
            : base(driver)
        {
            _locators = new HomePageLocators();
        }
        
        public override void Open()
        {
            Driver.Navigate().GoToUrl(WebAppUrls.HomePageUrl); 
        }
        
        public override string GetMainSectionTitle()
        {
            var titleElement = Wait.Until(ExpectedConditions.ElementIsVisible(_locators.MainTitle));
            return titleElement.Text;
        }
    }
}