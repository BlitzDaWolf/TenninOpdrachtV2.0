using System;
using System.Collections.Generic;
using System.Text;
using Tennis.BLL.Interface;
using Tennis.DTO.Read;

namespace Tennis.BLL.Service
{
    public class LeagueService : ILeagueService
    {
        public UnitOfWork UnitOfWork { get; set; }

        public LeagueService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void Delete(int id)
        {
            UnitOfWork.LeagueRepository.Delete(id);
        }

        public List<LeagueReadDTO> GetAll()
        {
            return UnitOfWork.LeagueRepository.GetAll();
        }

        public LeagueReadDTO GetById(int id)
        {
            return UnitOfWork.LeagueRepository.GetById(id);
        }
    }
}
