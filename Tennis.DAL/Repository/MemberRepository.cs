using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tennis.DAL.Models;
using Tennis.DAL.Repository.Interface;
using Tennis.DTO.Read;

namespace Tennis.DAL.Repository
{
    public class MemberRepository : GenericRepository<Member, MemberReadDTO>, IMemberRepository
    {
        public MemberRepository(DbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
