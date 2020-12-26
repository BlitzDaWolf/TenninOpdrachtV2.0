using Tennis.DTO.Attributes;

namespace Tennis.DTO.Read
{
    public class GameResultReadDTO
    {
        public int Id { get; set; }
        [Filter]
        public int SetNr { get; set; }
        public int GameId { get; set; }
        public int ScoreTeamMember { get; set; }
        public int ScoreOpponent { get; set; }
    }
}