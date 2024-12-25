using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.ConstrainedExecution;

namespace HRM_System.Models
{
    public class SalaryData
    {
        [Key]
        public int SalaryId { get; set; }

        public int RecordDays { get; set; }

        public int Daysofabsence { get; set; }

        public int ExtraTotal { get; set; }
       
        public int TotalDiscount { get; set; }

        public int Additional_hours { get; set; }

        public int Discount_per_hour { get; set; }


        public int? EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        public int? WorkDateId { get; set; }
        [ForeignKey(nameof(WorkDateId))]
        public WorkData WorkData { get; set; }

        public int? GeneralSettingsId { get; set; }
        [ForeignKey(nameof(GeneralSettingsId))]
        public GeneralSettings GeneralSettings { get; set; }

        public int? OfficialleavesettingsId { get; set; }
        [ForeignKey(nameof(OfficialleavesettingsId))]
        public Officialleavesettings Officialleavesettings{ get; set; }

        public int? AttendanceAndDepartureofEmployeesId { get; set; }
        [ForeignKey(nameof(AttendanceAndDepartureofEmployeesId))]
        public AttendanceAndDepartureofEmployees AttendanceAndDepartureofEmployees { get; set; }
    }
}
