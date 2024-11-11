using OpenQA.Selenium;

namespace SeleniumFramework.Locators;

public class SampleAppPageLocators
{
    public By MainTitle => By.CssSelector("h1.entry-title.main_title");
    public By FirstNameInput => By.Name("firstname");
    public By LastNameInput => By.Name("lastname");
    public By SubmitButton => By.CssSelector("input[type='submit']");
    public By MaleRadioButton => By.CssSelector("input[name='gender'][value='male']");
    public By FemaleRadioButton => By.CssSelector("input[name='gender'][value='female']");
    public By OtherRadioButton => By.CssSelector("input[name='gender'][value='other']");

}