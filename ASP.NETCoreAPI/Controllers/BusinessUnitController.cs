using ASP.NETCoreAPI.Models;
using ASP.NETCoreAPI.Services.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessUnitController : ControllerBase
    {
        private readonly IBusinessUnitRepository _businessUnitRepository;
        public BusinessUnitController(IBusinessUnitRepository businessUnitRepository)
        {
            _businessUnitRepository = businessUnitRepository;
        }


        // GET: api/<BusinessUnitController>
        [HttpGet]
        public IEnumerable<BusinessUnit> Get()
        {


            IEnumerable<BusinessUnit> deptList = _businessUnitRepository.GetAll();
            if (deptList == null)
            {
                return Enumerable.Empty<BusinessUnit>();
            }
            else
            {
                return deptList;
            }

        }



        // POST api/<BusinessUnitController>
        [HttpPost]
        public bool Post([FromBody] BusinessUnit businessUnit)
        {
            if (ModelState.IsValid)
            {
                _businessUnitRepository.Insert(businessUnit);
                return true;
            }
            else
            {
                return false;
            }



        }




        // PUT api/<DepartmentController>/5
        [HttpPut]
        public IActionResult updateBusinessUnit([FromBody] BusinessUnit businessUnit)
        {
            if (ModelState.IsValid)
            {
                _businessUnitRepository.Update(businessUnit);
                return StatusCode(200);
            }
            else

                return StatusCode(400);
        }


    }
}
