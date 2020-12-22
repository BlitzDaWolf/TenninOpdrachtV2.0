using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tennis.BLL;
using Tennis.DAL.Context;
using Tennis.DAL.Models;
using Tennis.DAL.Repository;

namespace Tennis.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class test : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;
        public test(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult index()
        {
            return Ok(unitOfWork.RoleRepository.GetAll());
        }
    }
}
