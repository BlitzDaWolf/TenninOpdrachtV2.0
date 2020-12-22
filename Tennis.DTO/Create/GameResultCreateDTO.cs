using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis.DTO.Create
{
    public class GameResultCreateDTO
    {
        public int GameId { get; set; }
        public int SetNr { get; set; }
        public int ScoreTeamMember { get; set; }
        public int ScoreOpponent { get; set; }
    }
}
