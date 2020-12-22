using System;
using System.Collections.Generic;
using System.Text;
using Tennis.DTO;
using Tennis.DTO.Interface;

namespace Tennis.BLL.Interface
{
    public interface IGenericService<TBase, TID, TRead, TCreate, TUpdate>
        where TBase : class
    {
        public List<TRead> GetAll();
        public TRead GetById(TID id);
        public void Update(TUpdate update);
        public void Create(TCreate create);
        public void Delete(TID id);
    }

    public interface IGenericService<TBase, TID>
        where TBase : class
    {
        public List<object> GetAll();
        public object GetById(TID id);
        public void Update(object update);
        public void Create(object create);
        public void Delete(TID id);
    }

    public interface IGenericService<TBase, TID, TRead>
        where TBase : class
    {
        public List<TRead> GetAll();
        public TRead GetById(TID id);
        public void Delete(TID id);
    }

    public interface IGenericService<TBase, TID, TRead, TUpdate>
        where TBase : class
    {
        public List<TRead> GetAll();
        public TRead GetById(TID id);
        public void Update(TUpdate update);
        public void Delete(TID id);
    }
}
