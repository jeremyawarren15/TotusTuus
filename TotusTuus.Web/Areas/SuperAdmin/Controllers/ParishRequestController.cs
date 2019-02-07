using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TotusTuus.Web.Areas.SuperAdmin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class ParishRequestController : Controller
    {
        // GET: SuperAdmin/ParishRequest
        public ActionResult Index()
        {
            return View();
        }
    }
}