using SeleniumFramework.CoreFramework.Enums;

namespace SeleniumFramework.CoreFramework.Models;

public class TestUser
{
    public string FirstName { get; }
    public string LastName { get; }
    public GenderType Gender { get; }

    public TestUser(string firstName, string lastName, GenderType gender)
    {
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
    }
}