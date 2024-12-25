using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM_System.Models
{
                                  //بيانات العمل
    public class WorkData
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a valid contract date")]
        public DateTime Dateofcontract { get; set; }//تاريخ التعاقد 
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Please enter a valid salary")]
        public int Salary { get; set; }

        [Required]
        public TimeSpan Attendance { get;set; }//موعد الحضور 
        [Required]
        public TimeSpan Departure { get;set; }//موعد الانصراف 


        public int EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee Employee { get; set; }

        
        public SalaryData SalaryData { get; set; }

    }
}
