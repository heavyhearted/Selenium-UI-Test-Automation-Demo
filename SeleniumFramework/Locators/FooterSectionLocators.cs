using OpenQA.Selenium;

namespace SeleniumFramework.Locators;

public class FooterSectionLocators
{
    public By Logo => By.CssSelector("footer a[href='https://ultimateqa.com/']");
    public By CopyrightText => By.CssSelector("footer .footer-copyright");
    public By TermsAndConditionsLink => By.CssSelector("footer a[href='https://courses.ultimateqa.com/pages/terms']");
    public By PrivacyPolicyLink => By.CssSelector("footer a[href='https://courses.ultimateqa.com/pages/privacy']");
}
