using ASP.NETCoreAPI.DAL;
using ASP.NETCoreAPI.Models;
using ASP.NETCoreAPI.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ASP.NETCoreAPI.Services.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public readonly new AppDbContext _context;
        public EmployeeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public int GetEmployeeCount(Expression<Func<Employee, bool>> predicate)
        {
            return _context.Set<Employee>().Where(predicate).Count();
        }
    }
}
