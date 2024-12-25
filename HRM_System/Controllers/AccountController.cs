using System.Threading.Tasks;
using HRM_System.Models;
using HRM_System.Models.ViewModel;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRM_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<HRUser> _userManager;
        private readonly SignInManager<HRUser> _signInManager;

        public AccountController(UserManager<HRUser> userManager, SignInManager<HRUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if(user != null)
                {
                    var password =await _userManager.CheckPasswordAsync(user , model.Password);
                    if (password)
                    {
                        var result= await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                        if(result.Succeeded)
                            return RedirectToAction("Index" , "Home");

                    }
                }
            }
            return View(model);
        }

        public async new Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");

        }



    }
}
