using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using Constants;
using HRM_System.Constants;
using HRM_System.Data;
using HRM_System.Data.Base;
using HRM_System.Models;
using HRM_System.Models.ViewModel;
using HRM_System.seeds;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 

namespace HRM_System.Controllers
{
 //   [Authorize(Roles = Roles.HRAdmin)]
    public class AdminsController : Controller
    {
        private readonly IEntityRepository<Admin> _adminRepo;
        private readonly IEntityRepository<HRUser> _HRRepo;
        private readonly UserManager<HRUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEntityRepository<Usergroupsandpermissions> _groupRepo;
        private readonly AppDbContext _context;

        public AdminsController(IEntityRepository<Admin> adminRepo,
            IEntityRepository<HRUser> HRRepo,
            UserManager<HRUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IEntityRepository<Usergroupsandpermissions> groupRepo, AppDbContext context)
        {
            _adminRepo = adminRepo;
            _HRRepo = HRRepo;
            _userManager = userManager;
            _roleManager = roleManager;
            _groupRepo = groupRepo;
            _context = context;
        }
        [Authorize(permissions.Admin.View)]
        public async Task<IActionResult> All()
        {
            var employee = (await _adminRepo.GetAllAsync()).Include(e => e.HRUser);

            return View(employee);
        }

        public IActionResult CreateAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdmin(HRviewModel Admin)
        {
            if (ModelState.IsValid)
            {
                var admin = new HRUser()
                {
                    FullName = Admin.FullName,
                    Email = Admin.Email,
                    UserName = Admin.Email.Split('@')[0],
                    Admin = new Admin
                    {
                        Email = Admin.Email,
                        UserName = Admin.UserName,
                        Password = Admin.Password,
                        RoleName=Admin.RoleName,
                    }
                };

                var result = await _userManager.CreateAsync(admin, Admin.Password);

                if (result.Succeeded)
                {
                    var role = await _userManager.AddToRoleAsync(admin, Admin.RoleName);

                    return View("All" , (await _adminRepo.GetAllAsync()).Include(e => e.HRUser));
                }


                foreach (var item in result.Errors)
                    ModelState.AddModelError(string.Empty, item.Description);
                return View(Admin);
            }

            return View(Admin);
        }



        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                var admin = (await _adminRepo.GetByIdAsync((int)id));

                if (admin != null)
                {
                    await _context.Entry(admin)
                        .Reference(e => e.HRUser)
                        .LoadAsync();

                    return View(admin);
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

        public async Task< IActionResult> Edit(int? id)
        {
            return await Details(id);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int? id, Admin Updateadmin)
        {
            if (id != Updateadmin.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                var admin = (await _adminRepo.GetByIdAsync((int)id));
                var user = await _userManager.FindByEmailAsync(admin.Email);
                if(user != null)
                {
                    user.Email = Updateadmin.Email;
                    user.FullName = Updateadmin.HRUser.FullName;
                    user.UserName = Updateadmin.Email.Split('@')[0];
                }
                if(admin != null)
                {
                    admin.Email = Updateadmin.Email;
                    admin.UserName = Updateadmin.UserName;
                    admin.Password = Updateadmin.Password;
                    admin.RoleName = Updateadmin.RoleName;
                }
                await _userManager.UpdateAsync(user);
                var userRoles = await _userManager.GetRolesAsync(user);

                await _userManager.RemoveFromRolesAsync(user, userRoles);
                var result = await _userManager.AddToRoleAsync(user, Updateadmin.RoleName);
               
                await _adminRepo.UpdateAsync(admin);
                    return RedirectToAction(nameof(All));
                
            }
            return View(Updateadmin);
        }

        public Task<IActionResult> Delete(int? id)
        {
            return Details(id);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int? id, Admin admin)
        {
            if (admin.Id != id)
                return BadRequest();
            var Admin = (await _adminRepo.GetByIdAsync((int)id));
            var user = await _userManager.FindByEmailAsync(Admin.Email);

            try
            {
                await _userManager.DeleteAsync(user);
                await _adminRepo.DeleteAsync(Admin);
                return RedirectToAction(nameof(All));

            }
            catch
            {
                return View(admin);
            }
        }

       

    }
}
