using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taoxue.Training.Website.Extensions;

namespace Taoxue.Training.Website.Areas.School.Controllers
{
    public class HomeController : SchoolBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}