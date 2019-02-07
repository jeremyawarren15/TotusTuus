using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TotusTuus.Web.Areas.SuperAdmin.Models.ParishRequest
{
    public class ParishRequestCreateViewModel
    {
        public int Parish { get; set; }
        public string User { get; set; }
        public bool IsHomeParish { get; set; }
    }
}