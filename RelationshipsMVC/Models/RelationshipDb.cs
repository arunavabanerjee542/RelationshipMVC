using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationshipsMVC.Models
{
    public class RelationshipDb : DbContext
    {

        public RelationshipDb(DbContextOptions<RelationshipDb> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<EmployeeProject>().HasKey(
                k => new { k.EmployeeId, k.ProjectId }
                );

            mb.Entity<Employee>().HasData(
                   new Employee() { EmployeeId = 1, Ename = "Ram" },
                   new Employee() { EmployeeId = 2, Ename = "Shiv" },
                   new Employee() { EmployeeId = 3, Ename = "Krishna" });


            mb.Entity<Project>().HasData(
                new Project() { ProjectId=1,Pname="Employee Management"},
                new Project() { ProjectId = 2, Pname = "Student Management" }
                );

            mb.Entity<EmployeeProject>().HasData(
                new EmployeeProject() { EmployeeId = 1, ProjectId = 1 },
                new EmployeeProject() { EmployeeId = 1, ProjectId = 2 },
                new EmployeeProject() { EmployeeId = 2, ProjectId = 2 });
             
        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }

    }
}
