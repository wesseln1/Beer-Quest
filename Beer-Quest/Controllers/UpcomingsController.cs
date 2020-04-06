using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Beer_Quest.Models;


namespace Beer_Quest.Controllers
{
    public class UpcomingsController : Controller
    {
        private readonly ILogger<UpcomingsController> _logger;

        public UpcomingsController(ILogger<UpcomingsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
