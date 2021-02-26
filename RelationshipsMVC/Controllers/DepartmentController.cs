using Microsoft.AspNetCore.Mvc;
using RelationshipsMVC.Repository;
using RelationshipsMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationshipsMVC.Controllers
{
    public class DepartmentController : Controller
    {

        private IEmployeeRepository _employeeRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IEmployeeRepository employeeRepository
            , IDepartmentRepository departmentRepository, IProjectRepository projectRepository)
        {
            _employeeRepository = employeeRepository;
            _projectRepository = projectRepository;
            _departmentRepository = departmentRepository;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDepartment(DepartmentModel deptModel)
        {

            _departmentRepository.AddDepartment(deptModel);
            return RedirectToAction("Index","Home");
        }

        public IActionResult DepartmentDetails()
        {
           var dept = _departmentRepository.GetDepartments();
            return View(dept);
        }


    }
}
