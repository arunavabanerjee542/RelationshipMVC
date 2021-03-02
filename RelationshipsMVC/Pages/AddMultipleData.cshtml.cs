using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RelationshipsMVC.Models;
using RelationshipsMVC.Repository;
using RelationshipsMVC.ViewModel;

namespace RelationshipsMVC.Pages
{
    public class AddMultipleDataModel : PageModel
    {
        private IEmployeeRepository _employeeRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public AddMultipleDataModel(IEmployeeRepository employeeRepository
            , IDepartmentRepository departmentRepository, IProjectRepository projectRepository)
        {
            _employeeRepository = employeeRepository;
            _projectRepository = projectRepository;
            _departmentRepository = departmentRepository;
        }
        [BindProperty]
        public EmployeeViewModel Employee  { get; set; }
        [BindProperty]
        public DepartmentModel Department { get; set; }
        [BindProperty]
        public ProjectViewModel Project { get; set; }
        public IEnumerable<Department> Departments { get; set; }

        public void OnGet()
        {
          

        }

        public dynamic GetDept()
        {
            return Departments = _departmentRepository.GetDepartments();
        }

        public IActionResult OnPostEmployeeModelHandler()
        {
            _employeeRepository.AddEmployeeWithProjects(Employee);
            return RedirectToPage();
        }

        public IActionResult OnPostDepartmentModelHandler()
        {
            _departmentRepository.AddDepartment(Department);
            return RedirectToPage();
        }


        public void OnPostProjectModelHandler(ProjectViewModel projectViewModel)
        {

        }



    }
}
