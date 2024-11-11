using FluentAssertions;
using OpenQA.Selenium;
using SeleniumFramework.CoreFramework;
using SeleniumFramework.CoreFramework.Utilities;
using SeleniumFramework.Pages;

namespace SeleniumFramework.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class BlogPageTests
{
    private WebDriverFactory _webDriverFactory;
    private IWebDriver _driver;
    private BlogPage _blogPage;

    [SetUp]
    public void Setup()
    {
        _webDriverFactory = new WebDriverFactory();
        _driver = _webDriverFactory.GetWebDriver();
        _blogPage = new BlogPage(_driver);
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
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
        var actualUrl = _driver.Url;
        actualUrl.Should().Be(expectedUrl);
        _blogPage.AreArticlesPresent().Should().BeTrue();
    }
}