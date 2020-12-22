using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis.DTO.Create
{
    public class GameCreateDTO
    {
        public string GameNumber { get; set; }
        public int MemberId { get; set; }
        public int LeagueId { get; set; }
        public DateTime Date { get; set; }
    }
}
