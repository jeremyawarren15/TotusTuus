using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TotusTuus.Contracts;
using TotusTuus.Services;
using TotusTuus.Web.Areas.SuperAdmin.Models.Account;

namespace TotusTuus.Web.Areas.SuperAdmin.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: SuperAdmin/Account
        public ActionResult Index()
        {
            var users = _userService.GetAllUsers()
                .Select(u => new AccountListItem()
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    Email = u.Email
                });

            var model = new AccountIndexViewModel()
            {
                UsersList = users
            };

            return View(model);
        }
    }
}