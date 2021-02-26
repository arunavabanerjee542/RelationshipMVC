using Microsoft.EntityFrameworkCore;
using RelationshipsMVC.Models;
using RelationshipsMVC.ViewModel;
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

        public Department AddDepartment(DepartmentModel deptModel)
        {
            var dept = new Department() { DeptName = deptModel.DeptName };
            _context.Departments.Add(dept);
            _context.SaveChanges();
            return dept;

        }

        public IEnumerable<Department> GetDepartments()
        {
            return _context.Departments
                .Include(d => d.Employees);
               
        }
    }
}
