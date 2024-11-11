using Bogus;
using FluentAssertions;
using OpenQA.Selenium;
using SeleniumFramework.CoreFramework;
using SeleniumFramework.Pages;

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
    public void ApplicationForm_IsSuccessfullySubmitted(GenderType gender)
    {
        _sampleAppPage.Open();
        
        var samplePageTitle = _sampleAppPage.GetPageTitle();
        samplePageTitle.Should().Be(SampleAppPage.PageTitle);
        
        var testUser = new TestUser(_faker.Name.FirstName(), _faker.Name.LastName(), gender);
        
        _sampleAppPage.SelectGender(testUser.Gender.ToString()); 
        _sampleAppPage.FillOutFormAndSubmit(testUser.FirstName, testUser.LastName);
        
        var currentUrl = _driver.Url;
        currentUrl.Should().Be($"https://ultimateqa.com/?gender={testUser.Gender.ToString().ToLower()}&firstname={testUser.FirstName}&lastname={testUser.LastName}");
        
        var pageRedirectedAfterSubmission = _homePage.GetMainTitleText();
        pageRedirectedAfterSubmission.Should().Be(HomePage.PageTitle);
    }
}