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
        public IEnumerable<Department> Get()
        {
           

            IEnumerable<Department> deptList = _departmentRepository.GetAll();
            if (deptList == null)
            {
               return Enumerable.Empty<Department>();
            }
            else
            {
                return deptList;
            }

        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public bool Post([FromBody] Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.Insert(department);
                return true;
            }
            else
            {
                return false;
            }



        }

        // PUT api/<DepartmentController>/5
        [HttpPut]
        public IActionResult updateEmployee([FromBody] Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.Update(department);
                return StatusCode(200);
            }
            else

                return StatusCode(400);
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
