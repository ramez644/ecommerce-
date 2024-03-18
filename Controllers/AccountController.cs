using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Oseas.Models;
using Oseas.ViewModel;

namespace Oseas.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        
        public AccountController(UserManager<ApplicationUser>userManager,SignInManager<ApplicationUser>signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }



        //public IActionResult Index()
        //{
        //    return View();
        //} 

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel newUserVm)
        {
            if (ModelState.IsValid)
            {
                //mapping from view model to model
                ApplicationUser usermodel=new ApplicationUser();
                usermodel.UserName = newUserVm.UserName;
                usermodel.Address = newUserVm.Address;
                usermodel.PasswordHash = newUserVm.Password;

     //savedb

              IdentityResult result=  await userManager.CreateAsync(usermodel,newUserVm.Password);

                if (result.Succeeded)
                {

                   await signInManager.SignInAsync(usermodel, false);
                    await userManager.AddToRoleAsync(usermodel, "Customer");

                    //createcookie
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                   foreach (var errorItem in result.Errors)
                    {
                       ModelState.AddModelError("Password",errorItem.Description);
                    }
                }



                
           
            }


            return View(newUserVm);
        }

        public IActionResult LogOut() { 



        signInManager.SignOutAsync();
            return RedirectToAction("Register");
        
        
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> LogIn(LogInViewModel UserVm)
        {
            if (ModelState.IsValid)
            {
               ApplicationUser userModel=await userManager.FindByNameAsync(UserVm.UserName);
                if (userModel !=null) {

                   Boolean Found=await userManager.CheckPasswordAsync(userModel,UserVm.Password);

                    if (Found==true) {
                     //create cookie
                   await  signInManager.SignInAsync(userModel,false);
                        return RedirectToAction("Index", "Home");

                    
                    }
                    ModelState.AddModelError("", "user name or password");
                
                }
               

            }
            return View(UserVm);

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult AddAdmin()
        {
            return View();
        }


        [HttpPost]

        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddAdmin(RegisterViewModel newUserVm)
        {
            if (ModelState.IsValid)
            {
                //mapping from view model to model
                ApplicationUser usermodel = new ApplicationUser();
                usermodel.UserName = newUserVm.UserName;
                usermodel.Address = newUserVm.Address;
                usermodel.PasswordHash = newUserVm.Password;

                //savedb

                IdentityResult result = await userManager.CreateAsync(usermodel, newUserVm.Password);

                if (result.Succeeded)
                {

                    await signInManager.SignInAsync(usermodel, false);
                    await userManager.AddToRoleAsync(usermodel, "Admin");

                    //createcookie
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    foreach (var errorItem in result.Errors)
                    {
                        ModelState.AddModelError("Password", errorItem.Description);
                    }
                }





            }


            return View(newUserVm);
        }






    }
}
