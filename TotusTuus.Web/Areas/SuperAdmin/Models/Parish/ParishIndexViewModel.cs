using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotusTuus.Web.Areas.SuperAdmin.Models.Parish
{
    public class ParishIndexViewModel
    {
        public IEnumerable<ParishListItem> Parishes { get; set; }
    }
}