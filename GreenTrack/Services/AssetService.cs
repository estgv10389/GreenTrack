using GreenTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace GreenTrack.Services
{
    public class AssetService:BaseService
    {
        SessionService _sessionService;
        public AssetService(HttpClient httpClient, SessionService sessionService) : base(httpClient)
        {
            _sessionService = sessionService;
        }

        public async Task<ApiResponse<List<Asset>>?> GetAssests()
        {
            var response = await _httpClient.GetAsync("asset");
            return await  response.Content.ReadFromJsonAsync<ApiResponse<List<Asset>>>();
        }
    }
}
