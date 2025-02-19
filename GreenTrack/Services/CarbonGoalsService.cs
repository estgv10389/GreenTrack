using GreenTrack.DTO;
using GreenTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GreenTrack.Services
{
    public class CarbonGoalsService:BaseService
    {
        SessionService _sessionService;
        public CarbonGoalsService(HttpClient httpClient, SessionService sessionService) : base(httpClient)
        {
            _sessionService = sessionService;
        }

        public async Task<ApiResponse<CarbonGoal>?> SaveGoals(CarbonGoalsDTO carbonGoalsDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("carbongoal", carbonGoalsDTO);
            return await response.Content.ReadFromJsonAsync<ApiResponse<CarbonGoal>>();
        }
    }
}
