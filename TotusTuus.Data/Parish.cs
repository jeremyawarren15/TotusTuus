using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotusTuus.Data
{
    public class Parish
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ParishName { get; set; }
        public string StreetAddress { get; set; }
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

        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }

        public virtual IEnumerable<ApplicationUser> Parishioners { get; set; }
        public virtual IEnumerable<TimeSlot> TimeSlots { get; set; }
    }
}
