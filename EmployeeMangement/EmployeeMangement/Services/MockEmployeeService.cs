using EmployeeMangement.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangement.Services
{
    public class MockEmployeeService : IEmployeeService
    {
        public List<ViewEmployee> employees;
        public MockEmployeeService()
        {
            employees = new List<ViewEmployee>()
            {
                new ViewEmployee()
                {
                    Age = 18,
                    AvatarPath = "~/images/a1.jpg",
                    Code = "CGH001",
                    Firstname = "Hung",
                    Lastname = "Tran",
                    Id = 1
                },
                new ViewEmployee()
                {
                    Age = 18,
                    AvatarPath = "~/images/a3.jpg",
                    Code = "CGH002",
                    Firstname = "Dieu",
                    Lastname = "Hanh",
                    Id = 2
                },
                new ViewEmployee()
                {
                    Age = 18,
                    AvatarPath = "~/images/a2.jpg",
                    Code = "CGH003",
                    Firstname = "Huy",
                    Lastname = "Phan",
                    Id = 3
                }
            };
        }

        public bool Create(ViewEmployee request)
        {
            try
            {
                request.Id = employees.Max(e => e.Id) + 1;
                employees.Add(request);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var delEmp = Get(id);
            if(delEmp != null)
            {
                employees.Remove(delEmp);
                return true;
            }
            return false;
        }

        public bool Edit(ViewEmployee request)
        {
            try
            {
                var employee = Get(request.Id);
                employee.Firstname = request.Firstname;
                employee.Lastname = request.Lastname;
                employee.Age = request.Age;
                employee.Email = request.Email;
                employee.AvatarPath = request.AvatarPath;
                employee.Code = request.Code;
                employee.Phone = request.Phone;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ViewEmployee Get(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public List<ViewEmployee> Gets()
        {
            return employees;
        }

        public bool Remove(ViewEmployee request)
        {
            throw new NotImplementedException();
        }
    }
}
