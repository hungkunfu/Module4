using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMangement.Models.Employee;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMangement.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var roles = roleManager.Roles;
            var model = new List<Role>();
            model = roles.Select(r => new Role()
            {
                RoleId = r.Id,
                RoleName = r.Name
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateRole model)
        {
            if (ModelState.IsValid)
            {
                var result = await roleManager.CreateAsync(new IdentityRole()
                {
                    Name = model.RoleName
                });
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Role");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description); 
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if(role != null)
            {

                var model = new EditRole()
                {
                    RoleName = role.Name,
                    RoleId = role.Id
                };
               return View(model);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditRole model)
        {
            if (ModelState.IsValid)
            {
                var role = await roleManager.FindByIdAsync(model.RoleId);
                if(role != null)
                {
                    role.Name = model.RoleName;
                    var result = await roleManager.UpdateAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Role");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description); 
                    }
                }
            }
            return View();
        }

        //public async Task<IActionResult> Delete(string id)
        //{
        //    var role = await roleManager.FindByIdAsync(id);

        //    return View(role);
        //}

        public async Task<IActionResult> Delete(string id)
        {
            var Delrole = await roleManager.FindByIdAsync(id);
            if (Delrole != null)
            {
                var result = await roleManager.DeleteAsync(Delrole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Role");
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
