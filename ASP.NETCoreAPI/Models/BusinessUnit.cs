using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETCoreAPI.Models
{
    public class BusinessUnit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }


        public ICollection<Employee> Employees { get; set; }


        public int DepartmentId { get; set; }
        public Department Department { get; set; }


    }
}
