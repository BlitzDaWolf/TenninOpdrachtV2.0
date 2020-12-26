using System.Collections.Generic;
using Tennis.BLL.Interface;
using Tennis.DTO.Read;

namespace Tennis.BLL.Service
{
    public class FineService : IFineService
    {
        public UnitOfWork UnitOfWork { get; set; }

        public FineService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void Delete(int id)
        {
            UnitOfWork.FineRepository.Delete(id);
        }

        public List<FineReadDTO> GetAll()
        {
            return UnitOfWork.FineRepository.GetAll();
        }

        public FineReadDTO GetById(int id)
        {
            return UnitOfWork.FineRepository.GetById(id);
        }
    }
}
