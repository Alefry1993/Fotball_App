using Fotball_App.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fotball_App.Core.Contracts.Services
{
    public interface IPlayerService
    {
        Task<IEnumerable<PlayerDto>> GetPlayersAsync();
        Task<PlayerDto> CreatePlayerAsync(PlayerDto player);
        Task<bool> DeletePlayerAsync(PlayerDto player);
        Task<PlayerDto> UpdatePlayerAsync(PlayerDto player);
    }
}
