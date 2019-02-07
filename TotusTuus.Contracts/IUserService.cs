using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotusTuus.Data;

namespace TotusTuus.Contracts
{
    public interface IUserService
    {
        bool AddUser(ApplicationUser user, string password);
        IEnumerable<ApplicationUser> GetAllUsers();
        IEnumerable<ApplicationUser> GetUsersByParishId(int id);
        int GetNumberOfUsers();
        ApplicationUser GetUserById(string id);
        bool UpdateUser(ApplicationUser user);
    }
}
