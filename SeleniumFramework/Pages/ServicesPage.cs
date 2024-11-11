using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SeleniumFramework.CoreFramework;
using SeleniumFramework.CoreFramework.Utilities;
using SeleniumFramework.Locators;

namespace SeleniumFramework.Pages;

public class ServicesPage : BasePage
{
    private readonly ServicesPageLocators _locators;
    
    public const string PageTitle = "World'S Best Test Automation Solutions";
    public const string HeroSectionText = "Poor software quality can be the exception rather than the norm. UltimateQA’s automated QA testing saves time and money and protects a company’s reputation for the fast, flawless delivery of IT that actually works.";
    public const string DiscoverySessionButtonText = "SCHEDULE A FREE DISCOVERY SESSION";
    public static readonly Dictionary<string, string> ExpectedCards = new()
    {
        { "Automation Program Creation", "Choose UltimateQA for Automation Program Creation to leverage their expertise in customized, efficient QA test automation solutions, proven to enhance software team efficiency and company profitability." },
        { "Framework Assessment", "Ensure the robustness and scalability of your test automation framework with our in-depth Framework Assessment service." },
        { "Test Strategy Consultation", "Crafting a successful testing strategy is a cornerstone of software development." },
        { "Test Automation Training", "Empower your team with the latest skills and knowledge in test automation through our specialized training programs." },
        { "Web, Mobile & API Automation", "At UltimateQA, we specialize in automating web, mobile, and API testing to enhance software quality and efficiency." },
        { "Web Development", "Beyond testing, we offer top-notch Web Development services to bring your digital vision to life." }
    };
    
    public ServicesPage(IWebDriver driver)
        : this(driver, new ServicesPageLocators())
    {
    }

    public ServicesPage(IWebDriver driver, ServicesPageLocators locators)
        : base(driver)
    {
        _locators = locators;
    }

    public override void Open()
    {
        Driver.Navigate().GoToUrl(WebAppUrls.ServicesPageUrl);
    }
    
    public override string GetMainSectionTitle()
    {
        var titleElement = Wait.Until(ExpectedConditions.ElementIsVisible(_locators.MainTitle));
        return titleElement.Text;
    }

    public bool IsHeroSectionVisible()
    {
        var heroSection = Wait.Until(ExpectedConditions.ElementIsVisible(_locators.InnerText));
        return heroSection.Displayed;
    }

    public string GetHeroSectionText()
    {
        var heroTextElement = Wait.Until(ExpectedConditions.ElementIsVisible(_locators.InnerText));
        return heroTextElement.Text;
    }

    public bool IsDiscoverySessionButtonVisible()
    {
        var button = Wait.Until(ExpectedConditions.ElementIsVisible(_locators.DiscoverySessionButton));
        return button.Displayed;
    }

    public string GetDiscoverySessionButtonText()
    {
        var button = Wait.Until(ExpectedConditions.ElementIsVisible(_locators.DiscoverySessionButton));
        return button.Text;
    }
    
    public void ClickDiscoverySessionButton()
    {
        var button = Wait.Until(ExpectedConditions.ElementToBeClickable(_locators.DiscoverySessionButton));
        button.Click();
    }

    public bool IsHeroImageVisible()
    {
        var image = Wait.Until(ExpectedConditions.ElementIsVisible(_locators.HeroImage));
        return image.Displayed;
    }

    public string GetHeroImageSrc()
    {
        var image = Wait.Until(ExpectedConditions.ElementIsVisible(_locators.HeroImage));
        return image.GetAttribute("src");
    }
    
    public bool IsServiceCardVisible(string title)
    {
        var serviceCard = Wait.Until(ExpectedConditions.ElementIsVisible(_locators.ServiceCardContainerByTitle(title)));
        return serviceCard.Displayed;
    }
    
    public string GetServiceCardTitleText(string title)
    {
        var titleElement = Wait.Until(ExpectedConditions.ElementIsVisible(_locators.ServiceCardTitleText(title)));
        return titleElement.Text;
    }

    public string GetServiceCardDescriptionText(string description)
    {
        var descriptionElement = Wait.Until(ExpectedConditions.ElementIsVisible(_locators.ServiceCardDescriptionText(description)));
        return descriptionElement.Text;
    }
}