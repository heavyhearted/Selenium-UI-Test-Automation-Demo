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
    private IWebDriver _driver;
    private SampleAppPage _sampleAppPage;
    private WebDriverFactory _webDriverFactory;


    [SetUp]
    public void Setup()
    {
        _webDriverFactory = new WebDriverFactory();
        _driver = _webDriverFactory.GetWebDriver();
        _sampleAppPage = new SampleAppPage(_driver);
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
        samplePageTitle.Should().Be("Sample Application Lifecycle – Sprint 3");

        var faker = new Faker();
        var testUser = new TestUser(faker.Name.FirstName(), faker.Name.LastName(), gender);
        
        _sampleAppPage.SelectGender(testUser.Gender.ToString()); 
        _sampleAppPage.FillOutFormAndSubmit(testUser.FirstName, testUser.LastName);
        
        var currentUrl = _driver.Url;
        currentUrl.Should().Be($"https://ultimateqa.com/?gender={testUser.Gender.ToString().ToLower()}&firstname={testUser.FirstName}&lastname={testUser.LastName}");
    }
}