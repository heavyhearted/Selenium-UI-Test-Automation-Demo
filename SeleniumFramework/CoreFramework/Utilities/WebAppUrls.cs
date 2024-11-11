namespace SeleniumFramework.CoreFramework.Utilities;

public static class WebAppUrls
{
    // Base URLs
    private const string BaseUrl = "https://ultimateqa.com";
    private const string CoursesBaseUrl = "https://courses.ultimateqa.com";

    // Full Paths
    private const string TermsOfUsePath = "/pages/terms";
    private const string PrivacyPolicyPath = "/pages/privacy";
    private const string SampleApplicationLifecyclePath = "/sample-application-lifecycle-sprint-3";
    private const string ServicesPath = "/consulting/";
    private const string BlogPath = "/blog";

    // Full URLs
    public const string HomePageUrl = $"{BaseUrl}";
    public const string TermsOfUseUrl = $"{CoursesBaseUrl}{TermsOfUsePath}";
    public const string PrivacyPolicyUrl = $"{CoursesBaseUrl}{PrivacyPolicyPath}";
    public const string SampleAppPageUrl = $"{BaseUrl}{SampleApplicationLifecyclePath}";
    public const string ServicesPageUrl = $"{BaseUrl}{ServicesPath}";
    public const string BlogPageUrl = $"{BaseUrl}{BlogPath}";
}
    