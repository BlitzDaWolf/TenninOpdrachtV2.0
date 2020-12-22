using System;
using System.Collections.Generic;
using System.Text;
using Tennis.DTO;
using Tennis.DTO.Interface;

namespace Tennis.BLL.Interface
{
    public interface IGenericService<TBase, TID, TRead, TCreate, TUpdate> : IGenericService<TBase, TID, TRead, TCreate>
        where TBase : class
    {
        public void Update(TUpdate update);
    }

    public interface IGenericService<TBase, TID>
        where TBase : class
    {
        public UnitOfWork UnitOfWork { get; set; }
    }

    public interface IGenericService<TBase, TID, TRead> : IGenericService<TBase, TID>
        where TBase : class
    {
        public List<TRead> GetAll();
        public TRead GetById(TID id);
        public void Delete(TID id);
    }

    public interface IGenericService<TBase, TID, TRead, TCreate> : IGenericService<TBase, TID, TRead>
        where TBase : class
    {
        public void Create(TCreate create);
    }
}
