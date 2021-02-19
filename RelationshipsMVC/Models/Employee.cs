using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationshipsMVC.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Ename { get; set; }
        public virtual ICollection<EmployeeProject> Projects { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Departments { get; set; }
    }
}
