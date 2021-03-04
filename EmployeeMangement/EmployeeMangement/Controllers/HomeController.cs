using EmployeeMangement.Models.About;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangement.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index(int id = 10)
        {
            //string str = "";
            //Random rnd = new Random();
            //for(int i = 0; i<id; i++)
            //{
            //    str += $"{rnd.Next(10, 90).ToString()} <br>";
            //}
            //return str;
            //ViewBag.Id = id;
            TempData["Id"] = id;
            return View("~/Views/Home/trangchu.cshtml");
        }

        public string Login(string un, string pw)
        {
            return $"Username: {un}, Password: {pw}";
        }

        public ViewResult About()
        {
            var khoa = new AboutModel()
            {
                Firstname = "Khoa",
                Lastname = "Nguyen",
                Email = "khoa.nguyen@codegym.vn",
                Address = "28 Nguyen Tri Phuong"
            };
            var tan = new AboutModel()
            {
                Firstname = "Tan",
                Lastname = "Ton",
                Email = "tan.ton@codegym.vn",
                Address = "28 Nguyen Tri Phuong"
            };
            var huy = new AboutModel()
            {
                Firstname = "Huy",
                Lastname = "Phan",
                Email = "huy.phan@codegym.vn",
                Address = "28 Nguyen Tri Phuong"
            };
            List<AboutModel> models = new List<AboutModel>();
            models.Add(khoa);
            models.Add(tan);
            models.Add(huy);

            ViewBag.Title = "About";
            return View(models);
        }
    }
}
