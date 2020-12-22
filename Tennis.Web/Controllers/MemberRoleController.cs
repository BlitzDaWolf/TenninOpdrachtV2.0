using Microsoft.AspNetCore.Mvc;
using Tennis.BLL.Interface;
using Tennis.DTO.Create;
using Tennis.Web.Interface;

namespace Tennis.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberRoleController : ControllerBase, IReadController<int>, ICreateController<MemberRoleCreateDTO>
    {
        private readonly IMemberRoleService Service;

        public MemberRoleController(IMemberRoleService service)
        {
            Service = service;
        }

        [HttpPost]
        public void Create(MemberRoleCreateDTO create)
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
    }
}
