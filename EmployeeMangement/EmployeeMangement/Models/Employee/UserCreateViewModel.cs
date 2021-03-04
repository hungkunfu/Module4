﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangement.Models.Employee
{
    public class UserCreateViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
       
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "ConfirmPassword Not Macth")]
        public string ConfirmPassword { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        [Display(Name ="Role")]
        public string RoleId { get; set; }
    }
}
