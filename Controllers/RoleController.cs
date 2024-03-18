﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Oseas.ViewModel;

namespace Oseas.Controllers
{
    [Authorize (Roles ="Admin")]
    public class RoleController : Controller
    {
        
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult New() {
        
        return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> New(AddRoleViewModel addRoleViewModel)
        {

            if(ModelState.IsValid==true) {
                IdentityRole roleModel = new IdentityRole();
                roleModel.Name = addRoleViewModel.RoleName;

             IdentityResult result=  await roleManager.CreateAsync(roleModel);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            
            
            }

            return View(addRoleViewModel);
        }
    }
}
