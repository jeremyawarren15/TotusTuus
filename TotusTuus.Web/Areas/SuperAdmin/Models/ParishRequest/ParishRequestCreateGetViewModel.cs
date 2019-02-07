using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TotusTuus.Web.Areas.SuperAdmin.Models.ParishRequest
{
    public class ParishRequestCreateGetViewModel
    {
        [Required]
        public IEnumerable<SelectListItem> Parishes { get; set; }

        [Required]
        public IEnumerable<SelectListItem> Users { get; set; }

        public bool IsHomeParish { get; set; }
    }
}