using Microsoft.EntityFrameworkCore;
using RelationshipsMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationshipsMVC.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {

        private RelationshipDb _context;
        public DepartmentRepository(RelationshipDb context)
        {
            _context = context;
        }


        public IEnumerable<Department> GetDepartments()
        {
            return _context.Departments.ToList();
        }
    }
}
