using RelationshipsMVC.Models;
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


        public IEnumerable<Project> GetProjects()
        {
            return _context.Projects.ToList();
        }
    }
}
