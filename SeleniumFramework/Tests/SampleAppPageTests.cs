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
public class SampleAppPageTests : BaseTest
{
    private SampleAppPage _sampleAppPage;
    private HomePage _homePage;
    private Faker _faker;

    [SetUp]
    public void Setup()
    {
        _sampleAppPage = new SampleAppPage(Driver);
        _homePage = new HomePage(Driver);
        
        _faker = new Faker();
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
        var currentUrl = Driver.Url;
        currentUrl.Should().Be(expectedUrl);
        
        var pageRedirectedAfterSubmission = _homePage.GetMainSectionTitle();
        pageRedirectedAfterSubmission.Should().Be(HomePage.PageTitle);
    }
}