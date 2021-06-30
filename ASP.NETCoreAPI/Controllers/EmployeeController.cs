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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            IEnumerable<Employee> empList= _employeeRepository.GetAll();
            if (empList==null)
            {
               return Enumerable.Empty<Employee>();
            }
            else
            {
                return empList;
            }
            
        }


        [HttpPost]
        public bool Post([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Insert(employee);
                return true;
            }
            else
            {
                return false;
            }


           
        }

       
        [HttpGet("search/{lastName}")]
        public Employee SearchByLastName(string lastName)
        {
            return _employeeRepository.GetByFilter(e=>e.LastName==lastName);
        } 

        [HttpPut]
        public IActionResult  updateEmployee([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Update(employee);
                return StatusCode(200);
            }
            else

                return StatusCode(400);
        }
    }
}
