using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;                  
using System.Threading.Tasks;

namespace EmployeeMangement.Entities
{

            
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(10)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(500)]
        public string AvatarPath { get; set; }
        [Required]
        [MaxLength(8)]
        public string Code { get; set; }
       
     

    }
}
