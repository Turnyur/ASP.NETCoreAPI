using ASP.NETCoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ASP.NETCoreAPI.Services.IRepository
{
   public interface IEmployeeRepository:IRepository<Employee>
    {
        //addictional Contracts for Employee
        public int GetEmployeeCount(Expression<Func<Employee, bool>> predicate);
    }
}
