using ASP.NETCoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETCoreAPI.Services.IRepository
{
    public interface IDepartmentRepository:IRepository<Department>
    {
        //addictional Contracts for Department
    }
}
