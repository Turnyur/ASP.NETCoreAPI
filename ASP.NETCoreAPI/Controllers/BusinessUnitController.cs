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
        public IActionResult Get()
        {
            IEnumerable<BusinessUnit> businesUnitList = _businessUnitRepository.GetAll();
            if (businesUnitList == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(businesUnitList);
            }

        }

        [HttpGet("{Id}")]
        public IActionResult Get(int? Id)
        {
            if (Id != null)
            {
                BusinessUnit businesUnit = _businessUnitRepository.GetById((int)Id);
                if (businesUnit == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(businesUnit);
                }

            }
            else
            {
                return BadRequest();
            }

        }




        // POST api/<BusinessUnitController>
        [HttpPost]
        public IActionResult Post([FromBody] BusinessUnit businessUnit)
        {
            // Reject Id specified by user and auto generate Id
            businessUnit.Id = 0;
            if (ModelState.IsValid)
            {
                _businessUnitRepository.Insert(businessUnit);
                return CreatedAtAction("GET", new { Id = businessUnit.Id }, businessUnit);
            }
            else
            {
                return BadRequest(ModelState);
            }



        }
        // POST api/<BusinessUnitController>

        [HttpPut]
        public IActionResult Put([FromBody] BusinessUnit businessUnit)
        {
            if (ModelState.IsValid)
            {
                BusinessUnit bUnit = _businessUnitRepository.GetById(businessUnit.Id);
                if (bUnit != null)
                {
                    _businessUnitRepository.Update(businessUnit);

                    return Ok(businessUnit);
                }
                else
                {
                    return NotFound();
                }

            }
            else
            {
                return BadRequest(ModelState);
            }



        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int? Id)
        {

            if (Id != null)
            {
                BusinessUnit businessUnit = _businessUnitRepository.GetById((int)Id);
                if (businessUnit != null)
                {
                    _businessUnitRepository.Delete(businessUnit);
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest(Id);
            }
        }


    }
}
