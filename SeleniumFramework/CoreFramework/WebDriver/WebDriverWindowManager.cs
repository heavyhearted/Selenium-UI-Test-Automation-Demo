using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumFramework.CoreFramework;

public static class WebDriverWindowManager
{
    private static void WaitForWindows(this IWebDriver driver, 
        int numberOfWindows, int timeoutInSeconds = 5)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        wait.Until(d => d.WindowHandles.Count == numberOfWindows);
    }
    
    public static void SwitchToNewWindow(this IWebDriver driver, 
        string expectedUrl, int expectedWindowsCount = 2, int timeoutInSeconds = 10)
    {
        driver.WaitForWindows(expectedWindowsCount, timeoutInSeconds);
        var newWindowHandle = driver.WindowHandles.Last();
        driver.SwitchTo().Window(newWindowHandle);
        
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        wait.Until(d => d.Url == expectedUrl);
    }
}