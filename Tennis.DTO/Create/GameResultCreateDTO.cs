using System;
using System.Collections.Generic;
using System.Text;
using Tennis.DTO.Attributes;
using Tennis.DTO.Read;

namespace Tennis.DTO.Create
{
    public class GameResultCreateDTO
    {
        [DropDown(typeof(GameReadDTO), "GameNumber", "GameNumber")]
        public int GameId { get; set; }
        public int SetNr { get; set; }
        public int ScoreTeamMember { get; set; }
        public int ScoreOpponent { get; set; }
    }
}
