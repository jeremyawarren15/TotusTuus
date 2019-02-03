using System.Collections.Generic;
using TotusTuus.Models.Parish;

namespace TotusTuus.Web.Areas.SuperAdmin.Models.Parish
{
    public class ParishIndexViewModel
    {
        public IEnumerable<ParishListItem> Parishes { get; set; }
    }
}