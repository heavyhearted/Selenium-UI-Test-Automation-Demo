using FluentAssertions;
using OpenQA.Selenium;
using SeleniumFramework.CoreFramework;
using SeleniumFramework.Pages;

namespace SeleniumFramework.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class AboutPageTests : BaseTest
{
    private AboutPage _aboutPage;

    [SetUp]
    public void Setup()
    {
        _aboutPage = new AboutPage(Driver);
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