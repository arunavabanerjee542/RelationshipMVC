using Microsoft.AspNetCore.Mvc;
using RelationshipsMVC.Infrastructure;
using RelationshipsMVC.Models;
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

        private int maxAllowedPageContent = 3;
        public IActionResult Index(string category, int pagesize = 1)
        {
             IEnumerable<Department> cat = null;
            if (category != null)
            {
                cat = _departmentRepository
                    .GetDepartments()
                    .Where(dept => dept.DeptName.Equals(category))
                    .Skip(maxAllowedPageContent * (pagesize - 1))
                    .Take(maxAllowedPageContent);
                    
            }

            return View(new DepartmentViewModel()
            {
                Departments = cat,
                PagingInfo = new Paging()
                {
                    CurrentPage = pagesize,
                    TotalItems = cat!=null ? cat.Sum(d => d.Employees.Count()) : 0,
                    TotalPages = cat!= null ?  cat.Sum(d => d.Employees.Count()) / maxAllowedPageContent : 0
                }

            }) ;
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
