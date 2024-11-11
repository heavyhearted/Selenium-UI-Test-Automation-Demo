using System.Web;
using Bogus;
using FluentAssertions;
using OpenQA.Selenium;
using SeleniumFramework.CoreFramework;
using SeleniumFramework.CoreFramework.Enums;
using SeleniumFramework.CoreFramework.Models;
using SeleniumFramework.Pages;
using SeleniumFramework.Sections;
using static SeleniumFramework.CoreFramework.Utilities.WebAppUrlValidationHelper;

namespace SeleniumFramework.Tests;

[TestFixture] 
[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class SampleAppPageTests
{
    private WebDriverFactory _webDriverFactory;
    private IWebDriver _driver;
    private SampleAppPage _sampleAppPage;
    private HomePage _homePage;
    private Faker _faker;
    
    private string GenerateExpectedUrl(TestUser testUser)
    {
        var encodedFirstName = HttpUtility.UrlEncode(testUser.FirstName);
        var encodedLastName = HttpUtility.UrlEncode(testUser.LastName);
        return $"https://ultimateqa.com/?gender={testUser.Gender.ToString().ToLower()}&firstname={encodedFirstName}&lastname={encodedLastName}";
    }

    [SetUp]
    public void Setup()
    {
        _webDriverFactory = new WebDriverFactory();
        _driver = _webDriverFactory.GetWebDriver();
        
        _sampleAppPage = new SampleAppPage(_driver);
        _homePage = new HomePage(_driver);
        
        _faker = new Faker();
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit(); 
        _driver.Dispose(); 
    }
    
    [TestCase(GenderType.Male)]
    [TestCase(GenderType.Female)]
    [TestCase(GenderType.Other)]
    public void SampleAppPage_ApplicationForm_IsSuccessfullySubmitted(GenderType gender)
    {
        _sampleAppPage.Open();
        
        var samplePageTitle = _sampleAppPage.GetMainSectionTitle();
        samplePageTitle.Should().Be(SampleAppPage.PageTitle);
        
        var testUser = new TestUser(_faker.Name.FirstName(), _faker.Name.LastName(), gender);
        
        _sampleAppPage.SelectGender(testUser.Gender.ToString()); 
        _sampleAppPage.FillOutFormAndSubmit(testUser.FirstName, testUser.LastName);
        
        var expectedUrl = GenerateApplicationFormSubmissionUrl(testUser);
        var currentUrl = _driver.Url;
        currentUrl.Should().Be(expectedUrl);
        
        var pageRedirectedAfterSubmission = _homePage.GetMainSectionTitle();
        pageRedirectedAfterSubmission.Should().Be(HomePage.PageTitle);
    }
}