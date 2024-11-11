namespace SeleniumFramework.CoreFramework;

public static class TestUrlConstants
{
    // Base URLs
    public const string BaseUrl = "https://ultimateqa.com";
    public const string CoursesBaseUrl = "https://courses.ultimateqa.com";

    // Full Paths
    public const string TermsOfUsePath = "/pages/terms";
    public const string PrivacyPolicyPath = "/pages/privacy";
    public const string SampleApplicationLifecyclePath = "/sample-application-lifecycle-sprint-3";

    // Full URLs
    public const string HomePageUrl = $"{BaseUrl}";
    public const string TermsOfUseUrl = $"{CoursesBaseUrl}{TermsOfUsePath}";
    public const string PrivacyPolicyUrl = $"{CoursesBaseUrl}{PrivacyPolicyPath}";
}
    