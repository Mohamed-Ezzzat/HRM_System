using HRM_System.Data.Base;
using HRM_System.Data;
using HRM_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HRM_System.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;
using HRM_System.Constants;
using Constants;

namespace HRM_System.Controllers
{
    public class RolesController : Controller
    {
        private readonly IEntityRepository<Admin> _adminRepo;
        private readonly IEntityRepository<HRUser> _HRRepo;
        private readonly UserManager<HRUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;

        public RolesController(IEntityRepository<Admin> adminRepo,
            IEntityRepository<HRUser> HRRepo,
            UserManager<HRUser> userManager,
            RoleManager<IdentityRole> roleManager, AppDbContext context)
        {
            _adminRepo = adminRepo;
            _HRRepo = HRRepo;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
        public IActionResult Create()
        {

            var allClaims = permissions.GenerateAllPermissions();
            var allPermissions = allClaims.Select(p => new CheckBoxViewModel { DisplayValue = p }).ToList();


            var viewModel = new RoleFormViewModel
            {
                RoleCalims = allPermissions
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _roleManager.RoleExistsAsync(model.Name.Trim()))
                {
                    ModelState.AddModelError("Name", "Role is exists!");
                    return View(model);
                }

                var role = new IdentityRole(model.Name.Trim());
                var identityResult = await _roleManager.CreateAsync(role);

                if (identityResult.Succeeded)
                {

                  //  var role = await _roleManager.FindByNameAsync(model.Name.Trim());


                    var selectedClaims = model.RoleCalims.Where(c => c.IsSelected).ToList();

                    foreach (var claim in selectedClaims)
                    {
                        await _roleManager.AddClaimAsync(role, new Claim("Permission", claim.DisplayValue));
                    }

                    return View("Index", await _roleManager.Roles.ToListAsync());
                }
                else
                {

                    foreach (var error in identityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);
        }
        public async Task<IActionResult> ManagePermissions(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
                return NotFound();

            var roleClaims = _roleManager.GetClaimsAsync(role).Result.Select(c => c.Value).ToList();
            var allClaims = permissions.GenerateAllPermissions();
            var allPermissions = allClaims.Select(p => new CheckBoxViewModel { DisplayValue = p }).ToList();

            foreach (var permission in allPermissions)
            {
                if (roleClaims.Any(c => c == permission.DisplayValue))
                    permission.IsSelected = true;
            }

            var viewModel = new PermissionsFormViewModel
            {
                RoleId = roleId,
                RoleName = role.Name,
                RoleCalims = allPermissions
            };

            return View(viewModel);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> ManagePermissions(PermissionsFormViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);

            if (role == null)
                return NotFound();

            var roleClaims = await _roleManager.GetClaimsAsync(role);

            foreach (var claim in roleClaims)
                await _roleManager.RemoveClaimAsync(role, claim);

            var selectedClaims = model.RoleCalims.Where(c => c.IsSelected).ToList();

            foreach (var claim in selectedClaims)
                await _roleManager.AddClaimAsync(role, new Claim("Permission", claim.DisplayValue));

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
                return NotFound();

            var roleClaims = _roleManager.GetClaimsAsync(role).Result.Select(c => c.Value).ToList();
            var allClaims = permissions.GenerateAllPermissions();
            var allPermissions = allClaims.Select(p => new CheckBoxViewModel { DisplayValue = p }).ToList();

            foreach (var permission in allPermissions)
            {
                if (roleClaims.Any(c => c == permission.DisplayValue))
                    permission.IsSelected = true;
            }

            var viewModel = new PermissionsFormViewModel
            {
                RoleId = roleId,
                RoleName = role.Name,
                RoleCalims = allPermissions
            };

            return View(viewModel);
        }
        public Task<IActionResult> Delete(string roleId)
        {
            return ManagePermissions(roleId);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] string roleId, PermissionsFormViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);

            if (role == null)
                return NotFound();

            try
            {
                var roleClaims = await _roleManager.GetClaimsAsync(role);

                foreach (var claim in roleClaims)
                    await _roleManager.RemoveClaimAsync(role, claim);

                var deleterole = await _roleManager.DeleteAsync(role);
                if (deleterole.Succeeded)
                {
                    return RedirectToAction(nameof(Index));

                }
                return View(model);

            }
            catch
            {
                return View(model);
            }
        }
    }
}
