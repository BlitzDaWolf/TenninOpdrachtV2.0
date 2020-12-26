using Tennis.DAL.Models;
using Tennis.DTO.Read;

namespace Tennis.DAL.Repository.Interface
{
    public interface IGameResultRepository : IGenericRepository<GameResult, GameResultReadDTO> { }
}
