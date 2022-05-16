using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fotball_App.DataApi.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string ProfileImage { get; set; }
        public int Age { get; set; }
        public Team club { get; set; }
        public string National { get; set; }
    }
}
