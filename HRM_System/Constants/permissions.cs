using System;
using System.Collections.Generic;
using System.Reflection;
using HRM_System.Constants;

namespace Constants
{
    public static class permissions
    {
        public static List<string> GeneratePermissionsList(string module)
        {
            return new List<string>()
            {
                $"Permissions_{module}_View",
                $"Permissions_{module}_Create",
                $"Permissions_{module}_Edit",
                $"Permissions_{module}_Delete",
            };
        }

        public static List<string> GenerateAllPermissions()
        {
            var allPermissions = new List<string>();

            var modules = Enum.GetValues(typeof(Pages));

            foreach (var module in modules)
                allPermissions.AddRange(GeneratePermissionsList(module.ToString()));

            return allPermissions;
        }

        public static class AttendanceAndDeparture
        {
            public const string View = "Permissions_AttendanceAndDeparture_View";
            public const string Create = "Permissions_AttendanceAndDeparture_Create";
            public const string Edit = "Permissions_AttendanceAndDeparture_Edit";
            public const string Delete = "Permissions_AttendanceAndDeparture_Delete";
        }
        public static class Employee
        {
            public const string View = "Permissions_Employee_View";
            public const string Create = "Permissions_Employee_Create";
            public const string Edit = "Permissions_Employee_Edit";
            public const string Delete = "Permissions_Employee_Delete";
        }
        public static class Payrollreport
        {
            public const string View = "Permissions_Payrollreport_View";
            public const string Create = "Permissions_Payrollreport_Create";
            public const string Edit = "Permissions_Payrollreport_Edit";
            public const string Delete = "Permissions_Payrollreport_Delete";
        }
        //public static class GeneralSettings
        //{
        //    public const string View = "Permission_GeneralSettings_View";
        //    public const string Create = "Permission_GeneralSettings_Create";
        //    public const string Edit = "Permission_GeneralSettings_Edit";
        //Permissions_Admin_View
        //    public const string Delete = "Permission_GeneralSettings_Delete";
        //}
        public static class Admin
        {
            public const string View = "Permissions_Admin_View";
            public const string Create = "Permissions_Admin_Create";
            public const string Edit = "Permissions_Admin_Edit";
            public const string Delete = "Permissions_Admin_Delete";
        }
        public static class Officialleavesettings
        {
            public const string View = "Permissions_Officialleavesettings_View";
            public const string Create = "Permissions_Officialleavesettings_Create";
            public const string Edit = "Permissions_Officialleavesettings_Edit";
            public const string Delete = "Permissions_Officialleavesettings_Delete";
        }
    }
}
