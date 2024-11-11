using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SeleniumFramework.CoreFramework.Configuration;
using SeleniumFramework.CoreFramework.Enums;

namespace SeleniumFramework.CoreFramework
{
    public class WebDriverFactory : IDisposable
    {
        private readonly BrowserSettings _browserSettings;
        private IWebDriver _driver;

        public WebDriverFactory()
        {
            var browserEnvironment = Environment.GetEnvironmentVariable("BROWSER_ENVIRONMENT") ?? "Chrome";
            
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(string.Format(SettingsConstants.SettingsFileName, browserEnvironment), true)
                .AddEnvironmentVariables()
                .Build();
            
            _browserSettings = configuration
                .GetSection(SettingsConstants.BrowserSettingsSection)
                .Get<BrowserSettings>()!;
            
            if (Enum.TryParse(configuration["BrowserSettings:BrowserType"], ignoreCase: true, out BrowserType parsedBrowserType))
            {
                _browserSettings.BrowserType = parsedBrowserType;
            }
            else
            {
                throw new ArgumentException($"Browser '{configuration["BrowserType"]}' is not valid.");
            }
        }

        public IWebDriver GetWebDriver()
        {
            _driver = _browserSettings.BrowserType switch
            {
                BrowserType.Chrome => new ChromeDriver(GetChromeOptions()),
                BrowserType.Firefox => new FirefoxDriver(GetFirefoxOptions()),
                BrowserType.Edge => new EdgeDriver(GetEdgeOptions()),
                BrowserType.Safari => throw new NotSupportedException("Safari is currently not supported."),
                _ => throw new ArgumentException($"Browser '{_browserSettings.BrowserType}' is not supported.")
            };
            return _driver;
        }
        
        private ChromeOptions GetChromeOptions()
        {
            var options = new ChromeOptions();
            
            options.AddArguments(_browserSettings.Arguments);

            foreach (var additionalCapability in _browserSettings.AdditionalCapabilities)
            {
                options.AddAdditionalOption(additionalCapability.Key, additionalCapability.Value);
            }
            
            return options;
        }

        private FirefoxOptions GetFirefoxOptions()
        {
            var options = new FirefoxOptions();
            
            options.AddArguments(_browserSettings.Arguments);

            foreach (var additionalCapability in _browserSettings.AdditionalCapabilities)
            {
                options.AddAdditionalOption(additionalCapability.Key, additionalCapability.Value);
            }
            
            return options;
        }

        private EdgeOptions GetEdgeOptions()
        {
            var options = new EdgeOptions();
            
            options.AddArguments(_browserSettings.Arguments);

            foreach (var additionalCapability in _browserSettings.AdditionalCapabilities)
            {
                options.AddAdditionalOption(additionalCapability.Key, additionalCapability.Value);
            }
            
            return options;
        }
        
        public void Dispose()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}