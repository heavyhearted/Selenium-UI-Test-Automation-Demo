using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SeleniumFramework.Locators;
using static SeleniumFramework.CoreFramework.TestUrlConstants;

namespace SeleniumFramework.Pages;

public class SampleAppPage : BasePage
{
    private const string PageUnderTestUrl = $"{BaseUrl}{SampleApplicationLifecyclePath}";
    
    private readonly SampleAppPageLocators _locators;
    
    public SampleAppPage(IWebDriver driver)
        : this(driver, new SampleAppPageLocators())
    {
    }
    
    public SampleAppPage(IWebDriver driver, SampleAppPageLocators locators)
        : base(driver)
    {
        _locators = locators;
    }

    public void Open()
    {
        Driver.Navigate().GoToUrl(PageUnderTestUrl); 
    }
    
    public string GetPageTitle()
    {
        var titleElement = Wait.Until
            (ExpectedConditions.ElementIsVisible(_locators.MainTitle)); 
        return titleElement.Text;
    }

    public void FillOutFormAndSubmit(string firstName, string lastName)
    {
        var firstNameInput = Wait.Until
            (ExpectedConditions.ElementIsVisible(_locators.FirstNameInput));
        firstNameInput.SendKeys(firstName);
        
        var lastNameInput = Wait.Until
            (ExpectedConditions.ElementIsVisible(_locators.LastNameInput));
        lastNameInput.SendKeys(lastName);
        
        var submitButton = Wait.Until
            (ExpectedConditions.ElementToBeClickable(_locators.SubmitButton));
        submitButton.Click();
    }
    
    public void SelectGender(string gender)
    {
        var genderLocators = new Dictionary<string, By>
        {
            { "male", _locators.MaleRadioButton },
            { "female", _locators.FemaleRadioButton },
            { "other", _locators.OtherRadioButton }
        };

        var genderButton = Wait.Until
            (ExpectedConditions.ElementToBeClickable(genderLocators[gender.ToLower()]));
        genderButton.Click();
    }
}
 