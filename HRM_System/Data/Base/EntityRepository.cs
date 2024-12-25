using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HRM_System.Models;
using HRM_System.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace HRM_System.Data.Base
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _entities;

        public EntityRepository(AppDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _entities.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
                return _entities.AsQueryable();

            return _entities.Where(predicate);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _entities.FindAsync(id);
            return result;
        }

        public async Task UpdateAsync(T entity)
        {
            _entities.Update(entity);

            await _context.SaveChangesAsync();

        }

        //حساب الساعات الاضافية في شهر معين
        public int CalcExtraHours(
            TimeSpan attendanceFromWorkDate,
            TimeSpan departureFromWorkDate,
            DateTime standartDateFromAttendance,
            DateTime checkOutDateFromAttendance)
        {
            int x = ((departureFromWorkDate.Hours + 12) - (attendanceFromWorkDate.Hours)); //عدد ساعات الحضور في اليوم الواحد
            int y = (checkOutDateFromAttendance.TimeOfDay.Hours) - (standartDateFromAttendance.TimeOfDay.Hours);
            if (y > x)
            {
                y = y - x;
            }
            else if (x > y)
            {
                y = y - y;
            }
            return y;
        }
        //حساب ساعات الخصم في شهر معين
        public int CalcDiscountHours(
            TimeSpan attendanceFromWorkDate,
            TimeSpan departureFromWorkDate,
            DateTime standartDateFromAttendance,
            DateTime checkOutDateFromAttendance)
        {
            int x = ((departureFromWorkDate.Hours + 12) - (attendanceFromWorkDate.Hours)); //عدد ساعات الحضور في اليوم الواحد
            int y = (checkOutDateFromAttendance.TimeOfDay.Hours) - (standartDateFromAttendance.TimeOfDay.Hours);

            if (x > y)
            {
                y = x - y;
            }
            else if (y > x)
            {
                y = x - x;
            }
            return y;
        }
        //حساب الايام الفعليه التي حضرها في شهر معين
        public int Getrecorddays(int id, string month, int year) =>
            _context.AttendanceAndDepartureofEmployees
                .Count(a => a.EmployeeId == id && a.Month == month && a.year == year);

        public List<AttendanceAndDepartureofEmployees> ListofAttendanceDays(int id, string month, int year)
        {
            var listofAttendanceDays = _context.AttendanceAndDepartureofEmployees
             .Where(a => a.EmployeeId == id && a.Month == month && a.year == year)
              .ToList();

            return listofAttendanceDays;
        }
        //عمل قائمة من الايام في شهر معين
        public List<DateTime> GetDayinMonth(int year, int month)
        {
            int countOfDaysInMonth = DateTime.DaysInMonth(year, (int)month);

            List<DateTime> allDaysInMonth = new();

            for (int i = 1; i <= countOfDaysInMonth; i++)
                allDaysInMonth.Add(new DateTime(year, (int)month, i));
            return allDaysInMonth;
        }

        //الايام الي من المفترض انه يحضرها الشهر دا
        public List<DateTime> GetAccoulDayesinMonth(Months month, int year)
        {
            List<DateTime> holiDaysInCurrentMonth = _context.OfficialleaveSettings
                .Where(e => e.DateTime.Month == (int)month)
                .Select(e => e.DateTime)
                .ToList();

            List<DateTime> allDaysInMonth = GetDayinMonth(year, (int)month);
            var holiDaysInCurrentWeek = _context.GeneralSettings.Select(e => new
            {
                TheFirstDay = e.Thedayofthefirstofficialvacation,
                TheSecondDay = e.Thesecondofficialvacationday,
            }).ToList();

            // Combine holidays in the current week and month
            var holidaysToExclude = holiDaysInCurrentWeek.SelectMany(hdw => allDaysInMonth.Where(day => day.DayOfWeek == hdw.TheFirstDay || day.DayOfWeek == hdw.TheSecondDay))
                .Concat(holiDaysInCurrentMonth);

            // Filter out holidays
            List<DateTime> requiredDays = allDaysInMonth.Except(holidaysToExclude).ToList();

            return requiredDays;
            //var holiDaysInCurrentWeek = _context.GeneralSettings.Select(e => new
            //{
            //    TheFirstDay = e.Thedayofthefirstofficialvacation,
            //    TheSecondDay = e.Thesecondofficialvacationday,
            //}).ToList();


            //List<DateTime> requiredDays = allDaysInMonth;

            //holiDaysInCurrentWeek.ForEach(hdw =>
            //{
            //    allDaysInMonth = new(allDaysInMonth.SkipWhile(e => e.DayOfWeek == hdw.TheFirstDay || e.DayOfWeek == hdw.TheSecondDay));
            //    requiredDays = allDaysInMonth;
            //});

            //holiDaysInCurrentMonth.ForEach(hdi =>
            //{
            //    allDaysInMonth = new List<DateTime>(allDaysInMonth.SkipWhile(e => e.Month == hdi.Month || e.Day == hdi.Day));
            //    requiredDays = allDaysInMonth;
            //});

            //return requiredDays;
        }

        //الساعات الاضافية في الشهر الواحد
        public int GetExtraTotalHoursPerMonth(int id, Months month, int year)
        {
            var listofattend = ListofAttendanceDays(id, month.ToString(), year);
            int extraHours = 0;
            foreach (var day in listofattend)
            {
                extraHours += day.Extrahours;
            };
            return extraHours;

        }
        //ساعات الخصم في الشهر الواحد
        public int GetTotalDiscountHoursPerMonth(int id, Months month, int year)
        {
            var listofattend = ListofAttendanceDays(id, month.ToString(), year);
            int extraHours = 0;
            foreach (var day in listofattend)
            {
                extraHours += day.Discounthours;
            };
            return extraHours;

        }
        //حساب ايام الغياب
        public int GetDaysofAbsence(int id, Months month, int year)
        {
            List<DateTime> requiredDays = GetAccoulDayesinMonth(month, year); //الايام الي المفروض يحضرها 
            int accualDays = Getrecorddays(id, month.ToString(), year); //الايام الي حضرها فعليا
            // هحسب المرتب النهائي بعد الخصم والاضافي
            int DiscountDays = requiredDays.Count - accualDays;

            return DiscountDays;

        }
        //اجمالي الاضافي في الشهر
        public int GetExtraTotalPerMonth(int id, Months month, int year)
        {
            var salary = _context.WorkDatas
                .Where(a => a.EmployeeId == id)
                .Select(a => a.Salary)
                .FirstOrDefault(); // المرتب الاساسي للموظف


            // الايام الي موجوده في الشهر الي بحسب فيه المرتب 
            int requiredDayesInMonth = GetDayinMonth(year, (int)month).Count();


            int costperday = salary / requiredDayesInMonth; // تكلفة اليوم الواحد

            var Endofday = _context.WorkDatas // هنجيب وقت الانصراف الاساسي 
                .Where(w => w.EmployeeId == id)
                .Select(w => w.Departure)
                .FirstOrDefault();

            var Startofday = _context.WorkDatas // وقت الحضور الاساسي
                .Where(w => w.EmployeeId == id)
                .Select(w => w.Attendance)
                .FirstOrDefault();

            int WorkhoursinDay = (Endofday.Hours + 12) - Startofday.Hours; // عدد ساعات العمل في اليوم الواحد

            int costPerHour = costperday / WorkhoursinDay;


            var listofattend = ListofAttendanceDays(id, month.ToString(), year);
            int extraHours = 0;
            foreach (var day in listofattend)
            {
                extraHours += day.Extrahours;
            };

            List<DateTime> requiredDays = GetAccoulDayesinMonth(month, year); //الايام الي المفروض يحضرها 
            int accualDays = Getrecorddays(id, month.ToString(), year); //الايام الي حضرها فعليا
            int accualExtraperDay = 0;
            if (accualDays > requiredDays.Count)
            {

                // هحسب المرتب النهائي بعد الخصم والاضافي

                int extDayscount = accualDays - requiredDays.Count;

                accualExtraperDay = extDayscount * costperday;


            }
            var additionalHoursComaperdByStandardHours = _context.GeneralSettings
               .Select(a => a.Additional)
               .FirstOrDefault();

            int ExtraCost = (costPerHour * extraHours * additionalHoursComaperdByStandardHours) + accualExtraperDay;

            return ExtraCost;
        }
        //حساب الخصم الكلي  للساعات في شهر معين
        public int GetTotalDiscountPerMonth(int id, Months month, int year)
        {
            var salary = _context.WorkDatas
                 .Where(a => a.EmployeeId == id)
                 .Select(a => a.Salary)
                 .FirstOrDefault(); // المرتب الاساسي للموظف

            int requiredDayesInMonth = GetDayinMonth(year, (int)month).Count(); // month 

            int costperday = salary / requiredDayesInMonth; // تكلفة اليوم الواحد

            var Endofday = _context.WorkDatas // هنجيب وقت الانصراف الاساسي 
                .Where(w => w.EmployeeId == id)
                .Select(w => w.Departure)
                .FirstOrDefault();

            var Startofday = _context.WorkDatas // وقت الحضور الاساسي
                .Where(w => w.EmployeeId == id)
                .Select(w => w.Attendance)
                .FirstOrDefault();

            int Workhours = (Endofday.Hours + 12) - Startofday.Hours; // عدد ساعات العمل في اليوم الواحد

            int costPerHour = costperday / Workhours;//تكلفة اليوم الواحد

            var listofattend = ListofAttendanceDays(id, month.ToString(), year);//تقرير حضور وانصراف المزظف في شهر معين
            int discountHours = 0;
            foreach (var day in listofattend)
            {
                discountHours += day.Discounthours;// الساعات الاضافية الكلية في الشهر المعين
            };

            List<DateTime> requiredDays = GetAccoulDayesinMonth(month, year); //الايام الي المفروض يحضرها 
            int accualDays = Getrecorddays(id, month.ToString(), year); //الايام الي حضرها فعليا
            int accualExtraperDay = 0;
            if (requiredDays.Count > accualDays)
            {
                // هحسب المرتب النهائي بعد الخصم والاضافي
                int DiscountDays = requiredDays.Count - accualDays;

                accualExtraperDay = DiscountDays * costperday;
            }

            var discountHoursComaperdByStandardHours = _context.GeneralSettings
               .Select(a => a.Discount)
               .FirstOrDefault();

            int DiscountCost = (costPerHour * discountHours * discountHoursComaperdByStandardHours) + accualExtraperDay;

            return DiscountCost;
        }
        //حساب المرتب الي المفروض يقبضه الموظف في شهر معين بنائا علي حضوره
        public async Task<int> GetNetSalary(int employeeId, Months month, int year)
        {
            var salary = _context.WorkDatas
                 .Where(a => a.EmployeeId == employeeId)
                 .Select(a => a.Salary)
                 .FirstOrDefault(); // المرتب الاساسي للموظف
            int extratotalpermonth = GetExtraTotalPerMonth(employeeId, month, year);
            int totaldiscountpermonth = GetTotalDiscountPerMonth(employeeId, month, year);

            int netSalary = (salary + extratotalpermonth) - totaldiscountpermonth;
            return netSalary;
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<T> GetByIdWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();

        }
        public async Task<T> GetByNameWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();

        }
        public async Task<T> GetByNationalIDWithSpecAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>(), spec);
        }

        public IEnumerable<AttendanceAndDepartureofEmployees> GetEmployyeeByNameAsync(int empId, DateTime startDate, DateTime endDate)
        {
            var query = _context.AttendanceAndDepartureofEmployees.Where(a => a.EmployeeId == empId).ToList();

            DateTime start = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0);
            DateTime end = new DateTime(endDate.Year, endDate.Month, endDate.Day, 0, 0, 0);


            query = query.Where(a =>
             new DateTime(a.Date.Year, a.Date.Month, a.Date.Day, 0, 0, 0) >= start &&
             new DateTime(a.Date.Year, a.Date.Month, a.Date.Day, 0, 0, 0) <= end).ToList();



            return query;
        }

        public IEnumerable<AttendanceAndDepartureofEmployees> GetEmployyeeByNameAsync(DateTime startDate, DateTime endDate)
        {
            var result = _context.AttendanceAndDepartureofEmployees
                     .Where(a => a.Date >= startDate && a.Date <= endDate);
            return result;
        }
    }
}
