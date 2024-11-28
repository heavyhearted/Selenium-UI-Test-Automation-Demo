using FluentAssertions;
using OpenQA.Selenium;
using SeleniumFramework.CoreFramework;
using SeleniumFramework.Pages;

namespace SeleniumFramework.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class ServicesPageTests : BaseTest
{
    private ServicesPage _servicesPage;
    
    [SetUp]
    public void Setup()
    {
        _servicesPage = new ServicesPage(Driver);
    }
    
    [Test]
    public void ServicesPage_HeroSection_ShouldContainExpectedElements()
    {
        _servicesPage.Open();
        
        var servicesPageTitle = _servicesPage.GetMainSectionTitle();
        servicesPageTitle.Should().Be(ServicesPage.PageTitle);
        
        _servicesPage.IsHeroSectionVisible().Should().BeTrue();
        var heroSectionText = _servicesPage.GetHeroSectionText();
        heroSectionText.Should().Be(ServicesPage.HeroSectionText);
        
        _servicesPage.IsHeroImageVisible().Should().BeTrue();
        var heroImageSrc = _servicesPage.GetHeroImageSrc();
        heroImageSrc.Should().Contain("Header.png"); 
        
        _servicesPage.IsDiscoverySessionButtonVisible().Should().BeTrue();
        var scheduleSessionButtonText = _servicesPage.GetDiscoverySessionButtonText();
        scheduleSessionButtonText.Should().Be(ServicesPage.DiscoverySessionButtonText);
    }
    
    
    [Test]
    public void ServicesPage_ProfessionalServicesSection_ShouldContainExpectedCards()
    {
        _servicesPage.Open();

        foreach (var card in ServicesPage.ExpectedCards)
        {
            var expectedTitle = card.Key;
            var expectedDescription = card.Value;

            _servicesPage.IsServiceCardVisible(expectedTitle).Should().BeTrue();
            
            var actualTitle = _servicesPage.GetServiceCardTitleText(expectedTitle);
            actualTitle.Should().Be(expectedTitle);

            var actualDescription = _servicesPage.GetServiceCardDescriptionText(expectedTitle);
            actualDescription.Should().Contain(expectedDescription);
        }
    }
    
    [Test]
    public void ServicesPage_DiscoverySessionButton_ShouldRedirectToCorrectUrl()
    {
        _servicesPage.Open();
    
        _servicesPage.IsDiscoverySessionButtonVisible().Should().BeTrue();

        _servicesPage.ClickDiscoverySessionButton();
        
        Driver.SwitchToNewWindow(ServicesPage.DiscoveryButtonRedirectUrl);

        Driver.Url.Should().Be(ServicesPage.DiscoveryButtonRedirectUrl);
    }
}