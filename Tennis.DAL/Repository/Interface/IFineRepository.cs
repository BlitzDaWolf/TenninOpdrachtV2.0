using Tennis.DAL.Models;
using Tennis.DTO.Read;

namespace Tennis.DAL.Repository.Interface
{
    public interface IFineRepository : IGenericRepository<Fine, FineReadDTO> { }
}
