using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using HRM_System.Constants;
using HRM_System.Data;
using HRM_System.Data.Base;
using HRM_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Employee = HRM_System.Models.Employee;

namespace HRM_System.Controllers
{
    //[Authorize(Roles =Roles.HRAdmin)]
    public class EmployeesController : Controller
    {
        private readonly IEntityRepository<Employee> _EmpRepo;
        private readonly IEntityRepository<WorkData> _dataRepo;
        private readonly AppDbContext _context;

        public EmployeesController(IEntityRepository<Employee> EmpRepo, IEntityRepository<WorkData> dataRepo, AppDbContext context)
        {
            _EmpRepo = EmpRepo;
            _dataRepo = dataRepo;
            _context = context;
        }
       // [Authorize(permissions.Employee.View)]

        public async Task<IActionResult> All()
        {
            var employee = (await _EmpRepo.GetAllAsync()).Include(e=>e.WorkData);
            
            return View(employee);
        }
     //   [Authorize(permissions.Employee.Create)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var spec = new GetNationalIDofEmployee(employee.NationalID);
                var N_ID = await _EmpRepo.GetByNationalIDWithSpecAsync(spec);

                if (N_ID != null)
                {
                    ModelState.AddModelError("NationalID", "There is another person registered with this national number");
                    return View(employee);
                }
               
                await _EmpRepo.AddAsync(employee);
                return RedirectToAction("All");
            }
            return View(employee );
        }
       // [Authorize(permissions.Employee.View)]

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
            var employee = await _EmpRepo.GetByIdAsync((int)id);

                if (employee != null)
                {
                    
                    await _context.Entry(employee)
                        .Reference(e => e.WorkData)
                        .LoadAsync();

                    return View(employee);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }

       // [Authorize(permissions.Employee.Edit)]

        public async Task<IActionResult> Edit (int? id)
        {
            return await Details(id);
        }

       
        //[HttpPost]
        //public async Task<IActionResult> Edit([FromRoute] int? id, Employee employee)
        //{
        //    if (id != employee.Id)
        //        return BadRequest();
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            await _EmpRepo.UpdateAsync(employee);
        //            return RedirectToAction("All");
        //        }
        //        catch
        //        {
        //            return View(employee);
        //        }
        //    }
        //    return View(employee);
        //}
        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int? id, Employee employee)
        {
            if (id != employee.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                var spec = new GetNationalIDofEmployee(employee.NationalID);
                var N_ID = await _EmpRepo.GetByNationalIDWithSpecAsync(spec);

                if (N_ID != null)
                {
                    ModelState.AddModelError("National ID", "There is another person registered with this National ID");
                    return View(employee);
                }
                var emp = (await _EmpRepo.GetByIdAsync((int)id));
                var workdate = await _context.WorkDatas.Include(e => e.Employee)
                .FirstOrDefaultAsync(e => e.EmployeeId == employee.Id);
                if (emp != null)
                {
                    emp.Name = employee.Name;
                    emp.Address = employee.Address;
                    emp.Age = employee.Age;
                    emp.Deparment = employee.Deparment;
                    emp.Gender = employee.Gender;
                    emp.NationalID = employee.NationalID;
                    emp.Nationality = employee.Nationality;
                    emp.PhoneNumber = employee.PhoneNumber;
                }
                if (workdate != null)
                {
                    workdate.Salary = employee.WorkData.Salary;
                    workdate.Dateofcontract = employee.WorkData.Dateofcontract;
                    workdate.Attendance = employee.WorkData.Attendance;
                    workdate.Departure = employee.WorkData.Departure;

                    workdate.EmployeeId = employee.Id;
                }
                await _EmpRepo.UpdateAsync(emp);
                await _dataRepo.UpdateAsync(workdate);
                return RedirectToAction(nameof(All));

            }

            return View(employee);
        }
        //  [Authorize(permissions.Employee.Delete)]

        public async Task<IActionResult> Delete(int? id)
        {
            return await Details(id);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute]int? id , Employee employee)
        {
            if (employee.Id != id)
                return BadRequest();
            var data = await _context.WorkDatas.Include(e=>e.Employee)
                .FirstOrDefaultAsync(e => e.EmployeeId == employee.Id);
            var delemp = await _EmpRepo.GetByIdAsync((int)id);
            try
            {
               await _dataRepo.DeleteAsync(data);
               await _EmpRepo.DeleteAsync(delemp);
                return RedirectToAction("All");

            }
            catch
            {
                return View(employee);
            }
        }
    }
}
