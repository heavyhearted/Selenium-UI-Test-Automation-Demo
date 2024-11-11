using OpenQA.Selenium;

namespace SeleniumFramework.Locators;

public class BlogPageLocators
{
    public By CombinedTitleContainer => By.CssSelector(".et_pb_text_inner");  
    public By TopComponent => By.CssSelector(".et_pb_row.et_pb_row_0.banner-row");  
    public By SearchBar => By.CssSelector("input.et_pb_s"); 
    public By SearchButton => By.CssSelector("input.et_pb_searchsubmit");  
    public By ArticlesSection => By.CssSelector(".et_pb_row.et_pb_row_2");  
    public By ArticleItem => By.CssSelector(".et_pb_post");
}
