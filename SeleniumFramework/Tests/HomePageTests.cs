using FluentAssertions;
using OpenQA.Selenium;
using SeleniumFramework.CoreFramework;
using SeleniumFramework.CoreFramework.Utilities;
using SeleniumFramework.Pages;
using SeleniumFramework.Sections;

namespace SeleniumFramework.Tests;

[TestFixture] 
[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class HomePageTests : BaseTest
{
    private HomePage _homePage;
    
    [SetUp]
    public void Setup()
    {
        _homePage = new HomePage(Driver);
    }
    
    [Test]
    public void HomePage_HeaderLogo_ShouldBeVisible_OnHomePage()
    {
        _homePage.Open();

        _homePage.IsHeaderLogoVisible().Should().BeTrue();
    }
    
    [Test]
    public void HomePage_Title_ShouldBeCorrect()
    {
        _homePage.Open();
    
        _homePage.GetMainSectionTitle().Should().Be(HomePage.PageTitle);
    }
    
    
    [Test]
    public void HomePage_FooterLogo_ShouldBeVisible_OnHomePage()
    {
        _homePage.Open();
        
        _homePage.IsFooterLogoVisible().Should().BeTrue();
    }
    
    [Test]
    public void HomePage_CopyrightText_ShouldBePresent()
    {
        _homePage.Open();
        var copyrightText = _homePage.GetCopyrightText(); 
        copyrightText.Should().Contain(FooterSection.CopyrightText); 
    }

    [Test]
    public void HomePage_TermsOfUse_ShouldBeVisible_AndHasCorrectRedirect()
    {
        _homePage.Open();
        
        _homePage.IsTermsAndConditionsVisible().Should().BeTrue();
        
        _homePage.ClickTermsAndConditions();
        
        Driver.SwitchToNewWindow(WebAppUrls.TermsOfUseUrl);
        
        Driver.Url.Should().Be(WebAppUrls.TermsOfUseUrl); 
    }

    [Test]
    public void HomePage_PrivacyPolicy_ShouldBeVisible_AndHasCorrectRedirect()
    {
        _homePage.Open();
        
        _homePage.IsPrivacyPolicyVisible().Should().BeTrue();
        
        _homePage.ClickPrivacyPolicy();
        
        Driver.SwitchToNewWindow(WebAppUrls.PrivacyPolicyUrl);
        
        Driver.Url.Should().Be(WebAppUrls.PrivacyPolicyUrl); 
    }
}