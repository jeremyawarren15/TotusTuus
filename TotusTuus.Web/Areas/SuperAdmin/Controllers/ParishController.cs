using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TotusTuus.Contracts;
using TotusTuus.Data;
using TotusTuus.Web.Areas.SuperAdmin.Models.Parish;

namespace TotusTuus.Web.Areas.SuperAdmin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class ParishController : Controller
    {
        private IParishService _parishService;

        public ParishController(IParishService parishService)
        {
            _parishService = parishService;
        }

        // GET: SuperAdmin/Parish
        public ActionResult Index()
        {
            var parishes = _parishService
                .GetAllParishes()
                .Select(
                    p => new ParishListItem()
                    {
                        ParishName = p.ParishName,
                        City = p.City,
                        State = p.State
                    });
            
            var model = new ParishIndexViewModel()
            {
                Parishes = parishes
            };

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ParishCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var parish = new Parish()
            {
                ParishName = model.ParishName,
                City = model.ParishName,
                State = model.State,
                OfficePhoneNumber = model.OfficePhoneNumber,
                Archdiocese = model.Archdiocese,
                CreatedDate = DateTimeOffset.UtcNow,
                PostalCode = model.PostalCode,
                Pastor = model.Pastor,
                StreetAddress = model.StreetAddress
            };

            if (_parishService.AddParish(parish))
                return RedirectToAction("Index", new { area = "SuperAdmin"});

            return View();
        }
    }
}