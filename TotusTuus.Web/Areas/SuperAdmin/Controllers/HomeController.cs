using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TotusTuus.Contracts;
using TotusTuus.Web.Areas.SuperAdmin.Models.Home;

namespace TotusTuus.Web.Areas.SuperAdmin.Controllers
{
    public class HomeController : Controller
    {
        private IParishService _parishService;

        public HomeController(IParishService parishService)
        {
            _parishService = parishService;
        }

        // GET: SuperAdmin/Home
        public ActionResult Index()
        {
            var model = new HomeIndexViewModel()
            {
                TotalParishes = _parishService.GetAllParishes().Count()
            };

            return View(model);
        }
    }
}