using System;
using System.Collections.Generic;

namespace Tennis.DAL.Models
{
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
