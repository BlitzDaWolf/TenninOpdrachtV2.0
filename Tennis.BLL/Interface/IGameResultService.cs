using System;
using System.Collections.Generic;
using System.Text;
using Tennis.DAL.Models;
using Tennis.DTO.Create;
using Tennis.DTO.Read;
using Tennis.DTO.Update;

namespace Tennis.BLL.Interface
{
    public interface IGameResultService : IGenericService<GameResult, int, GameResultReadDTO, GameResultCreateDTO>
    {
    }
}
