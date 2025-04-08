using MammaMiaDev.DesignTime;

public class DesignTimeSecretService : ISecretService
{
    public static ISecretService Instance { get; } = new DesignTimeSecretService();

    private DesignTimeSecretService() { }

    public string GetToken()
    {
        return "Design Token";
    }
}
