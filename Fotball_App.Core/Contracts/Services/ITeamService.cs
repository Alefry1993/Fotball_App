using Fotball_App.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fotball_App.Core.Contracts.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamDto>> GetTeamsAsync();
        Task<TeamDto> CreateTeamAsync(TeamDto team);
        Task<bool> DeleteTeamAsync(TeamDto team);
        Task<TeamDto> UpdateTeamAsync(TeamDto team);
    }
}
