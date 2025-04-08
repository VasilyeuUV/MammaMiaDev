namespace MammaMiaDev.Services;

public record AuthenticationResult(
    int Id,
    string UserName,
    string Email,
    string FirstName,
    string LastName,
    string Gender,
    string Image,
    string Token
    )
{
}
