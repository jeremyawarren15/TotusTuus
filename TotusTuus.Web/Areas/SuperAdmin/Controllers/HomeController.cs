using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TotusTuus.Contracts;
using TotusTuus.Web.Areas.SuperAdmin.Models.Home;

namespace TotusTuus.Web.Areas.SuperAdmin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class HomeController : Controller
    {
        private readonly IParishService _parishService;
        private readonly IUserService _userService;

        public HomeController(IParishService parishService, IUserService userService)
        {
            _parishService = parishService;
            _userService = userService;
        }

        // GET: SuperAdmin/Home
        public ActionResult Index()
        {
            var model = new HomeIndexViewModel()
            {
                TotalParishes = _parishService.GetNumberOfParishes(),
                TotalUsers = _userService.GetNumberOfUsers()
            };

            return View(model);
        }
    }
}