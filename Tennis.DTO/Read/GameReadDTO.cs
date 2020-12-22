using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis.DTO.Read
{
    public class GameReadDTO
    {
        public string GameNumber { get; set; }
        public DateTime Date { get; set; }
        public virtual List<GameResultReadDTO> Results { get; set; }
    }
}
