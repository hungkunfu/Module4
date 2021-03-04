using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangement.Models.Employee
{
    public class EditRole
    {
        public string RoleId { get; set; }
        [Required]  
        public String RoleName { get; set; }
    }
}
