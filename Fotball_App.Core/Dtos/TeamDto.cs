using System.Collections.Generic;

namespace Fotball_App.Core.Dtos
{
    public class TeamDto
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public string TeamLogo { get; set; }
        public List<LeagueDto> League { get; set; }
        public List<PlayerDto> players { get; set; }
        public string Country { get; set; }
    }
}