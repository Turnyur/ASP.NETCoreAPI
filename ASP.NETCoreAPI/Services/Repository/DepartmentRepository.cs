using ASP.NETCoreAPI.DAL;
using ASP.NETCoreAPI.Models;
using ASP.NETCoreAPI.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETCoreAPI.Services.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext context) : base(context)
        {
            //Aditional Methods Specific to Department repo
        }

    }
}
