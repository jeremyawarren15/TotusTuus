using System.Linq;
using System.Web.Mvc;
using TotusTuus.Contracts;
using TotusTuus.Data;
using TotusTuus.Models.Account;
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AccountCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName,
            };

            var succeeded = _userService.AddUser(user, model.Password);

            if (succeeded)
                return RedirectToAction("Index", new {area = "SuperAdmin"});

            return View();
        }

        public ActionResult Details(string id)
        {
            var user = _userService.GetUserById(id);

            var details = new AccountDetails()
            {
                Id = user.Id,
                FullName = user.FullName,
                AcceptedParishes = null, //TODO: #29 This needs to get updated to show list of accepted parishes
                AccessFailedCount = user.AccessFailedCount,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                LockoutEnabled = user.LockoutEnabled,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName
            };

            var model = new AccountDetailsViewModel()
            {
                Account = details
            };

            return View(model);
        }
    }
}