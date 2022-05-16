using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fotball_App.DataApi.Models
{
    public class League
    {
        public int LeagueId { get; set; }
        public string LeagueName { get; set; }
        public string LeagueLogo { get; set; }
        public string Nationality { get; set; }
        public List<Team> Teams { get; set; }
    }
}
