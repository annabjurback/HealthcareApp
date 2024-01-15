using Blazored.LocalStorage;

namespace HealthCare.WebApp.Services;

public class UserDataService
{
    private readonly ILocalStorageService _localStorage;
    private const string UserIdKey = "UserId";

    public UserDataService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task SetUserIdAsync(string userId)
    {
        await _localStorage.SetItemAsync(UserIdKey, userId);
    }

    public async Task<string> GetUserIdAsync()
    {
        return await _localStorage.GetItemAsync<string>(UserIdKey);
    }
}
