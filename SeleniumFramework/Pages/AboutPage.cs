using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SeleniumFramework.CoreFramework.Utilities;
using SeleniumFramework.Locators;

namespace SeleniumFramework.Pages;

public class AboutPage : BasePage
{
    private readonly AboutPageLocators _locators;

    public const string PageTitle = "We elevate the way the world creates technology!";
    public const string PeopleTrainedDescriptionText = "World’s most passionate and experienced automation trainers!";
    public const string ClientsBenefitedDescriptionText = "World’s top automation consultants!";
    public const string MapSectionTitleText = "We ♥ Automated Testing";

    public AboutPage(IWebDriver driver)
        : base(driver)
    {
        _locators = new AboutPageLocators();
    }

    public override void Open()
    {
        Driver.Navigate().GoToUrl(WebAppUrls.AboutPageUrl);
    }

    public override string GetMainSectionTitle()
    {
        var titleElement = Wait.Until(ExpectedConditions.ElementIsVisible(_locators.MainSectionTitle));
        return titleElement.Text;
    }
    

    public bool IsMapVisible()
    {
        var mapElement = Wait.Until(ExpectedConditions.ElementIsVisible(_locators.MapImage));
        return mapElement.Displayed;
    }


    public bool IsPeopleTrainedTitleVisible()
    {
        var titleElement = Wait.Until(ExpectedConditions.ElementIsVisible(_locators.PeopleTrainedTitle));
        return titleElement.Displayed;
    }

    public string GetPeopleTrainedDescription()
    {
        var descriptionElement = Wait.Until(ExpectedConditions.ElementIsVisible(_locators.PeopleTrainedDescription));
        return descriptionElement.Text;
    }

    public bool IsClientsBenefitedTitleVisible()
    {
        var titleElement = Wait.Until(ExpectedConditions.ElementIsVisible(_locators.ClientsBenefitedTitle));
        return titleElement.Displayed;
    }

    public string GetClientsBenefitedDescription()
    {
        var descriptionElement = Wait.Until(ExpectedConditions.ElementIsVisible(_locators.ClientsBenefitedDescription));
        return descriptionElement.Text;
    }
    
    public bool IsMapSectionTitleCorrect()
    {
        var titleElement = Wait.Until(ExpectedConditions.ElementIsVisible(_locators.MapSectionTitle));
        return titleElement.Text == MapSectionTitleText;
    }
}