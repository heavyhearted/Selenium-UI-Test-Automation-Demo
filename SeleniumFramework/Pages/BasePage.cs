using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumFramework.Sections;

namespace SeleniumFramework.Pages;

public abstract class BasePage
{
    protected readonly IWebDriver Driver;
    protected readonly DefaultWait<IWebDriver> Wait;
    private readonly HeaderSection _headerSection;
    private readonly FooterSection _footerSection;

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;

        Wait = new DefaultWait<IWebDriver>(Driver)
        {
            Timeout = TimeSpan.FromSeconds(5),
            PollingInterval = TimeSpan.FromMilliseconds(500)
        };

        Wait.IgnoreExceptionTypes(
            typeof(NoSuchElementException), 
            typeof(StaleElementReferenceException));
        
        _headerSection = new HeaderSection(driver); 
        _footerSection = new FooterSection(driver);
    }
    
    public abstract void Open();
    
    public bool IsHeaderLogoVisible() => _headerSection.IsHeaderLogoVisible();
        
    public bool IsFooterLogoVisible() => _footerSection.IsFooterLogoVisible();
        
    public string GetCopyrightText() => _footerSection.GetCopyrightText(); 
        
    public bool IsTermsAndConditionsVisible() => _footerSection.IsTermsAndConditionsVisible();
    
    public void ClickTermsAndConditions() => _footerSection.ClickTermsAndConditions();
    
    public bool IsPrivacyPolicyVisible() => _footerSection.IsPrivacyPolicyVisible();
    
    public void ClickPrivacyPolicy() => _footerSection.ClickPrivacyPolicy();
}