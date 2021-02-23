using RelationshipsMVC.Models;
using RelationshipsMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationshipsMVC.Repository
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetProjects();
        Project AddProject(ProjectViewModel projectView);
    }
}
