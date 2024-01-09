// TokenService.cs
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Microsoft.Extensions.Options;

namespace HealthCare.WebApp.Services.Auth0
{
    public class TokenService
    {
        private readonly Auth0Settings _auth0Settings;
        private readonly AuthenticationApiClient _authenticationApiClient;

        public TokenService(IOptions<Auth0Settings> auth0Settings)
        {
            _auth0Settings = auth0Settings.Value;
            _authenticationApiClient = new AuthenticationApiClient(new Uri($"https://{_auth0Settings.Domain}"));
        }

        public async Task<string> ExchangeAuthorizationCodeForUserTokenAsync(string authorizationCode)
        {
            var tokenRequest = new AuthorizationCodeTokenRequest
            {
                ClientId = _auth0Settings.ClientId,
                ClientSecret = _auth0Settings.ClientSecret,
                Code = authorizationCode,
                RedirectUri = _auth0Settings.RedirectUri
            };

            try
            {
                // Exchange the code for a user token
                var tokenResponse = await _authenticationApiClient.GetTokenAsync(tokenRequest);
                return tokenResponse.IdToken; // Or tokenResponse.AccessToken depending on your need
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error exchanging code for token: {ex.Message}");
                throw; // Rethrow the exception or handle it as per your error handling policy
            }
        }
    }
    
        public class Auth0Settings
        {
            public const string SectionName = "Auth0";
            public string Domain { get; set; } = string.Empty;
            public string ClientId { get; set; } = string.Empty;
            public string ClientSecret { get; set; } = string.Empty;
            public string ApiIdentifier { get; set; } = string.Empty;
            public string Connection { get; set; } = string.Empty;
            public string ReturnUrlAfterLogout { get; set; } = string.Empty;
        public string RedirectUri { get; set; } = string.Empty;
    }
}

