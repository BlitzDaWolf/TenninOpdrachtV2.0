using System.Collections.Generic;
using System.Threading.Tasks;
using Tennis.DTO.Read;

namespace Tennis.App.Api
{
    public class FineAPI : IGenericGetAPI<FineReadDTO>
    {
        public Task<List<FineReadDTO>> GetAll()
        {
            return GenericAPI.GetAll<FineReadDTO>("fine");
        }

        public Task<FineReadDTO> GetById(int id)
        {
            return GenericAPI.GetById<FineReadDTO>(id, "fine");
        }
    }
}
