namespace Tennis.DAL.Models
{
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
