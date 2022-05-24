using System.Collections.Generic;

namespace Fotball_App.Core.Dtos
{
    public class LeagueDto
    {
        public int LeagueId { get; set; }
        public string LeagueName { get; set; }
        public string LeagueLogo { get; set; }
        public string Nationality { get; set; }
        public List<TeamDto> Teams { get; set; }
    }
}

