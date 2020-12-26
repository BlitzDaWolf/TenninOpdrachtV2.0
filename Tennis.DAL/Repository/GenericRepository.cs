using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Tennis.DAL.Attributes;
using Tennis.DAL.Repository.Interface;

namespace Tennis.DAL.Repository
{
    public class GenericRepository<TBase, TReturn> : IGenericRepository<TBase, TReturn> where TBase : class
    {
        private readonly DbContext context;
        private readonly IMapper mapper;
        private readonly DbSet<TBase> dbSet;

        private readonly Type readType;
        private readonly Type updateType;
        private readonly Type createType;

        public GenericRepository(DbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            dbSet = this.context.Set<TBase>();
            readType = ReadDTOAttribute.GetAttribute(typeof(TBase))?.ReadType;
            updateType = UpdateDTOAttribute.GetAttribute(typeof(TBase))?.ReadType;
            createType = CreateDTOAttribute.GetAttribute(typeof(TBase))?.ReadType;
        }

        public List<TReturn> GetAll()
        {
            if (readType == null) return null;
            if (readType != typeof(TReturn)) return null;
            Type genericListType = typeof(List<>).MakeGenericType(readType);
            var res = dbSet.ToList();
            return (List<TReturn>)mapper.Map(res, res.GetType(), genericListType);
        }

        public void Create(object create)
        {
            if (createType == null) return;
            if (create.GetType() != createType) return;
            TBase t = (TBase)mapper.Map(create, createType, typeof(TBase));
            dbSet.Add(t);
        }

        public void Update(object update)
        {
            if (updateType == null) return;
            if (update.GetType() != updateType) return;
            dbSet.Update((TBase)mapper.Map(update, updateType, typeof(TBase)));
        }

        public TReturn GetById(object id)
        {
            // if (readType == null) return null;
            var res = dbSet.Find(id);
            return (TReturn)mapper.Map(res, typeof(TBase), readType);
        }

        public void Delete(object id)
        {
            dbSet.Remove(dbSet.Find(id));
        }
    }
}
