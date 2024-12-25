using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using HRM_System.Data.Base;
using HRM_System.Models;
using HRM_System.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRM_System.Controllers
{
    public class UsergroupsandpermissionsController : Controller
    {
        private readonly UserManager<HRUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEntityRepository<Usergroupsandpermissions> _groupsRepo;

        public UsergroupsandpermissionsController(UserManager<HRUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IEntityRepository<Usergroupsandpermissions> GroupsRepo)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _groupsRepo = GroupsRepo;
        }

        public async Task<IActionResult> Index()
        {
            var groups = await _groupsRepo.GetAllAsync();

            return View(groups);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usergroupsandpermissions usergroupsandpermissions)
        {
            if (ModelState.IsValid)
            {
                var spec = new GetGroupByName(usergroupsandpermissions.Name.Trim());
                var groups = await _groupsRepo.GetByNameWithSpecAsync(spec);

                if (groups != null)
                {
                    ModelState.AddModelError("Name", "This Name is exist");
                    return View(usergroupsandpermissions);
                }
                await _groupsRepo.AddAsync(usergroupsandpermissions);
                return RedirectToAction(nameof(HomeController.Index));
            }

            return View(usergroupsandpermissions);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                var group = await _groupsRepo.GetByIdAsync((int)id);

                return View(group);
            }
            else
            {
                return NotFound();
            }
        }

        public async Task< IActionResult> Edit(int? id)
        {
            return await Details(id);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int? id, Usergroupsandpermissions usergroupsandpermissions)
        {
            if (id != usergroupsandpermissions.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    await _groupsRepo.UpdateAsync(usergroupsandpermissions);
                    return RedirectToAction(nameof(HomeController.Index));
                }
                catch
                {
                    return View(usergroupsandpermissions);
                }
            }
            return View(usergroupsandpermissions);
        }

        public Task<IActionResult> Delete(int? id)
        {
            return Details(id);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int? id, Usergroupsandpermissions usergroupsandpermissions)
        {
            if (usergroupsandpermissions.Id != id)
                return BadRequest();
            try
            {
                await _groupsRepo.DeleteAsync(usergroupsandpermissions);
                return RedirectToAction(nameof(HomeController.Index));

            }
            catch
            {
                return View(usergroupsandpermissions);
            }
        }

       
    }
}
