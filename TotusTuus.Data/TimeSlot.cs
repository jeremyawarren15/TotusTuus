using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotusTuus.Data
{
    public class TimeSlot
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DayOfWeek DayOfWeek { get; set; }

        [Required]
        [Range(0,23)]
        public int Hour { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? RemovedDate { get; set; }

        [Required]
        public virtual Parish Parish { get; set; }
    }
}
