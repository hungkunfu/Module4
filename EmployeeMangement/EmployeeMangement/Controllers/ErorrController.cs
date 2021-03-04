using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMangement.Controllers
{
    public class ErorrController : Controller
    {
        [Route("Erorr/{StatusCode}")]
        public IActionResult PageNotFound(int StatusCode)
        {
            ViewBag.ErroMessage = $"Erorr {StatusCode}: Sory the resource Not Found  ";
            return View();
        }
        public ViewResult Erorr()
        {
            return View("Exception");
        }
    }
}
