using Microsoft.AspNetCore.Mvc;
using RelationshipsMVC.Models;
using RelationshipsMVC.Repository;
using RelationshipsMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationshipsMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeController(IEmployeeRepository employeeRepository
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

        public IActionResult Details()
        {
          IEnumerable<Employee> employees = _employeeRepository.GetEmployees();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var empViewModel = new EmployeeViewModel()
            {
                DepartmentList = _departmentRepository.GetDepartments(),
                ProjectList = _projectRepository.GetProjects()
            };
            
            return View(empViewModel);
        }

        [HttpPost]
        public IActionResult Add(EmployeeViewModel employeeModel)
        {
            //_employeeRepository.Add(employee);
            return Redirect("Home/Index");
        }

    }
}
