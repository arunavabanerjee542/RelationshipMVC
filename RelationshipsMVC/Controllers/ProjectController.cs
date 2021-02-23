using Microsoft.AspNetCore.Mvc;
using RelationshipsMVC.Repository;
using RelationshipsMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationshipsMVC.Controllers
{
    public class ProjectController : Controller
    {

        private IEmployeeRepository _employeeRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public ProjectController(IEmployeeRepository employeeRepository
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
        public IActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProject(ProjectViewModel projectView)
        {
            _projectRepository.AddProject(projectView);
            return RedirectToAction("Index", "Home");
        }
    }
}
