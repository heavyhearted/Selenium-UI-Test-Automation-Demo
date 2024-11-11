using OpenQA.Selenium;

namespace SeleniumFramework.Locators;

public class ServicesPageLocators
{
    // Hero Section
    public By MainTitle => By.CssSelector("h1.et_pb_module_heading");
    public By DiscoverySessionButton => By.CssSelector(".et_pb_button_module_wrapper.et_pb_button_0_wrapper a");
    public By InnerText => By.CssSelector(".et_pb_text_inner .p1");
    public By HeroImage => By.CssSelector(".et_pb_image_wrap img");
    
    
    // Professional Services Section
    public By ServiceCardContainerByTitle(string title) => By.XPath($"//div[contains(@class, 'et_pb_blurb_content')]//span[text()='{title}']/ancestor::div[contains(@class, 'et_pb_blurb')]");
    
    public By ServiceCardTitleText(string title) => By.XPath($"//div[contains(@class, 'et_pb_blurb_content')]//span[text()='{title}']");  

    public By ServiceCardDescriptionText(string title) => By.XPath($"//div[contains(@class, 'et_pb_blurb_content')]//span[text()='{title}']/ancestor::div[contains(@class, 'et_pb_blurb')]//div[contains(@class, 'et_pb_blurb_description')]");
}
