using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TotusTuus.Web.Areas.SuperAdmin.Models.Parish
{
    public class ParishCreateViewModel
    {
        [Required]
        public string ParishName { get; set; }
        public string StreetAddress { get; set; }

        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }
        
        public string Pastor { get; set; }

        [Required]
        public string Archdiocese { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        public string OfficePhoneNumber { get; set; }
    }
}