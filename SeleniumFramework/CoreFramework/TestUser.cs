namespace SeleniumFramework.CoreFramework;

public class TestUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public GenderType Gender { get; set; }

    public TestUser(string firstName, string lastName, GenderType gender)
    {
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
    }
}