using CommunityToolkit.Mvvm.ComponentModel;
using MammaMiaDev.DesignTime;

namespace MammaMiaDev.ViewModels;

public partial class SecretViewModel : ViewModelBase
{
    private readonly ISecretService _secretService;

    [ObservableProperty] private string _token = "";

    // Конструктор для дизайнера
    public SecretViewModel()
        : this(DesignTimeSecretService.Instance)
    {
    }

    /// <summary>
    /// CTOR
    /// </summary>
    public SecretViewModel(ISecretService secretService)
    {
        _secretService = secretService;
        Token = _secretService.GetToken();
    }
}
