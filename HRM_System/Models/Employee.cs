using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HRM_System.Contants;

namespace HRM_System.Models
{
                                      //الموظفين
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your Address")]
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please enter a valid telephone number")]
        [MinLength(11)]
        public string PhoneNumber { get; set; }
        [Required]
        public string Deparment { get; set; }
        [Required]
        public GenderType Gender { get; set; }
        
        [Required]
        public string Nationality { get; set; }
        
        [Range(20,60,ErrorMessage = "The employee must be at least 20 years old")]
        public int Age { get; set; }
        [DataType(DataType.CreditCard)]
        [Required(ErrorMessage = "The national ID must not be less than 14 digits!")]
        [MinLength(14)]
        
        public string NationalID { get; set; }


        public  WorkData WorkData { get; set; }

        public ICollection<AttendanceAndDepartureofEmployees> AttendanceAndDepartureofEmployees { get; set; }
        
        public SalaryData SalaryData { get; set; }

    }
}
