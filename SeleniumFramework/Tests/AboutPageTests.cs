using FluentAssertions;
using OpenQA.Selenium;
using SeleniumFramework.CoreFramework;
using SeleniumFramework.Pages;

namespace SeleniumFramework.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class AboutPageTests
{
    private WebDriverFactory _webDriverFactory;
    private IWebDriver _driver;
    private AboutPage _aboutPage;

    [SetUp]
    public void Setup()
    {
        _webDriverFactory = new WebDriverFactory();
        _driver = _webDriverFactory.GetWebDriver();

        _aboutPage = new AboutPage(_driver);
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
    }

    [Test]
    public void AboutPage_MainSection_ShouldContainExpectedText()
    {
        _aboutPage.Open();

        var mainSectionText = _aboutPage.GetMainSectionTitle();
        mainSectionText.Should().Contain(AboutPage.PageTitle);
    }

    [Test]
    public void AboutPage_Map_ShouldBeVisible()
    {
        _aboutPage.Open();

        _aboutPage.IsMapVisible().Should().BeTrue();
    }

    [Test]
    public void AboutPage_Statistics_ShouldContainExpectedTitlesAndDescriptions()
    {
        _aboutPage.Open();

        _aboutPage.IsPeopleTrainedTitleVisible().Should().BeTrue();
        var peopleTrainedText = _aboutPage.GetPeopleTrainedDescription();
        peopleTrainedText.Should().Contain(AboutPage.PeopleTrainedDescriptionText);

        _aboutPage.IsClientsBenefitedTitleVisible().Should().BeTrue();
        var clientsBenefitedText = _aboutPage.GetClientsBenefitedDescription();
        clientsBenefitedText.Should().Contain(AboutPage.ClientsBenefitedDescriptionText);

        _aboutPage.IsMapSectionTitleCorrect().Should().BeTrue();
    }
}