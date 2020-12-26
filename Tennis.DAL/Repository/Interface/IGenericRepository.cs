using System.Collections.Generic;

namespace Tennis.DAL.Repository.Interface
{
    public interface IGenericRepository<TBase, TReturn> where TBase : class
    {
        public List<TReturn> GetAll();
        public void Create(object create);
        public void Update(object update);
        public TReturn GetById(object id);
        public void Delete(object id);
    }
}
