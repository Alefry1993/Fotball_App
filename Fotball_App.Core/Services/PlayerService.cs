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
    public class PlayerService : IPlayerService
    {
        private readonly HttpClient _httpClient;
        public PlayerService()
        {
            _httpClient = new HttpClient() { BaseAddress = new System.Uri(UrlAdresses.DataApi) };
        }

        public async Task<IEnumerable<PlayerDto>> GetPlayersAsync()
        {
            var PlayerItems = new List<PlayerDto>();
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("Players?includeclub=true");
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                PlayerItems = await Json.ToObjectAsync<List<PlayerDto>>(content);
            }
            return PlayerItems;
        }

        public async Task<PlayerDto> CreatePlayerAsync(PlayerDto player)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync($"Players", player);
            httpResponseMessage.EnsureSuccessStatusCode();

            return await httpResponseMessage.Content.ReadFromJsonAsync<PlayerDto>();
        }

        public async Task<bool> DeletePlayerAsync(PlayerDto player)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.DeleteAsync($"Players/{player.PlayerId}");
            return httpResponseMessage.IsSuccessStatusCode;
        }

        public async Task<PlayerDto> UpdatePlayerAsync(PlayerDto player)
        {
            var updatedPlayer = new PlayerDto();
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsJsonAsync($"Players/{player.PlayerId}", player);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string content = await httpResponseMessage.Content.ReadAsStringAsync();
                updatedPlayer = await Json.ToObjectAsync<PlayerDto>(content);
            }
            return updatedPlayer;
        }
    }
}
