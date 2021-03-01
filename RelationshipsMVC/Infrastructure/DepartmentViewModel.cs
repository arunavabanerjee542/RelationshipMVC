using RelationshipsMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationshipsMVC.Infrastructure
{
    public class DepartmentViewModel
    {
        public Paging PagingInfo { get; set; }
        public IEnumerable<Department> Departments { get; set; }
    }
}
