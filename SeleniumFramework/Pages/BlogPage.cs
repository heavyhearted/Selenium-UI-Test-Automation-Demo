using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SeleniumFramework.CoreFramework;
using SeleniumFramework.CoreFramework.Utilities;
using SeleniumFramework.Locators;

namespace SeleniumFramework.Pages;

public class BlogPage : BasePage
{
    private readonly BlogPageLocators _locators;
    
    public const string MainSectionTitle = "Blog Our latest tech discussions!";

    public BlogPage(IWebDriver driver)
    
        : base(driver)
    {
        _locators = new BlogPageLocators();
    }

    public override void Open()
    {
        Driver.Navigate().GoToUrl(WebAppUrls.BlogPageUrl);
    }

    public override string GetMainSectionTitle()
    {
        var titleContainer = Wait.Until(ExpectedConditions.ElementIsVisible(_locators.CombinedTitleContainer));
        return titleContainer.Text.Replace("\n", " ").Trim();
    }

    public bool IsTopComponentVisible()
    {
        var topComponent = Wait.Until(ExpectedConditions.ElementIsVisible(_locators.TopComponent));
        return topComponent.Displayed;
    }

    public bool IsSearchBarVisible()
    {
        var searchBar = Wait.Until(ExpectedConditions.ElementIsVisible(_locators.SearchBar));
        return searchBar.Displayed;
    }

    public void SearchForArticle(string searchInput)
    {
        var searchBar = Wait.Until(ExpectedConditions.ElementIsVisible(_locators.SearchBar));
        searchBar.Clear();
        searchBar.SendKeys(searchInput);

        var searchButton = Wait.Until(ExpectedConditions.ElementToBeClickable(_locators.SearchButton));
        searchButton.Click();
        
        var expectedUrl = WebAppUrlValidationHelper.GenerateSearchUrl(searchInput);
        Wait.Until(driver => driver.Url.StartsWith(expectedUrl, StringComparison.OrdinalIgnoreCase));
    }

    public bool IsArticlesSectionVisible()
    {
        var articlesSection = Wait.Until(ExpectedConditions.ElementIsVisible(_locators.ArticlesSection));
        return articlesSection.Displayed;
    }

    public bool AreArticlesPresent()
    {
        var articles = Driver.FindElements(_locators.ArticleItem);
        return articles.Count > 0;
    }
}