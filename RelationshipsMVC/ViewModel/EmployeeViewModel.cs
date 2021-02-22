using RelationshipsMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationshipsMVC.ViewModel
{
    public class EmployeeViewModel
    {
        public string Ename { get; set; } 
        public int DepartmentId { get; set; }
        public ICollection<ProjectIdViewModel> ProjectIds { get; set; }
        public IEnumerable<Department> DepartmentList { get; set; }
        public IEnumerable<Project> ProjectList { get; set; }
    }
}
