using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tennis.DAL.Models;
using Tennis.DAL.Repository.Interface;
using Tennis.DTO.Read;

namespace Tennis.DAL.Repository
{
    public class FineRepository : GenericRepository<Fine, FineReadDTO>, IFineRepository
    {
        public FineRepository(DbContext context, IMapper mapper) : base(context, mapper) { }
    }
}
