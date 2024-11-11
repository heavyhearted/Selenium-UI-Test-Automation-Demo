using System.Web;
using SeleniumFramework.CoreFramework.Models;

namespace SeleniumFramework.CoreFramework.Utilities;

public static class ApplicationFormUrlHelper
{
    public static string GenerateApplicationFormSubmissionUrl(TestUser testUser)
    {
        var encodedFirstName = HttpUtility.UrlEncode(testUser.FirstName);
        var encodedLastName = HttpUtility.UrlEncode(testUser.LastName);
        return $"https://ultimateqa.com/?gender={testUser.Gender.ToString().ToLower()}&firstname={encodedFirstName}&lastname={encodedLastName}";
    }
}