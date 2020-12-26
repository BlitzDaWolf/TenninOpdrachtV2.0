using System.Collections.Generic;
using Tennis.BLL.Interface;
using Tennis.DTO.Create;
using Tennis.DTO.Read;
using Tennis.DTO.Update;

namespace Tennis.BLL.Service
{
    public class MemberService : IMemberService
    {
        public UnitOfWork UnitOfWork { get; set; }

        public MemberService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void Create(MemberCreateDTO create)
        {
            UnitOfWork.MemberRepository.Create(create);
        }

        public void Delete(int id)
        {
            UnitOfWork.MemberRepository.Delete(id);
        }

        public List<MemberReadDTO> GetAll()
        {
            return UnitOfWork.MemberRepository.GetAll();
        }

        public MemberReadDTO GetById(int id)
        {
            return UnitOfWork.MemberRepository.GetById(id);
        }

        public void Update(MemberUpdateDTO update)
        {
            UnitOfWork.MemberRepository.Update(update);
        }
    }
}
