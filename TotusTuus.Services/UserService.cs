using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TotusTuus.Contracts;
using TotusTuus.Data;

namespace TotusTuus.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
            var store = new UserStore<ApplicationUser>(context);
            _userManager = new UserManager<ApplicationUser>(store);
        }

        public bool AddUser(ApplicationUser user, string password)
        {
            // FullName should always be overridden by this
            user.FullName = $"{user.FirstName} {user.LastName}";

            var newUserResult = _userManager.CreateAsync(user, password);

            return newUserResult.Result.Succeeded;
        }

        public ApplicationUser GetUserById(string id)
        {
            var user = _userManager.FindById(id);

            return user;
        }

        public bool UpdateUser(ApplicationUser user)
        {
            var result = _userManager.UpdateAsync(user);

            return result.Result.Succeeded;
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return _context.Users;
        }
    }
}
