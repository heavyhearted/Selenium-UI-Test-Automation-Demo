using FluentAssertions;
using OpenQA.Selenium;
using SeleniumFramework.CoreFramework;
using SeleniumFramework.CoreFramework.Utilities;
using SeleniumFramework.Pages;

namespace SeleniumFramework.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class BlogPageTests : BaseTest
{
    private BlogPage _blogPage;

    [SetUp]
    public void Setup()
    {
        _blogPage = new BlogPage(Driver);
    }
    
    [Test]
    public void BlogPage_Content_ShouldContainExpectedElements()
    {
        _blogPage.Open();

        _blogPage.IsTopComponentVisible().Should().BeTrue();

        _blogPage.IsSearchBarVisible().Should().BeTrue();

        var actualTitle = _blogPage.GetMainSectionTitle();
        actualTitle.Should().Be(BlogPage.MainSectionTitle);

        _blogPage.IsArticlesSectionVisible().Should().BeTrue();
        
        _blogPage.AreArticlesPresent().Should().BeTrue();
    }
    


    [Test]
    public void BlogPage_SearchBar_ShouldRedirectAndReturnResults()
    {
        _blogPage.Open();
        
        string searchQuery = "Playwright";
        _blogPage.SearchForArticle(searchQuery);

        var expectedUrl = WebAppUrlValidationHelper.GenerateSearchUrl(searchQuery);
        var actualUrl = Driver.Url;
        actualUrl.Should().Be(expectedUrl);
        _blogPage.AreArticlesPresent().Should().BeTrue();
    }
}