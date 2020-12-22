using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tennis.DAL.Models;
using Tennis.DAL.Repository.Interface;
using Tennis.DTO.Read;

namespace Tennis.DAL.Repository
{
    public class GenderRepository : GenericRepository<Gender, GenderReadDTO>, IGenderRepository
    {
        public GenderRepository(DbContext context, IMapper mapper) : base(context, mapper) { }
    }
}
