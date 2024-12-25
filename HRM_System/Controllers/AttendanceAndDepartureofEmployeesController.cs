using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HRM_System.Constants;
using HRM_System.Data;
using HRM_System.Data.Base;
using HRM_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRM_System.Controllers
{
    // [Authorize(Roles = Roles.HRAdmin)]
    public class AttendanceAndDepartureofEmployeesController : Controller
    {
        private readonly IEntityRepository<AttendanceAndDepartureofEmployees> _settingrepo;
        private readonly IEntityRepository<Employee> _employees;
        private readonly AppDbContext _context;

        public AttendanceAndDepartureofEmployeesController(IEntityRepository<AttendanceAndDepartureofEmployees> settingrepo, AppDbContext context, IEntityRepository<Employee> employees)
        {
            _settingrepo = settingrepo;
            _context = context;
            _employees = employees;
        }
        // [Authorize(permissions.Attendance.View)]

        public async Task<IActionResult> GetAll(int empId, DateTime startDate, DateTime endDate)
        {
            if (empId == 0)
            {
                return View((await _settingrepo.GetAllAsync()).Include(e => e.Employee));
            }
            else
            {
                return View(_settingrepo.GetEmployyeeByNameAsync(empId, startDate, endDate));
            }

        }

        //    [Authorize(permissions.Attendance.Create)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AttendanceAndDepartureofEmployees attendanceAndDepartureofEmployees)
        {
            if (ModelState.IsValid)
            {
                var employee = await (await _employees.GetAllAsync()).Where(e => e.Id == attendanceAndDepartureofEmployees.EmployeeId).Include(e => e.WorkData).FirstOrDefaultAsync();
                var newemployeeData = new AttendanceAndDepartureofEmployees()
                {
                    Date = attendanceAndDepartureofEmployees.Date,
                    Check_outDate = attendanceAndDepartureofEmployees.Check_outDate,
                    EmployeeId = attendanceAndDepartureofEmployees.EmployeeId,
                    Month= CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(attendanceAndDepartureofEmployees.Date.Month) ,
                    Discounthours = _settingrepo.CalcDiscountHours(employee.WorkData.Attendance,employee.WorkData.Departure, attendanceAndDepartureofEmployees.Date, attendanceAndDepartureofEmployees.Check_outDate),
                    Extrahours = _settingrepo.CalcExtraHours(employee.WorkData.Attendance, employee.WorkData.Departure, attendanceAndDepartureofEmployees.Date, attendanceAndDepartureofEmployees.Check_outDate),
                };
                await _settingrepo.AddAsync(newemployeeData);
                return RedirectToAction("GetAll" , "AttendanceAndDepartureofEmployees");

            }
            return View(attendanceAndDepartureofEmployees);
        }
        // [Authorize(permissions.Attendance.View)]
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                var emp = await(await _settingrepo.GetAllAsync()).Include(e => e.Employee).FirstOrDefaultAsync(a => a.Id == id.Value);
                return View(emp);
            }
            else
            {

                return NotFound();
            }
        }
        // [Authorize(permissions.Attendance.Edit)]
        public async Task<IActionResult> Edit(int? id)
        {
            return await Details(id);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int? id, AttendanceAndDepartureofEmployees attendanceAndDepartureofEmployees)
        {
            if (id != attendanceAndDepartureofEmployees.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var employee = await (await _employees.GetAllAsync()).Where(e => e.Id == attendanceAndDepartureofEmployees.EmployeeId).Include(e => e.WorkData).FirstOrDefaultAsync();
                    var newemployeeData = new AttendanceAndDepartureofEmployees()
                    {
                        Date = attendanceAndDepartureofEmployees.Date,
                        Check_outDate = attendanceAndDepartureofEmployees.Check_outDate,
                       
                        Discounthours = _settingrepo.CalcDiscountHours(employee.WorkData.Attendance, employee.WorkData.Departure, attendanceAndDepartureofEmployees.Date, attendanceAndDepartureofEmployees.Check_outDate),
                        Extrahours = _settingrepo.CalcExtraHours(employee.WorkData.Attendance, employee.WorkData.Departure, attendanceAndDepartureofEmployees.Date, attendanceAndDepartureofEmployees.Check_outDate),
                    };
                    await _settingrepo.UpdateAsync(newemployeeData);
                    return RedirectToAction(nameof(GetAll));
                }
                catch
                {
                    return View(attendanceAndDepartureofEmployees);
                }
            }
            return View(attendanceAndDepartureofEmployees);
        }
       
        //   [Authorize(permissions.Attendance.Delete)]
        public Task<IActionResult> Delete(int? id)
        {
            return Details(id);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int? id, AttendanceAndDepartureofEmployees data)
        {
            if (data.Id != id)
                return BadRequest();
            try
            {
                await _settingrepo.DeleteAsync(data);
                return RedirectToAction("GetAll");

            }
            catch
            {
                return View(data);
            }
        }
    }
}
