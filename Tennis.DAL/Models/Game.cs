using System;
using System.Collections.Generic;
using Tennis.DAL.Attributes;
using Tennis.DTO.Create;
using Tennis.DTO.Read;

namespace Tennis.DAL.Models
{
    [ReadDTO(typeof(GameReadDTO))]
    [CreateDTO(typeof(GameCreateDTO))]
    public class Game
    {
        public int Id { get; set; }
        public string GameNumber { get; set; }
        public int MemberId { get; set; }
        public virtual Member Member { get; set; }
        public int LeagueId { get; set; }
        public virtual League League { get; set; }
        public DateTime Date { get; set; }
        public virtual List<GameResult> Results { get; set; }
    }
}
