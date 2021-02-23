using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RelationshipsMVC.Repository;
using RelationshipsMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationshipsMVC.Controllers
{
    public class EmployeeProjectController : Controller
    {

        private IEmployeeRepository _employeeRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEmployeeProjectRepository _employeeProjectRepository;

        public EmployeeProjectController(IEmployeeRepository employeeRepository
            , IDepartmentRepository departmentRepository
            , IProjectRepository projectRepository,
            IEmployeeProjectRepository employeeProjectRepository)
        {
            _employeeRepository = employeeRepository;
            _projectRepository = projectRepository;
            _departmentRepository = departmentRepository;
            _employeeProjectRepository = employeeProjectRepository;
        }



        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AddEmployeeProject()
        {
            ViewBag.EmployeeIds =
                new SelectList(_employeeRepository.GetEmployees(), "EmployeeId", "Ename");
            ViewBag.ProjectIds = _projectRepository.GetProjects();
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployeeProject(int EmployeeIds, int[] ProjectIds )
        {
            foreach (var item in ProjectIds)
            {
                EmployeeProjectViewModel emp = new EmployeeProjectViewModel()
                {
                    ProjectId = item,
                    EmployeeId = EmployeeIds
                };
                _employeeProjectRepository.AddEmployeeProject(emp);

            }
           
            return RedirectToAction("Index", "Home");
        }


    }
}
