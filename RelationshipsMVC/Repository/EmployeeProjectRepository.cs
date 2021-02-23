using RelationshipsMVC.Models;
using RelationshipsMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationshipsMVC.Repository
{
    public class EmployeeProjectRepository : IEmployeeProjectRepository
    {
        private RelationshipDb _context;
        public EmployeeProjectRepository(RelationshipDb context)
        {
            _context = context;
        }

        public EmployeeProject AddEmployeeProject(EmployeeProjectViewModel model)
        {
            var empProject = new EmployeeProject()
            {
                EmployeeId = model.EmployeeId,
                ProjectId = model.ProjectId
            };

           var empPro = _context.EmployeeProjects
                .Where(e => e.EmployeeId == model.EmployeeId && e.ProjectId == model.ProjectId).SingleOrDefault();
            if (empPro == null)
            {
                _context.EmployeeProjects.Add(empProject);
                _context.SaveChanges();
            }
            return empProject;
        }
    }
}
