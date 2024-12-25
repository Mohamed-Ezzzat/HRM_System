using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HRM_System.Contants;

namespace HRM_System.Models
{
    //الاعدادات العامله
    public class GeneralSettings
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Additional { get; set; }

        [Required]
        public int Discount { get; set; }

        [Required]
        public DayOfWeek Thedayofthefirstofficialvacation { get; set; }

        public DayOfWeek? Thesecondofficialvacationday { get; set; }

        public SalaryData SalaryData { get; set; }
    }
}
