using OpenQA.Selenium;

namespace SeleniumFramework.Locators;

public class AboutPageLocators
{
    public By MainSectionTitle => By.CssSelector(".et_pb_text_inner h1 span");
    public By MapImage => By.CssSelector(".et_pb_image_wrap img");

    public By PeopleTrainedTitle => By.CssSelector(".et_pb_blurb_0 .et_pb_blurb_description h1");
    public By PeopleTrainedDescription => By.CssSelector(".et_pb_blurb_0 .et_pb_blurb_description p");

    public By ClientsBenefitedTitle => By.CssSelector(".et_pb_blurb_1 .et_pb_blurb_description h1");
    public By ClientsBenefitedDescription => By.CssSelector(".et_pb_blurb_1 .et_pb_blurb_description p");
    
    public By MapSectionTitle => By.CssSelector(".et_pb_text_1 .et_pb_text_inner h1");
}