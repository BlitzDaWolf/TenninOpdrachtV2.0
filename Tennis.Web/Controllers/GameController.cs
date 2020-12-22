using Microsoft.AspNetCore.Mvc;
using Tennis.BLL.Interface;
using Tennis.DTO.Create;
using Tennis.Web.Interface;

namespace Tennis.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase, IReadController<int>, ICreateController<GameCreateDTO>
    {
        private readonly IGameService GameService;

        public GameController(IGameService gameService)
        {
            GameService = gameService;
        }

        [HttpPost]
        public void Create(GameCreateDTO create)
        {
            GameService.Create(create);
        }

        [HttpGet("{id:int}")]
        public ActionResult GetByID(int id)
        {
            return Ok(GameService.GetById(id));
        }


        [HttpGet]
        public ActionResult Index()
        {
            return Ok(GameService.GetAll());
        }
    }
}
