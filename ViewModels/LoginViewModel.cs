using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MammaMiaDev.Services;

namespace MammaMiaDev.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    private readonly ILoginService _loginService;

    [ObservableProperty] private string _errorMessage = "";
    [ObservableProperty] private string _userName = "";
    [ObservableProperty] private string _password = "";
    [ObservableProperty] private IReadOnlyList<DummyUser> _availableUsers = [];
    [ObservableProperty] private DummyUser? _selectedUser;


    /// <summary>
    /// CTOR
    /// </summary>
    /// <param name="loginService"></param>
    public LoginViewModel(ILoginService loginService)
    {
        _loginService = loginService;
        _ = GetUsers();
    }


    partial void OnSelectedUserChanged(DummyUser? value)
    {
        if (value == null)
        {
            return;
        }
        UserName = value.UserName;
        Password = value.Password;
    }


    [RelayCommand]
    private async Task Login()
    {
        var authResult = await _loginService.Authenticate(UserName, Password);
        if (authResult is null)
        {
            ErrorMessage = "Invalid username or password";
            return;
        }
        ErrorMessage = "";
    }


    private async Task GetUsers()
    {
        AvailableUsers = await _loginService.Users();
    }
}
