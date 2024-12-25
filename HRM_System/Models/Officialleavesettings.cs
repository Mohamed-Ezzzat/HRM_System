using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM_System.Models
{
    public class Officialleavesettings
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateTime { get; set; }

        public SalaryData SalaryData { get; set; }

    }
}
