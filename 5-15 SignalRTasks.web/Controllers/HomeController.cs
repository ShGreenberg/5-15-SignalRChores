using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _5_15_SignalRTasks.web.Models;
using Microsoft.AspNetCore.Authorization;
using _5_15_SignalRTasks.data;
using Microsoft.Extensions.Configuration;

namespace _5_15_SignalRTasks.web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private string _connString;
        public HomeController(IConfiguration configuration)
        {
            _connString = configuration.GetConnectionString("ConStr");
        }
        public IActionResult Index()
        {
            ChoresRepository rep = new ChoresRepository(_connString); 
            return View(rep.GetChores());
        }

        public IActionResult GetChores()
        {
            ChoresRepository rep = new ChoresRepository(_connString);
            return Json(rep.GetChores());
        }

        
    }
}
