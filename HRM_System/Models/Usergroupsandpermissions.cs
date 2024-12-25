using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HRM_System.Constants;

namespace HRM_System.Models
{
	public class Usergroupsandpermissions
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }

        public bool Permission_Employee_Create { get; set; }
        public bool Permission_Employee_View { get; set; }
        public bool Permission_Employee_Edit { get; set; }
        public bool Permission_Employee_Delete { get; set; }

        public bool Permission_Payroll_Create { get; set; }
        public bool Permission_Payroll_View { get; set; }
        public bool Permission_Payroll_Edit { get; set; }
        public bool Permission_Payroll_Delete { get; set; }

        public bool Permission_GeneralSettings_Create { get; set; }
        public bool Permission_GeneralSettings_View { get; set; }
        public bool Permission_GeneralSettings_Edit { get; set; }
        public bool Permission_GeneralSettings_Delete { get; set; }

        public bool Permission_Attendance_Create { get; set; }
        public bool Permission_Attendance_View { get; set; }
        public bool Permission_Attendance_Edit { get; set; }
        public bool Permission_Attendance_Delete { get; set; }


    
	}
}
