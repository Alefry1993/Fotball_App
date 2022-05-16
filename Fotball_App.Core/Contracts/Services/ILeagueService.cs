using Fotball_App.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fotball_App.Core.Contracts.Services
{
    public interface ILeagueService
    {
        Task<IEnumerable<LeagueDto>> GetLeaguesAsync();
        Task<LeagueDto> CreateLeagueAsync(LeagueDto league);
        Task<bool> DeleteLeagueAsync(LeagueDto league);
        Task<LeagueDto> UpdateLeagueAsync(LeagueDto league);
    }
}
