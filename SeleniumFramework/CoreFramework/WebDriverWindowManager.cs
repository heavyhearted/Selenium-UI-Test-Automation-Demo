using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumFramework.CoreFramework;

public static class WebDriverWindowManager
{
    public static void WaitForWindows(this IWebDriver driver, int numberOfWindows, int timeoutInSeconds = 5)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        wait.Until(d => d.WindowHandles.Count == numberOfWindows);
    }
    
    public static void SwitchToNewWindow(this IWebDriver driver, int expectedWindowsCount = 2, int timeoutInSeconds = 5)
    {
        driver.WaitForWindows(expectedWindowsCount, timeoutInSeconds);
        var newWindowHandle = driver.WindowHandles.Last();
        driver.SwitchTo().Window(newWindowHandle);
    }
}