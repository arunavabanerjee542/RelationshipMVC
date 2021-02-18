using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationshipsMVC.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Pname { get; set; }
        public virtual ICollection<EmployeeProject> Employees { get; set; }

    }
}
