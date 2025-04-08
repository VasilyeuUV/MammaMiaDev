using System.Threading.Tasks;

namespace MammaMiaDev.Services;

public interface ILoginService
{
    Task<AuthenticationResult?> Authenticate(string userName, string password);


    Task<DummyUser[]> Users();
}
