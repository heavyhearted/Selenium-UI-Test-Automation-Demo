using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumFramework.Pages;

public class BasePage
{
    protected readonly IWebDriver Driver;
    protected readonly DefaultWait<IWebDriver> Wait;

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
    }
}