using System.Collections.Generic;
using Tennis.BLL.Interface;
using Tennis.DTO.Create;
using Tennis.DTO.Read;

namespace Tennis.BLL.Service
{
    public class GameResultService : IGameResultService
    {
        public UnitOfWork UnitOfWork { get; set; }
        public GameResultService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void Create(GameResultCreateDTO create)
        {
            UnitOfWork.GameResultRepository.Create(create);
            UnitOfWork.context.SaveChanges();
        }

        public void Delete(int id)
        {
            UnitOfWork.GameRepository.Delete(id);
        }

        public List<GameResultReadDTO> GetAll()
        {
            return UnitOfWork.GameResultRepository.GetAll();
        }

        public GameResultReadDTO GetById(int id)
        {
            return UnitOfWork.GameResultRepository.GetById(id);
        }
    }
}
