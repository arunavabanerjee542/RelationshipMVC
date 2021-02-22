using RelationshipsMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationshipsMVC.Repository
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();
    }
}
