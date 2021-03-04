using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangement.Models.Employee
{
    public class CreateEmployee : ViewEmployee
    {
        public IFormFile Avatar { get; set; }
    }
}
