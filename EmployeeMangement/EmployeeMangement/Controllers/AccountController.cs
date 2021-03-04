
using EmployeeMangement.Models.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangement.Controllers
{
    // cap go dung het khi dang nhap vao moi dc su dung cac chuc nang
    // dung de url khong bij lap gay ra loi
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser>  userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string  returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        //[AcceptVerbs("GET", "Post)]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            //check user is exist
            //if exist => dashboard
            //else show error
            if(ModelState.IsValid)
            {
                // await dong tac cho lam gi do xong
                var result = await signInManager.PasswordSignInAsync(
                    userName: model.Email,
                    password: model.Password,
                    isPersistent: model.RemenberMe,
                    lockoutOnFailure: false
                    );
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl); 
                    }
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attemp");
                    if (!string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                }
               
            }
            return View(model);
        }
        [HttpGet]
       [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    Email = model.Email,
                    UserName = model.Email,
                    City = model.City,
                    Address = model.Address
                    
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user: user, isPersistent: false);
                    return RedirectToAction("Index","Employee");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("",error.Description);

                    }
                }
              
            }
            return View(model); 
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Employee");
        }
        
        
    }
}
