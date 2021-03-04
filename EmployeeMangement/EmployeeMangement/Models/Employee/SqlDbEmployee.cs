
using EmployeeMangement.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;


namespace EmployeeMangement.Models.Employee
{
    //public class SqlDbEmployee : IEmployee
    //{
    //    private readonly AppDbContext context;

    //    public SqlDbEmployee(AppDbContext context)
    //    {
    //        this.context = context;
    //    }

    //    public Employee Create(Employee employee)
    //    {
    //        context.Employees.Add(employee);
    //        context.SaveChanges();
    //        return employee;
    //    }

    //    public bool Delete(int id)
    //    {
    //        var delEmp = context.Employees.Find(id);
    //        if (delEmp != null)
    //        {
    //            context.Employees.Remove(delEmp);
    //            return context.SaveChanges() > 0;
    //        }
    //        return false;
    //    }  

    //    public Employee Edit(Employee employee)
    //    {
    //        var editEmp = context.Employees.Attach(employee);
    //        editEmp.State = EntityState.Modified;
    //        context.SaveChanges();
    //        return employee;  
    //    }

    //    public Employee Get(int id)
    //    {
    //        return context.Employees.Find(id);
    //    }

    //    public IEnumerable<Employee> Gets()
    //    {
    //        return context.Employees;
    //    }
    
}
