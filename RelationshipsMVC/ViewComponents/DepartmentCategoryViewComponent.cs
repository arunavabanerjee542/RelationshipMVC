using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using RelationshipsMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationshipsMVC.ViewComponents
{
    public class DepartmentCategoryViewComponent : ViewComponent
    {
       // private IUrlHelperFactory _urlFactory;


      //  [ViewContext]
      //  public ViewContext CurrentContext { get; set; }

        public IDepartmentRepository _departmentRepository;
        public DepartmentCategoryViewComponent
            (IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
           // _urlFactory = urlHelperFactory;
        }


        public IViewComponentResult Invoke()
        {
         //   IUrlHelper url = _urlFactory.GetUrlHelper(CurrentContext);
            ViewBag.SelectedDept = RouteData?.Values["category"];
            return View(_departmentRepository
                .GetDepartments()
                .Distinct()
                .Select(d => d.DeptName));
        }







    }
}
