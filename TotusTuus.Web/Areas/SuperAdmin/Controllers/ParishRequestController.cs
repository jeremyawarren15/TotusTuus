using System.Web.Mvc;
using TotusTuus.Contracts;
using TotusTuus.Data;
using TotusTuus.Web.Areas.SuperAdmin.Models.ParishRequest;

namespace TotusTuus.Web.Areas.SuperAdmin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class ParishRequestController : Controller
    {
        private readonly IParishService _parishService;
        private readonly IParishRequestService _parishRequestService;
        private readonly IUserService _userService;

        public ParishRequestController(IParishService parishService, IParishRequestService parishRequestService, IUserService userService)
        {
            _parishService = parishService;
            _parishRequestService = parishRequestService;
            _userService = userService;
        }

        public ActionResult Create()
        {
            var parishes = _parishService.GetAllParishes();
            var users = _userService.GetAllUsers();

            var model = new ParishRequestCreateGetViewModel()
            {
                Parishes = new SelectList(parishes, "Id", "ParishName"),
                Users = new SelectList(users, "Id", "FullName"),
                IsHomeParish = false
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ParishRequestCreateViewModel model)
        {
            var user = _userService.GetUserById(model.User);
            var parish = _parishService.GetParish(model.Parish);

            var create = new ParishRequest()
            {
                Parish = parish,
                IsHomeParish = model.IsHomeParish,
                RequestingUser = user
            };

            _parishRequestService.CreateParishRequest(create);

            return RedirectToAction("Index", "Parish", new {area = "SuperAdmin"});
        }
    }
}