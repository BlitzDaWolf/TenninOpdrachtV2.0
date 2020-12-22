using Tennis.DAL.Models;
using Tennis.DTO.Create;
using Tennis.DTO.Read;
using Tennis.DTO.Update;

namespace Tennis.BLL.Interface
{
    public interface IMemberService : IGenericService<Member, int, MemberReadDTO, MemberCreateDTO, MemberUpdateDTO>
    {
    }
}
