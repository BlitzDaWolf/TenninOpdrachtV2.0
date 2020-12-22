using System;
using System.Collections.Generic;
using System.Text;
using Tennis.BLL.Interface;
using Tennis.DTO.Read;

namespace Tennis.BLL.Service
{
    public class GenderService : IGenderService
    {
        public UnitOfWork UnitOfWork { get; set; }

        public GenderService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void Delete(int id)
        {
            UnitOfWork.GenderRepository.Delete(id);
        }

        public List<GenderReadDTO> GetAll()
        {
            return UnitOfWork.GenderRepository.GetAll();
        }

        public GenderReadDTO GetById(int id)
        {
            return UnitOfWork.GenderRepository.GetById(id);
        }
    }
}
