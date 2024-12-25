using System;
using System.Collections.Generic;

namespace HRM_System.Models.ViewModel
{
    public class SalaryView
    {
        public string Name { get; set; }
        public Months Month { get; set; }
        public int Years { get; set; } 
    }
    
    public enum Months
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December,
    }
}
