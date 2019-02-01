using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotusTuus.Data
{
    public class SubstitutionHistory
    {
        public int Id { get; set; }
        
        [Required]
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? AssignedDate { get; set; }

        [Required]
        public virtual TimeSlot TimeSlot { get; set; }

        [Required]
        public virtual ApplicationUser RequestingUser { get; set; }
        public virtual ApplicationUser ResponsibleUser { get; set; }
    }
}
