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
        public IActionResult Get()
        {
            IEnumerable<Employee> empList= _employeeRepository.GetAll();
            if (empList==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(empList);
            }
            
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int? Id)
        {
            if (Id!=null)
            {
                Employee employee = _employeeRepository.GetById((int)Id);
                if (employee == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(employee);
                }

            }
            else
            {
                return BadRequest();
            }

        }


        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Insert(employee);
               return CreatedAtAction("GET", new { Id=employee.Id}, employee);
            }
            else
            {
                return BadRequest(ModelState);
            }


           
        }

        [HttpPost]
        public IActionResult Put([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
               Employee _employee = _employeeRepository.GetById(employee.Id);
                if (_employee!=null)
                {
                    _employeeRepository.Update(employee);

                    return Ok(employee);
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




        [HttpGet("filter-lastname")]
        public IActionResult SearchByLastName([FromBody]string lastName)
        {

            Employee employee = _employeeRepository.GetByFilter(e=>e.LastName==lastName);
            if (employee!=null)
            {
                return Ok(employee);
            }
            else
            {
               return NotFound();
            }
        } 

        
        [HttpDelete]
        public IActionResult Delete(int? Id) {

            if (Id!=null)
            {
                Employee employee = _employeeRepository.GetById((int)Id);
                if (employee!=null)
                {
                    _employeeRepository.Delete(employee);
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
