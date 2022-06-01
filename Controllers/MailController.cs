using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.BL.Healper;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public IActionResult SendMail(string title , string message)
        {
            TempData["msg"] = SendMailHealper.sendMail(title, message); 
            return RedirectToAction("Index"); 
        }
    }
}
