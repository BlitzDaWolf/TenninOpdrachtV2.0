using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tennis.BLL.Interface;
using Tennis.DTO.Create;
using Tennis.Web.Interface;

namespace Tennis.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameResultController : ControllerBase, IReadController<int>, ICreateController<GameResultCreateDTO>
    {
        private readonly IGameResultService Service;
        public GameResultController(IGameResultService service)
        {
            Service = service;
        }

        [HttpPost]
        public void Create(GameResultCreateDTO create)
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
