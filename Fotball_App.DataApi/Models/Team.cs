using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fotball_App.DataApi.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public string TeamLogo { get; set; }
        public League League { get; set; }
        public List<Player> players { get; set; }
    }
}
