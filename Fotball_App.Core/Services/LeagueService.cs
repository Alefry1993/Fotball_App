using Fotball_App.Core.Constants;
using Fotball_App.Core.Contracts.Services;
using Fotball_App.Core.Dtos;
using Fotball_App.Core.Helpers;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Fotball_App.Core.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly HttpClient _httpClient;
        public LeagueService()
        {
            _httpClient = new HttpClient() { BaseAddress = new System.Uri(UrlAdresses.DataApi) };
        }

        public async Task<IEnumerable<LeagueDto>> GetLeaguesAsync()
        {
            var leagueItems = new List<LeagueDto>();
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("League?includeteams=true");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                leagueItems = await Json.ToObjectAsync<List<LeagueDto>>(content);
            }
            return leagueItems;
        }

        public async Task<LeagueDto> CreateLeagueAsync(LeagueDto league)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"Leagues", league);
            httpResponseMessage.EnsureSuccessStatusCode();

            return await httpResponseMessage.Content.ReadFromJsonAsync<LeagueDto>();
        }

        public async Task<bool> DeleteLeagueAsync(LeagueDto league)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.DeleteAsync($"Leagues/{league.LeagueId}");
            return httpResponseMessage.IsSuccessStatusCode;
        }

        public async Task<LeagueDto> UpdateLeagueAsync(LeagueDto league)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsJsonAsync($"Leagues", league);
            return await httpResponseMessage.Content.ReadFromJsonAsync<LeagueDto>();
        }
    }
}
