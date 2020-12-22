using Tennis.DAL.Attributes;
using Tennis.DTO.Read;

namespace Tennis.DAL.Models
{
    [ReadDTO(typeof(LeagueReadDTO))]
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
