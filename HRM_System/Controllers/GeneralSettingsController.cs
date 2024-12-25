using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRM_System.Data.Base;
using HRM_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRM_System.Controllers
{
    public class GeneralSettingsController : Controller
    {
        private readonly IEntityRepository<GeneralSettings> _GeneralRepo;

        public GeneralSettingsController(IEntityRepository<GeneralSettings> GeneralRepo)
        {
            _GeneralRepo = GeneralRepo;
        }

        public async Task<IActionResult> All()
        {
            var setting = await _GeneralRepo.GetAllAsync();

            return View(setting);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GeneralSettings setting)
        {
         
                if (ModelState.IsValid)
                {
                    var Generalsetting = new GeneralSettings()
                    {
                        Discount = setting.Discount,
                        Additional = setting.Additional,
                        Thedayofthefirstofficialvacation = setting.Thedayofthefirstofficialvacation,
                        Thesecondofficialvacationday = setting.Thesecondofficialvacationday,
                    };
                    await _GeneralRepo.AddAsync(setting);
                    return RedirectToAction("All");
                }
                return View(setting);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                var setting = await _GeneralRepo.GetByIdAsync((int)id);

                return View(setting);
            }
            else
            {
                return NotFound();
            }
        }


        public async Task<IActionResult> Edit(int? id)
        {
            return await Details(id);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int? id, GeneralSettings setting)
        {
            if (id != setting.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    await _GeneralRepo.UpdateAsync(setting);
                    return RedirectToAction("All" , await _GeneralRepo.GetAllAsync());
                }
                catch
                {
                    return View(setting);
                }
            }
            return View(setting);
        }

      


    }
}
