using System.Collections.Generic;
using Tennis.BLL.Interface;
using Tennis.DTO.Create;
using Tennis.DTO.Read;

namespace Tennis.BLL.Service
{
    public class MemberRoleService : IMemberRoleService
    {
        public UnitOfWork UnitOfWork { get; set; }

        public MemberRoleService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void Create(MemberRoleCreateDTO create)
        {
            UnitOfWork.MemberRoleRepository.Create(create);
        }

        public void Delete(int id)
        {
            UnitOfWork.MemberRoleRepository.Delete(id);
        }

        public List<MemberRoleReadDTO> GetAll()
        {
            return UnitOfWork.MemberRoleRepository.GetAll();
        }

        public MemberRoleReadDTO GetById(int id)
        {
            return UnitOfWork.MemberRoleRepository.GetById(id);
        }
    }
}
