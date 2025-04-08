using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MammaMiaDev.Services;

/// <summary>
/// Служба, отвечающая за взаимодействие с API.
/// </summary>
public class LoginService : ILoginService
{
    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };
    private readonly HttpClient _httpClient;

    public LoginService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AuthenticationResult?> Authenticate(string userName, string password)
    {
        var response = await _httpClient.PostAsync("auth/login", JsonContent.Create(new
        {
            userName,
            password
        }));

        var content = await response.Content.ReadAsStringAsync();
        return response.IsSuccessStatusCode
            ? JsonSerializer.Deserialize<AuthenticationResult>(content,_jsonOptions)
            : null;
    }


    public async Task<DummyUser[]> Users()
    {
        var response = await _httpClient.GetFromJsonAsync<UserResponse>("users");
        return response is null
            ? []
            : response.Users;
    }
}
