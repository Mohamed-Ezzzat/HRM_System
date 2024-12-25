using System;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace HRM_System.Models
{
    public class AttendanceAndDepartureofEmployees
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; } 

        [Required]
        public DateTime Check_outDate { get; set; }
        public string Month { get;  set; }

        //public void UpdateMonthName()
        //{
        //    try
        //    {
        //        // استخراج اسم الشهر بالإنجليزية
        //        int monthNumber = Date.Month;
        //        string monthNameInEnglish = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthNumber);

        //        // تخزين اسم الشهر في الخاصية Month
        //        Month = monthNameInEnglish;
        //    }
        //    catch (Exception ex)
        //    {
        //        // يمكنك إضافة إجراءات الخطأ المناسبة هنا
        //        Console.WriteLine($"Error updating Month property: {ex.Message}");
        //    }
        //}
        ////public string Month
        ////{
        ////    get { return Date.Month.ToString("MMMM", new CultureInfo("ar-EG")); }

        ////    set { value = Date.Month.ToString(); }
        ////}

        public int year
        {
            get { return Date.Year; }
            set { value = Date.Year; }
        }

        public string TimeAttendance
        {
            get { return Date.TimeOfDay.ToString(); } 
            set { value = Date.TimeOfDay.ToString(); }
        }
        public string Check_outTime
        {
            get { return Check_outDate.TimeOfDay.ToString(); }
            set { value = Check_outDate.TimeOfDay.ToString(); }
        }
        public int Extrahours{ get; set; } = 0; // TODo: logic
        public int Discounthours{get; set;} = 0; // ToDo: logic

        public int EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        public  WorkData WorkData { get; set; }

        public SalaryData SalaryData { get; set; }
    }
}
