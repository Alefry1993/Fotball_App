using System;
using System.Collections.Generic;
using System.Text;

namespace Fotball_App.Core.Dtos
{
    public class PlayerDto
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string ProfileImage { get; set; }
        public int Age { get; set; }
        public TeamDto club { get; set; }
        public string National { get; set; }
    }
}
