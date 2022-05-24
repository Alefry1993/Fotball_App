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
    public class TeamService : ITeamService
    {
        private readonly HttpClient _httpClient;
        public TeamService()
        {
            _httpClient = new HttpClient() { BaseAddress = new System.Uri(UrlAdresses.DataApi) };
        }

        public async Task<IEnumerable<TeamDto>> GetTeamsAsync()
        {
            var TeamItems = new List<TeamDto>();
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("Teams?incluedplayers=true");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                TeamItems = await Json.ToObjectAsync<List<TeamDto>>(content);
            }
            return TeamItems;
        }

        public async Task<TeamDto> CreateTeamAsync(TeamDto team)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"Teams", team);
            httpResponseMessage.EnsureSuccessStatusCode();

            return await httpResponseMessage.Content.ReadFromJsonAsync<TeamDto>();
        }

        public async Task<bool> DeleteTeamAsync(TeamDto team)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.DeleteAsync($"Teams/{team.TeamId}");
            return httpResponseMessage.IsSuccessStatusCode;
        }

        public async Task<TeamDto> UpdateTeamAsync(TeamDto team)
        {
            var updatedTeam = new TeamDto();
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsJsonAsync($"Teams/{team.TeamId}", team);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                updatedTeam = await Json.ToObjectAsync<TeamDto>(content);
            }
            return updatedTeam;
        }
    }
}
