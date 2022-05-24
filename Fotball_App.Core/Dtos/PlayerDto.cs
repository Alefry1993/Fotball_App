using System.Collections.Generic;

namespace Fotball_App.Core.Dtos
{
    public class PlayerDto
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string ProfileImage { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public string Position { get; set; }
        public string About { get; set; }
        public List<TeamDto> club { get; set; }
        public string National { get; set; }
    }
}
