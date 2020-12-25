using System;
using System.Collections.Generic;
using System.Text;
using Tennis.DTO.Attributes;

namespace Tennis.DTO.Read
{
    public class GameReadDTO
    {
        public int Id { get; set; }
        [Filter]
        public string GameNumber { get; set; }
        public MemberReadDTO Member { get; set; }
        public LeagueReadDTO League { get; set; }
        public DateTime Date { get; set; }
        public virtual List<GameResultReadDTO> Results { get; set; }
    }
}
