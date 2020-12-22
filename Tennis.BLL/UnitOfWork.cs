using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tennis.DAL.Context;
using Tennis.DAL.Repository;
using Tennis.DAL.Repository.Interface;

namespace Tennis.BLL
{
    public class UnitOfWork
    {
        public readonly TennisContext context;
        public readonly IMapper mapper;

        public UnitOfWork(TennisContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        private IFineRepository fineRepository;
        private IGameRepository gameRepository;
        private IGameResultRepository gameResultRepository;
        private IGenderRepository genderRepository;
        private ILeagueRepository leagueRepository;
        private IMemberRepository memberRepository;
        private IMemberRoleRepository memberRoleRepository;
        private IRoleRepository roleRepository;

        public IFineRepository FineRepository => this.fineRepository ??= new FineRepository(context, mapper);
        public IGameRepository GameRepository => this.gameRepository ??= new GameRepository(context, mapper);
        public IGameResultRepository GameResultRepository => this.gameResultRepository ??= new GameResultRepository(context, mapper);
        public IGenderRepository GenderRepository => this.genderRepository ??= new GenderRepository(context, mapper);
        public ILeagueRepository LeagueRepository => this.leagueRepository ??= new LeagueRepository(context, mapper);
        public IMemberRepository MemberRepository => this.memberRepository ??= new MemberRepository(context, mapper);
        public IMemberRoleRepository MemberRoleRepository => this.memberRoleRepository ??= new MemberRoleRepository(context, mapper);
        public IRoleRepository RoleRepository => this.roleRepository ??= new RoleRepository(context, mapper);
    }
}
