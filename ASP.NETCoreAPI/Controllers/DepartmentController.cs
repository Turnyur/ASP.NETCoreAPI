using ASP.NETCoreAPI.Models;
using ASP.NETCoreAPI.Services.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NETCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        // GET: api/<DepartmentController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Department> deptList = _departmentRepository.GetAll();
            if (deptList == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(deptList);
            }

        }

        [HttpGet("{Id}")]
        public IActionResult Get(int? Id)
        {
            if (Id != null)
            {
                Department department = _departmentRepository.GetById((int)Id);
                if (department == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(department);
                }

            }
            else
            {
                return BadRequest();
            }

        }


        // POST api/<DepartmentController>
        [HttpPost]
        public IActionResult Post([FromBody] Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.Insert(department);
                return CreatedAtAction("GET", new { Id = department.Id }, department);
            }
            else
            {
                return BadRequest(ModelState);
            }



        }

        // PUT api/<DepartmentController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Department department)
        {
            if (ModelState.IsValid)
            {
                Department _dept = _departmentRepository.GetById(department.Id);
                if (_dept != null)
                {
                    _departmentRepository.Update(department);

                    return Ok(department);
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



        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int? Id)
        {

            if (Id != null)
            {
                Department department = _departmentRepository.GetById((int)Id);
                if (department != null)
                {
                    _departmentRepository.Delete(department);
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
