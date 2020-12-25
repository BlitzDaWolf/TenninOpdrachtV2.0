using System;
using System.Collections.Generic;
using System.Text;
using Tennis.BLL.Interface;
using Tennis.DTO.Create;
using Tennis.DTO.Read;

namespace Tennis.BLL.Service
{
    public class GameService : IGameService
    {
        public GameService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public UnitOfWork UnitOfWork { get; set; }

        public void Create(GameCreateDTO create)
        {
            UnitOfWork.GameRepository.Create(create);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<GameReadDTO> GetAll()
        {
            return UnitOfWork.GameRepository.GetAll();
        }

        public GameReadDTO GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
