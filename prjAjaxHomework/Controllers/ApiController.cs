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
    }
}
