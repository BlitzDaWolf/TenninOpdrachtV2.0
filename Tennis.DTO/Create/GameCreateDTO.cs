using System;
using System.Collections.Generic;
using System.Text;
using Tennis.DTO.Attributes;
using Tennis.DTO.Read;

namespace Tennis.DTO.Create
{
    public class GameCreateDTO
    {
        public string GameNumber { get; set; }
        [DropDown(typeof(MemberReadDTO), "FirstName", "Member")]
        public int MemberId { get; set; }
        [DropDown(typeof(LeagueReadDTO), "Name", "League")]
        public int LeagueId { get; set; }
        public DateTime Date { get; set; }
    }
}
