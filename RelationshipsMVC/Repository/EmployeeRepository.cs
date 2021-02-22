using Microsoft.EntityFrameworkCore;
using RelationshipsMVC.Models;
using RelationshipsMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationshipsMVC.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private RelationshipDb _context;
        public EmployeeRepository(RelationshipDb context)
        {
            _context = context;
        }

        public Employee AddEmployeeWithProjects(EmployeeViewModel empView)
        {            
            var emp = new Employee()
            {
                Ename = empView.Ename,
                DepartmentId = empView.DepartmentId,                         
            };
            _context.SaveChanges();
             
            foreach(var projectId in empView.ProjectIds)
            {
                _context.EmployeeProjects.Add(new EmployeeProject()
                {
                    ProjectId = projectId.ProjectId,
                    EmployeeId = emp.EmployeeId
                }) ;
                _context.SaveChanges();
            }

            return new Employee();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees
                .Include(e => e.Departments)
                .Include(emp => emp.Projects)
                .ThenInclude(p => p.Projects)
                .ToList();                  
        }
    }
}
