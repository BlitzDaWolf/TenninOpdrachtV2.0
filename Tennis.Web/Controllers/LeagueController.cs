using Microsoft.AspNetCore.Mvc;
using Tennis.BLL.Interface;
using Tennis.Web.Interface;

namespace Tennis.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase, IReadController<int>
    {
        private readonly ILeagueService Service;

        public LeagueController(ILeagueService service)
        {
            Service = service;
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
