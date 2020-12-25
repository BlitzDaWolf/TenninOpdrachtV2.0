using Microsoft.AspNetCore.Mvc;
using System;
using Tennis.BLL.Interface;
using Tennis.DTO.Create;
using Tennis.DTO.Update;
using Tennis.Web.Interface;

namespace Tennis.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase, IReadController<int>, IUpdateController<MemberUpdateDTO>, ICreateController<MemberCreateDTO>, IDeleteController<int>
    {
        IMemberService Service;

        public MemberController(IMemberService service)
        {
            Service = service;
        }

        [HttpPost]
        public void Create(MemberCreateDTO create)
        {
            Service.Create(create);
        }

        [HttpGet("{id:int}")]
        public ActionResult GetByID(int id)
        {
            return Ok(Service.GetById(id));
        }

        [HttpGet]
        public ActionResult Index()
        {
            return Ok(Service.GetAll());
        }

        [HttpPut]
        public void Update(MemberUpdateDTO update)
        {
            Service.Update(update);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            Service.Delete(id);
        }
    }
}
