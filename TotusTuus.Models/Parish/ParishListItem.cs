using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotusTuus.Models.Parish
{
    public class ParishListItem
    {
        public int Id { get; set; }
        public string ParishName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}