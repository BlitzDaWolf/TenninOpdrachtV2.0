using System.Collections.Generic;
using Tennis.BLL.Interface;
using Tennis.DTO.Read;

namespace Tennis.BLL.Service
{
    public class RoleService : IRoleService
    {
        public RoleService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public UnitOfWork UnitOfWork { get; set; }

        public void Delete(int id) { }

        public List<RoleReadDTO> GetAll()
        {
            return UnitOfWork.RoleRepository.GetAll();
        }

        public RoleReadDTO GetById(int id)
        {
            return UnitOfWork.RoleRepository.GetById(id);
        }
    }
}
