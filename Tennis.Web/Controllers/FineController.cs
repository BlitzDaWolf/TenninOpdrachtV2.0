using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tennis.BLL.Interface;
using Tennis.BLL.Service;
using Tennis.Web.Interface;

namespace Tennis.Web
{
    [Route("api/[controller]")]
    [ApiController]
    public class FineController : ControllerBase, IReadController<int>
    {
        private readonly IFineService fineService;

        public FineController(IFineService fineService)
        {
            this.fineService = fineService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return Ok(fineService.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult GetByID(int id)
        {
            return Ok(fineService.GetById(id));
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            fineService.Delete(id);
            return Ok();
        }
    }
}
