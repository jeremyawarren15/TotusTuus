using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotusTuus.Web.Areas.SuperAdmin.Models.Account
{
    public class AccountIndexViewModel
    {
        public IEnumerable<AccountListItem> UsersList { get; set; }
    }
}