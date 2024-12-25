using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HRM_System.Models;
using HRM_System.Models.ViewModel;

namespace HRM_System.Data.Base
{
    public interface IEntityRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
        IEnumerable<AttendanceAndDepartureofEmployees> GetEmployyeeByNameAsync(int empId, DateTime startDate, DateTime endDate);
        IEnumerable<AttendanceAndDepartureofEmployees> GetEmployyeeByNameAsync(DateTime startDate, DateTime endDate);
        Task<T> GetByIdAsync(int id);
        //Task<Officialleavesettings> GetByNameAsync(string name);
        Task<T> GetByIdWithSpecAsync(ISpecification<T> spec);
        Task<T> GetByNameWithSpecAsync(ISpecification<T> spec);
        Task<T> GetByNationalIDWithSpecAsync(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec);
        Task AddAsync (T entity);
        Task UpdateAsync (T entity);
        Task DeleteAsync (T entity);
       
        int CalcDiscountHours(
            TimeSpan attendanceFromWorkDate,
            TimeSpan departureFromWorkDate,
            DateTime standartDateFromAttendance,
            DateTime checkOutDateFromAttendance);
        int CalcExtraHours(
            TimeSpan attendanceFromWorkDate,
            TimeSpan departureFromWorkDate,
            DateTime standartDateFromAttendance,
            DateTime checkOutDateFromAttendance);

        int GetExtraTotalHoursPerMonth(int id, Months month, int year);
        int GetTotalDiscountHoursPerMonth(int id, Months month, int year);
        int Getrecorddays(int id , string month , int year);
        int GetExtraTotalPerMonth(int id, Months month, int year);
        int GetTotalDiscountPerMonth(int id, Months month, int year);
        int GetDaysofAbsence(int id, Months month, int year);
        Task<int> GetNetSalary(int employeeId, Months month, int year);
    }
}
