using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotusTuus.Data
{
    public class TimeSlotHistory
    {
        [Key]
        public int Id { get; set; }
        
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        [Required]
        public virtual ApplicationUser ResponsibleUser { get; set; }

        [Required]
        public virtual TimeSlot TimeSlot { get; set; }
    }
}
