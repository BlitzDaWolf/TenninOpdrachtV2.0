using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tennis.DAL.Models;
using Tennis.DAL.Repository.Interface;
using Tennis.DTO.Read;

namespace Tennis.DAL.Repository
{
    public class RoleRepository : GenericRepository<Role, RoleReadDTO>, IRoleRepository
    {
        public RoleRepository(DbContext context, IMapper mapper) : base(context, mapper) { }
    }
}
