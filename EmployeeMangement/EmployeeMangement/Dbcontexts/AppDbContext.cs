using EmployeeMangement.Entities;
using EmployeeMangement.Models.Employee;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangement.Dbcontexts
{
    // identity d
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
       public  DbSet<Employee> Employees { get; set; }
        //public DbSet<Department> departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
         
            //modelBuilder.Entity<Department>().HasData(
            //    new Department()
            //    {
            //        DepartmentId = 1,
            //        DepartmentName = "IT",
            //        Email = "hungkunfu@gmail.com",
            //        PhoneNumber = "0834529293",
                  
            //    },
            //    new Department()
            //     {
            //        DepartmentId = 1,
            //        DepartmentName = "HR",
            //        Email = "hungkunfu@gmail.com",
            //        PhoneNumber = "0834529293",
                  
            //    });


            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
      
                    Age = 18,
                    AvatarPath = "~/images/avatar11.jpg",
                    Code = "CGH00001",
                    FirstName = "Khoa",
                    LastName = "Nguyen",
                    Email = "khoa.nguyen@codegym.vn",
                    EmployeeId = 1
                },
                new Employee()
                {
                    Age = 18,
                    AvatarPath = "~/images/avatar10.jpg",
                    Code = "CGH00002",
                    FirstName = "Hung",
                    LastName = "Tran",
                    Email = "hung.tran@codegym.vn",
                    EmployeeId = 2
                },
                new Employee()
                {
                    Age = 18,
                    AvatarPath = "~/images/avatar14.jpg",
                    Code = "CGH00003",
                    FirstName = "Huy",
                    LastName = "Phan",
                    Email = "hungphan@codegym.vn",
                    EmployeeId = 3
                });
        }
    }
}