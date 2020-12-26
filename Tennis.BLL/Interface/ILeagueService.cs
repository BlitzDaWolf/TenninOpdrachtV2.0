using Tennis.DAL.Models;
using Tennis.DTO.Read;

namespace Tennis.BLL.Interface
{
    public interface ILeagueService : IGenericService<League, int, LeagueReadDTO>
    {
    }
}
