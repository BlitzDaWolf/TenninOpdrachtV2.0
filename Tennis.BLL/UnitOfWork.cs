using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Tennis.DAL.Context;
using Tennis.DAL.Repository;

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

        private RoleRepository roleRepository;

        public RoleRepository RoleRepository => this.roleRepository ??= new RoleRepository(context, mapper);
    }
}
