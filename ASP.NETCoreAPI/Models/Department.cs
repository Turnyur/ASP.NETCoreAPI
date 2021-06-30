using System;
using System.Collections.Generic;


namespace ASP.NETCoreAPI.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

       
        public ICollection<BusinessUnit> BusinessUnits { get; set; }

    }
}
