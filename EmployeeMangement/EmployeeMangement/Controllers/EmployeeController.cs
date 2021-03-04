using EmployeeMangement.Models.Employee;
using EmployeeMangement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangement.Controllers
{
    // dung cho cap do trong class khi dang nhap moi duoc su dung chuc nang
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EmployeeController(IEmployeeService employeeService,
                                    IWebHostEnvironment webHostEnvironment)
        {
            this.employeeService = employeeService;
            this.webHostEnvironment = webHostEnvironment;
        }
        // cho phep duoc sua dung chuc nang khi dung allowanymous
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(employeeService.Gets());
        }

        [HttpGet]
        // dung cho chuc nang tao moi khi dang nhap
        //[Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateEmployee model)
        {
           
            if (ModelState.IsValid)
            {
                //1. get root
                //2. create folder path
                //3. filename path
                //4. copy image to folder step 2
                var filename = "noavatar.jpg";
                if(model.Avatar != null)
                {
                    var folderPath = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    filename = $"{Guid.NewGuid()}_{model.Avatar.FileName}";
                    var filePath = Path.Combine(folderPath, filename);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        model.Avatar.CopyTo(fs);
                    }
                }
               
                var employee = new ViewEmployee()
                {
                    Age = model.Age,
                    AvatarPath = $"~/images/{filename}",
                    Code = model.Code,
                    Email = model.Email,
                    Firstname = model.Firstname,
                    Lastname = model.Lastname
                };
                if (employeeService.Create(employee))
                    return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Profile(int id)
        {
            //try
            //{
            //    int.Parse(id.Value.ToString());
                var employee = employeeService.Get(id);
                if (employee == null)
                {
                    return View("~/Views/Erorr/EmployeeNotFound.cshtml", id);
                }
                return View(employee);
            //}
            //catch (Exception e)
            //{

            //    throw e;
            //}
          
        }

        [HttpGet]
        [Route("/Employee/Edit/{employeeId}")]
        public IActionResult Edit(int employeeId)
        {
            var employee = employeeService.Get(employeeId);
            if (employee == null)
            {
                return View("~/Views/Erorr/EmployeeNotFound.cshtml", employeeId);
            }
            var editEmp = new EditEmployee()
            {
                AvatarPath = employee.AvatarPath,
                Age = employee.Age,
                Code = employee.Code,
                Email = employee.Email,
                Firstname = employee.Firstname,
                Lastname = employee.Lastname,
                Id = employee.Id
            };
            return View(editEmp);
        }

        [HttpPost]
        public IActionResult Edit(EditEmployee model)
        {
            if (ModelState.IsValid)
            {
                var existingAvatar = model.AvatarPath;
                if(model.Avatar != null)
                {
                    //remove exist file

                    existingAvatar = existingAvatar.Split("/").Last();
                    if(string.Compare(existingAvatar, "noavatar.jpg") != 0)
                    {
                        System.IO.File.Delete(Path.Combine(webHostEnvironment.WebRootPath, "images", existingAvatar));
                    }
                  

                    //upload new file
                    var folderPath = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    var filename = $"{Guid.NewGuid()}_{model.Avatar.FileName}";
                    var filePath = Path.Combine(folderPath, filename);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        model.Avatar.CopyTo(fs);
                    }
                    existingAvatar = $"~/images/{filename}";
                }
                var employee = new ViewEmployee()
                {
                    Age = model.Age,
                    AvatarPath = existingAvatar,
                    Code = model.Code,
                    Email = model.Email,
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    Id = model.Id,
                    Phone=model.Phone
                    
                };
                if (employeeService.Edit(employee))
                    return RedirectToAction("Profile", "Employee", new { id = model.Id});
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
          
            var delEmployee = employeeService.Get(id);
            if (delEmployee != null)
            {
                var filename = delEmployee.AvatarPath.Split("/").Last();
                if (string.Compare(filename, "noavatar.jpg") != 0)
                {
                    System.IO.File.Delete(Path.Combine(webHostEnvironment.WebRootPath, "images", filename));
                }
                employeeService.Remove(delEmployee);
                return RedirectToAction("Index");
            }
            var employee = employeeService.Get(id);
            ViewBag.Error = "Something went wrong, please contact administator";
            return View(employee);
           
        }
        public IActionResult ProfileViews(int id)
        {
            var employee = employeeService.Get(id);
         
            return View(employee);

        }
    }
}
