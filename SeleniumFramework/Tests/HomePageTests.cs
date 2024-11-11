using FluentAssertions;
using OpenQA.Selenium;
using SeleniumFramework.CoreFramework;
using SeleniumFramework.Pages;
using SeleniumFramework.Sections;

namespace SeleniumFramework.Tests;

[TestFixture] 
[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class HomePageTests
{
    private IWebDriver _driver;
    private HomePage _homePage;
    private WebDriverFactory _webDriverFactory;
    
    [SetUp]
    public void Setup()
    {
        _webDriverFactory = new WebDriverFactory();
        _driver = _webDriverFactory.GetWebDriver();
        _homePage = new HomePage(_driver);
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit(); 
        _driver.Dispose(); 
    }
    
    [Test]
    public void HeaderLogo_ShouldBeVisible_OnHomePage()
    {
        _homePage.Open();

        _homePage.IsHeaderLogoVisible().Should().BeTrue();
    }
    
    
    [Test]
    public void FooterLogo_ShouldBeVisible_OnHomePage()
    {
        _homePage.Open();
        
        _homePage.IsFooterLogoVisible().Should().BeTrue();
    }
    
    [Test]
    public void CopyrightText_ShouldBePresent()
    {
        _homePage.Open();
        var copyrightText = _homePage.GetCopyrightText(); 
        copyrightText.Should().Contain(FooterSection.CopyrightText); 
    }

    [Test]
    public void TermsOfUse_ShouldBeVisible_AndHasCorrectRedirect()
    {
        _homePage.Open();
        
        _homePage.IsTermsAndConditionsVisible().Should().BeTrue();
        
        _homePage.ClickTermsAndConditions();
        
        _driver.SwitchToNewWindow();
        
        _driver.Url.Should().Be(WebAppTestUrls.TermsOfUseUrl); 
    }

    [Test]
    public void PrivacyPolicy_ShouldBeVisible_AndHasCorrectRedirect()
    {
        _homePage.Open();
        
        _homePage.IsPrivacyPolicyVisible().Should().BeTrue();
        
        _homePage.ClickPrivacyPolicy();
        
        _driver.SwitchToNewWindow();
        
        _driver.Url.Should().Be(WebAppTestUrls.PrivacyPolicyUrl); 
    }
    

}