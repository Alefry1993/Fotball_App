using System;
using System.Collections.Generic;
using System.Text;

namespace Fotball_App.Core.Dtos
{
    public class TeamDto
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public string TeamLogo { get; set; }
        public LeagueDto League { get; set; }
        public List<PlayerDto> players { get; set; }
    }
}