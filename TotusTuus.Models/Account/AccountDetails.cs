using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotusTuus.Models.Parish;

namespace TotusTuus.Models.Account
{
    public class AccountDetails
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public bool EmailConfirmed { get;set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public IEnumerable<ParishListItem> AcceptedParishes { get; set; }
    }
}
