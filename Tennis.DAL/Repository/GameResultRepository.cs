﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tennis.DAL.Models;
using Tennis.DAL.Repository.Interface;
using Tennis.DTO.Read;

namespace Tennis.DAL.Repository
{
    public class GameResultRepository : GenericRepository<GameResult, GameResultReadDTO>, IGameResultRepository
    {
        public GameResultRepository(DbContext context, IMapper mapper) : base(context, mapper) { }
    }
}
