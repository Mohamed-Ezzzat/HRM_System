using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Constants;
using HRM_System.Constants;
using HRM_System.Contants;
using HRM_System.Data.Base;
using HRM_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRM_System.seeds
{
    public static class AdminDbSeed
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            
            if (!await roleManager.Roles.AnyAsync())
            {
                await roleManager.CreateAsync(new IdentityRole { Id = Guid.NewGuid().ToString(), Name = Roles.HRAdmin, NormalizedName = Roles.HRAdmin.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() });
                await roleManager.CreateAsync(new IdentityRole { Id = Guid.NewGuid().ToString(), Name = Roles.Admin, NormalizedName = Roles.Admin.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() });
            }
        }

        public static async Task SeedHR_Async(UserManager<HRUser> userManager)
        {
         
            if (!userManager.Users.Any())
            {
                var HR = new HRUser
                {
                    FullName = "Mohamed Ezzat",
                    UserName = "mohamedezzat22",
                    Email = "mohamedezzat22@gmail.com",
                    Admin = new Admin
                    {
                        UserName = "mohamedezzat22",
                        Email = "mohamedezzat22@gmail.com",
                        
                    },
                };
                var result = await userManager.CreateAsync(HR, "123456");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(HR, Roles.HRAdmin.ToString());
                }
            }
        }

        public static async Task SeedClaimsForHRAdmin(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync(Roles.HRAdmin.ToString());

            await roleManager.AddPermissionClaims(adminRole, "Employee");
            await roleManager.AddPermissionClaims(adminRole, "GeneralSettings");
            await roleManager.AddPermissionClaims(adminRole, "Attendance");
            await roleManager.AddPermissionClaims(adminRole, "Payroll");
            await roleManager.AddPermissionClaims(adminRole, "Admin");
            await roleManager.AddPermissionClaims(adminRole, "UserGroup");
            await roleManager.AddPermissionClaims(adminRole, "Officialleavesettings");


        }


        public static async Task AddPermissionClaims (this RoleManager<IdentityRole> roleManager, IdentityRole role , string module)
        {
            var allclaims = await roleManager.GetClaimsAsync(role);
            var allpermission = permissions.GeneratePermissionsList(module);

            foreach (var permission in allpermission)
            {
                if (!allclaims.Any(c => c.Type == "Permission" && c.Value == permission))
                    await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
            }
        }

    }
}

