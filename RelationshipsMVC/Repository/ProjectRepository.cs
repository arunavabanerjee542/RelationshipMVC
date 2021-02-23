using RelationshipsMVC.Models;
using RelationshipsMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationshipsMVC.Repository
{
    public class ProjectRepository : IProjectRepository
    {


        private RelationshipDb _context;
        public ProjectRepository(RelationshipDb context)
        {
            _context = context;
        }

        public Project AddProject(ProjectViewModel projectView)
        {
            var project = new Project()
            {
                Pname = projectView.Pname
            };

            _context.Projects.Add(project);
            _context.SaveChanges();
            return project;      
        }

        public IEnumerable<Project> GetProjects()
        {
            return _context.Projects.ToList();
        }
    }
}
