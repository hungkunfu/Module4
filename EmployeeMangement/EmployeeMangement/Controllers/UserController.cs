using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMangement.Models.Employee;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeMangement.Controllers
{
    // quyen manager hoaj admin co the xem dc cai user va role
    [Authorize(Roles ="System Adminstaror,Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> usermanager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<ApplicationUser> usermanager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.usermanager = usermanager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var users = usermanager.Users;
            if (users != null && users.Any())
            {
                var model = new List<UserViewModel>();
                model = users.Select(u => new UserViewModel()
                {
                    UserId = u.Id,
                    Email = u.Email,
                    City = u.City,
                    Address = u.Address
                }).ToList();
                foreach (var user in model)
                {
                    user.RoleName = GetRolesName(user.UserId);
                }
                return View(model);
            }
            return View();

        }
        public string GetRolesName(string userId)
        {
            var user = Task.Run(async () => await usermanager.FindByIdAsync(userId)).Result;
            var roles = Task.Run(async () => await usermanager.GetRolesAsync(user)).Result;
            return roles != null ? string.Join(", ", roles) : string.Empty;

        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles  = roleManager.Roles;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateViewModel model)
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
                var result = await usermanager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.RoleId))
                    {
                        var role = await roleManager.FindByIdAsync(model.RoleId);
                        var addRoleResult = await usermanager.AddToRoleAsync(user, role.Name);
                        if (addRoleResult.Succeeded)
                        {
                            return RedirectToAction("Index", "User");
                        }
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);

                        }
                    }

                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);

                    }
                }

            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await usermanager.FindByIdAsync(id);

            if (user != null)
            {
                var model = new EditUserViewModel()
                {
                    Address = user.Address,
                    Email = user.Email,
                    City = user.City,
                    UserId = user.Id
                };
                var rolesName = await usermanager.GetRolesAsync(user);
                if(rolesName != null && rolesName.Any())
                {
                    var role = await roleManager.FindByNameAsync(rolesName.FirstOrDefault());
                    model.RoleId = role.Id;
                }
                ViewBag.Roles = roleManager.Roles;
                return View(model);
            }
            ViewBag.Roles = roleManager.Roles;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await usermanager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    user.Address = model.Address;
                    user.UserName = model.Email;
                    user.Email = model.Email;
                    user.City = model.City;
                    user.Id = model.UserId;
                    var result = await usermanager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        var rolesname = await usermanager.GetRolesAsync(user);
                        var delRole = await usermanager.RemoveFromRolesAsync(user, rolesname);
                        if (!string.IsNullOrEmpty(model.RoleId))
                        {
                            var role = await roleManager.FindByIdAsync(model.RoleId);
                            var addRoleResult = await usermanager.AddToRoleAsync(user, role.Name);
                            if (addRoleResult.Succeeded)
                            {
                                return RedirectToAction("Index", "User");

                            }
                            foreach (var error in addRoleResult.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }

                        }
                        return RedirectToAction("Index", "User");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return RedirectToAction("Index", "User");
                }
              
            }

            return View();
        }
        public async Task<IActionResult> Delete(string id)
        {
            var user = await usermanager.FindByIdAsync(id);
            if(user != null)
            {
                var result = await usermanager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "User");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
    }
 }
