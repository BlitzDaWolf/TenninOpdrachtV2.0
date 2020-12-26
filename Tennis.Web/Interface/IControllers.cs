using Microsoft.AspNetCore.Mvc;

namespace Tennis.Web.Interface
{
    public interface IReadController<TID>
    {
        public ActionResult Index();
        public ActionResult GetByID(TID id);
    }

    public interface IUpdateController<TUpdate>
    {
        public void Update(TUpdate update);
    }

    public interface ICreateController<TCreate>
    {
        public void Create(TCreate create);
    }

    public interface IDeleteController<TID>
    {
        public void Delete(TID id);
    }
}
