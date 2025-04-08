namespace MammaMiaDev.Services;

public record DummyUser(
    string UserName,
    string Password,
    string FirstName,
    string LastName
    )
{
    public string FullName => $"{FirstName} {LastName}";
}
