using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TotusTuus.Models.Parish
{
    public class ParishEdit
    {
        public int Id { get; set; }

        [Required]
        public string ParishName { get; set; }

        [Required]
        public string StreetAddress { get; set; }
        
        [Required]
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
