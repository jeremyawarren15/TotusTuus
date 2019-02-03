using System.Collections.Generic;
using TotusTuus.Models.Account;

namespace TotusTuus.Web.Areas.SuperAdmin.Models.Account
{
    public class AccountIndexViewModel
    {
        public IEnumerable<AccountListItem> UsersList { get; set; }
    }
}