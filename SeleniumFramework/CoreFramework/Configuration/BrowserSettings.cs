using SeleniumFramework.CoreFramework.Enums;

namespace SeleniumFramework.CoreFramework.Configuration;

public class BrowserSettings
{
    public BrowserType BrowserType { get; set; }

    public List<string> Arguments { get; set; } = new();
    
    public Dictionary<string, object> AdditionalCapabilities { get; set; } = new();
}