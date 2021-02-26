using Microsoft.AspNetCore.Mvc;
using RelationshipsMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationshipsMVC.ViewComponents
{
    public class DepartmentCategoryViewComponent : ViewComponent
    {
        public IDepartmentRepository _departmentRepository;
        public DepartmentCategoryViewComponent
            (IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }


        public IViewComponentResult Invoke()
        {          
            return View(_departmentRepository.GetDepartments());
        }







    }
}
