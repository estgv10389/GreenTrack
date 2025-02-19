using GreenTrack.Models;
using System.Net.Http.Json;

namespace GreenTrack.Services
{
    public class AuthService : BaseService
    {
        private SessionService _sessionService;

        public AuthService(HttpClient httpClient, SessionService sessionService) : base(httpClient)
        {
            _sessionService = sessionService;
        }

        public async Task<bool> LoginDataAsync(string email, string password)
        {
            var loginData = new { Email = email, Password = password };
            var response = await _httpClient.PostAsJsonAsync("auth", loginData);
            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadFromJsonAsync<ApiResponse<User>>();
                _sessionService.StartSession(responseJson!.Data!, responseJson!.Token!.ToString()!);
                await SecureStorage.SetAsync("authToken", _sessionService.Token!);
                return responseJson.Success;
            }
            else
            {
                response.ReasonPhrase!.ToString();
                return response.IsSuccessStatusCode;
            }
        }

        public Task LogoutAsync()
        {
            _sessionService.EndSession();
            SecureStorage.Remove("authToken");
            return Task.CompletedTask;
        }
    }
}
