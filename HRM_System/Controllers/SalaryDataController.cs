using System;
using System.Linq;
using System.Threading.Tasks;
using HRM_System.Data.Base;
using HRM_System.Models;
using HRM_System.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRM_System.Controllers
{
    public class SalaryDataController : Controller
    {
        private readonly IEntityRepository<SalaryData> _salaryRepo;
        private readonly IEntityRepository<Employee> _empRepo;

        public SalaryDataController(IEntityRepository<SalaryData> salaryRepo,
            IEntityRepository<Employee> empRepo)
        {
            _salaryRepo = salaryRepo;
            _empRepo = empRepo;
        }

        //public IActionResult GetSalary()
        //{
        //    return View();
        //}

        //[HttpPost]
        public async Task<IActionResult> GetSalary(string Name, Months Month, int Year)
        {

            var employee = (await _empRepo.GetAllAsync(e => e.Name.Contains(Name))).FirstOrDefault();
            if (employee == null)
            {
                return View();
            }
            else
            {
                return await Details(Name, Month, Year);
            }

        }

        
        public async Task<IActionResult> Details(string Name, Months Month, int Year)
        {
            var employee = (await _empRepo.GetAllAsync(e => e.Name.Contains(Name))).Include(e=>e.WorkData).FirstOrDefault();
            if (employee == null)
            {
                return NotFound();
            }
            int recorddays = _salaryRepo.Getrecorddays(employee.Id, Month.ToString(), Year);
            int daysofabsence = _salaryRepo.GetDaysofAbsence(employee.Id, Month, Year);
            int additional_hours = _salaryRepo.GetExtraTotalHoursPerMonth(employee.Id, Month, Year);
            int discount_per_hour = _salaryRepo.GetTotalDiscountHoursPerMonth(employee.Id, Month, Year);
            int extratotal = _salaryRepo.GetExtraTotalPerMonth(employee.Id, Month, Year);
            int totaldiscount = _salaryRepo.GetTotalDiscountPerMonth(employee.Id, Month, Year);
            int netsalary = await _salaryRepo.GetNetSalary(employee.Id, Month, Year);

            var salary = new SalaryDataViewModel()
            {
                EmployeeName = Name,
                Department = employee.Deparment,
                Salary = employee.WorkData.Salary,
                RecordDays =recorddays,
                Daysofabsence = daysofabsence,
                Additional_hours =additional_hours,
                Discount_per_hour =discount_per_hour,
                ExtraTotal =extratotal,
                TotalDiscount =totaldiscount,
                NetSalary = netsalary,
            };

            return View(salary);
        }

        //public ActionResult PrintSalary(int employeeId)
        //{
        //    var employee = _salaryRepo.GetByIdAsync(employeeId);

        //    return View("PrintSalary", employee);
        //}
        //public IActionResult Edit(int? id)
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit([FromRoute] int? id, SalaryData salaryData)
        //{
        //    if (id != salaryData.EmployeeId)
        //        return BadRequest();
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            await _salaryRepo.UpdateAsync(salaryData);
        //            return RedirectToAction(nameof(HomeController.Index));
        //        }
        //        catch
        //        {
        //            return View(salaryData);
        //        }
        //    }
        //    return View(salaryData);
        //}


    }
}
