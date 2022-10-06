using Microsoft.AspNetCore.Mvc;
using prjAjaxHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjAjaxHomework.Controllers
{
    public class ApiController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register(Member member)
        {
            return Content(member.Name);
        }
        public IActionResult CheckName(string name)
        {
            string str = "";
            if (name != null)
            {
                DemoContext dbContext = new DemoContext();
                var member = dbContext.Members.Where(i => i.Name == name).Select(i => i).FirstOrDefault();
                if (member != null)
                {
                    str = "帳號已被註冊";
                }
                else
                {
                    str = "帳號可使用";
                }
            }
            
            
            return Content(str);
        }

        public IActionResult City()
        {
            DemoContext dbContext = new DemoContext();
            var cities = dbContext.Addresses.Select(i => i.City).Distinct();
            return Json(cities);
        }
        public IActionResult Site(string city)
        {
            DemoContext dbContext = new DemoContext();
            var sites = dbContext.Addresses.Where(i => i.City == city).Select(i => i.SiteId).Distinct();
            return Json(sites);
        }
        public IActionResult Road(string site)
        {
            DemoContext dbContext = new DemoContext();
            var roads = dbContext.Addresses.Where(i => i.SiteId == site).Select(i => i.Road).Distinct();
            return Json(roads);
        }


        public IActionResult AutoComplete(string keyword)
        {
            NorthwindContext dbContext = new NorthwindContext();
            var products = dbContext.Products.Where(i => i.ProductName.Contains(keyword)).Select(i => i.ProductName);
            return Json(products);
        }
    }
}
