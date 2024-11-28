using OpenQA.Selenium;
using SeleniumFramework.CoreFramework;

namespace SeleniumFramework.Pages;

public abstract class BaseTest
{
    protected IWebDriver Driver;

    [SetUp]
    public void BaseSetup()
    {
        var webDriverFactory = new WebDriverFactory();
        Driver = webDriverFactory.GetWebDriver();
    }

    [TearDown]
    public void BaseTearDown()
    {
        Driver.Quit();
        Driver.Dispose();
    }
}