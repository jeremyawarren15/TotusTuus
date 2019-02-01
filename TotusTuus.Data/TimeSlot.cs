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
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        [Range(0,23)]
        public int Hour { get; set; }

        [Required]
        public DateTimeOffset CreatedDate { get; set; }

        [Required]
        public virtual Parish Parish { get; set; }
    }
}
