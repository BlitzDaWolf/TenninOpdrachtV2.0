using Tennis.DAL.Attributes;
using Tennis.DTO.Create;
using Tennis.DTO.Read;

namespace Tennis.DAL.Models
{
    [ReadDTO(typeof(GameResultReadDTO))]
    [CreateDTO(typeof(GameResultCreateDTO))]
    public class GameResult
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public int SetNr { get; set; }
        public int ScoreTeamMember { get; set; }
        public int ScoreOpponent { get; set; }
    }
}
