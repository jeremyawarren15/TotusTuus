using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TotusTuus.Contracts;
using TotusTuus.Data;
using TotusTuus.Models.Account;
using TotusTuus.Models.Parish;
using TotusTuus.Web.Areas.SuperAdmin.Models.Parish;

namespace TotusTuus.Web.Areas.SuperAdmin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class ParishController : Controller
    {
        private readonly IParishService _parishService;
        private readonly IUserService _userService;

        public ParishController(IParishService parishService, IUserService userService)
        {
            _parishService = parishService;
            _userService = userService;
        }

        // GET: SuperAdmin/Parish
        public ActionResult Index()
        {
            var parishes = _parishService
                .GetAllParishes()
                .Select(
                    p => new ParishListItem()
                    {
                        Id = p.Id,
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
                return RedirectToAction("Index", new { area = "SuperAdmin" });

            return View();
        }

        public ActionResult Details(int id)
        {
            var parish = _parishService.GetParish(id);

            var users = _userService
                .GetUsersByParishId(id)
                .Select(u => new AccountListItem()
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    Email = u.Email
                });

            //TODO: need to find a solution to the ModifiedDate problem
            var model = new ParishDetails()
            {
                Id = id,
                ParishName = parish.ParishName,
                Address = $"{parish.StreetAddress} {parish.City}, {parish.State} {parish.PostalCode}",
                Archdiocese = parish.Archdiocese,
                CreatedDate = parish.CreatedDate.LocalDateTime,
                OfficePhoneNumber = parish.OfficePhoneNumber,
                Pastor = parish.Pastor,
                Parishioners = users,
                TimeSlots = null //TODO: This will have to be filled later
            };

            return View(model);
        }
    }
}