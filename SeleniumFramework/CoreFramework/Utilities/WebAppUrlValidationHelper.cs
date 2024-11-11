using System.Web;
using SeleniumFramework.CoreFramework.Models;

namespace SeleniumFramework.CoreFramework.Utilities;

public static class WebAppUrlValidationHelper
{
    public static string GenerateApplicationFormSubmissionUrl(TestUser testUser)
    {
        var encodedFirstName = HttpUtility.UrlEncode(testUser.FirstName);
        var encodedLastName = HttpUtility.UrlEncode(testUser.LastName);
        return $"https://ultimateqa.com/?gender={testUser.Gender.ToString().ToLower()}&firstname={encodedFirstName}&lastname={encodedLastName}";
    }
    
    public static string GenerateSearchUrl(string searchInput)
    {
        var encodedSearchInput = HttpUtility.UrlEncode(searchInput);
        return $"https://ultimateqa.com/?s={encodedSearchInput}&et_pb_searchform_submit=et_search_proccess&et_pb_include_posts=yes&et_pb_include_pages=yes";
    }
}