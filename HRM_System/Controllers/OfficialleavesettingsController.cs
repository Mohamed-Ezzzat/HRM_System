using HRM_System.Data.Base;
using HRM_System.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HRM_System.Controllers
{
    public class OfficialleavesettingsController : Controller
    {
        private readonly IEntityRepository<Officialleavesettings> _officialRepo;

        public OfficialleavesettingsController(IEntityRepository<Officialleavesettings> officialRepo)
        {
            _officialRepo = officialRepo;
        }

        public async Task<IActionResult> Index()
        {
            var groups = await _officialRepo.GetAllAsync();

            return View(groups);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Officialleavesettings setting)
        {
            if (ModelState.IsValid)
            {
                var spec = new GetOfficialByName(setting.Name.Trim());
                var officialleave = await _officialRepo.GetByNameWithSpecAsync(spec);

                if (officialleave != null)
                {
                    ModelState.AddModelError("Name", "This Official vacation is exist actually");
                    return View(setting);
                }
                await _officialRepo.AddAsync(setting);
                return RedirectToAction(nameof(Index));
            }
            return View(setting);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                var setting = await _officialRepo.GetByIdAsync((int)id);

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
        public async Task<IActionResult> Edit([FromRoute] int? id, Officialleavesettings setting)
        {
            if (id != setting.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    await _officialRepo.UpdateAsync(setting);
                    return RedirectToAction(nameof(HomeController.Index));
                }
                catch
                {
                    return View(setting);
                }
            }
            return View(setting);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            return await Details(id);
        }


        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int? id, Officialleavesettings setting)
        {
            if (setting.Id != id)
                return BadRequest();
            try
            {
                await _officialRepo.DeleteAsync(setting);
                return RedirectToAction(nameof(HomeController.Index));

            }
            catch
            {
                return View(setting);
            }
        }


    }
}
