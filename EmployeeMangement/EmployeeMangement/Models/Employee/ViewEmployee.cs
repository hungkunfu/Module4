using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangement.Models.Employee
{
    public class ViewEmployee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Code is required")]
        [Display(Name = "Employee Code")]
        [StringLength(maximumLength:8, MinimumLength =8, ErrorMessage = "Employee code must 8 characters")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Fristname is required")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        public string Lastname { get; set; }
        public string Fullname => $"{Firstname} {Lastname}";
        public string AvatarPath { get; set; }
        [Required(ErrorMessage = "Age is required")]
        [Range(minimum:18, maximum:60, ErrorMessage ="Age must between 18 and 60")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression("^(0?)(3[2-9]|5[6|8|9]|7[0|6-9]|8[0-6|8|9]|9[0-4|6-9])[0-9]{7}$", ErrorMessage = "Invalid Phone")]
        public string Phone { get; set; }
    }
}
