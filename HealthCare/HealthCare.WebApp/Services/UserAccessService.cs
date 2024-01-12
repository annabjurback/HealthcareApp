using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;

namespace HealthCare.WebApp.Services;

public class UserAccessService
{
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManager;

    public UserAccessService(HttpClient httpClient, NavigationManager navigationManager)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7139/");
        _navigationManager = navigationManager;
    }

    public async Task LogInUser(string role, string id, string firstName, string lastName, string email)
    {
        var apiEndpoint = $"/api/{role}?id=" + id;
        var getResponse = await _httpClient.GetAsync(apiEndpoint);

        if (getResponse.IsSuccessStatusCode)
        {
            return;
        }
        else
        {
            var query = new Dictionary<string, string>
            {
                ["id"] = id,
                ["firstName"] = firstName,
                ["lastName"] = lastName,
                ["email"] = email
            };
            var uri = QueryHelpers.AddQueryString($"/api/{role}", query);
            var saveResponse = await _httpClient.PostAsync(uri, null);

            if (!saveResponse.IsSuccessStatusCode)
            {
                _navigationManager.NavigateTo("/Error");
            }
        }
    }
}
