using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangement.Models.Employee
{
    public class RegisterViewModel
    {
        // bat buoc nhap dung requier
        [Required]
        [EmailAddress]
        //[Remote("EmailInUse", "Account", ErrorMessage ="Email da ton tai")]
        public string Email { get; set; }
        [Required]
        // an passwword
        [DataType(DataType.Password)]
        
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = " Confirm Password not Mach")]
        public string ConfirmPassword { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
