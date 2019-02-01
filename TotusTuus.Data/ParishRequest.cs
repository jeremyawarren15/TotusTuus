using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotusTuus.Data.Enums;

namespace TotusTuus.Data
{
    public class ParishRequest
    {
        [Key]
        public int Id { get; set; }

        [DefaultValue(ParishRequestStatus.Pending)]
        public ParishRequestStatus Status { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? DecisionDate { get; set; }

        [Required]
        public virtual ApplicationUser RequestingUser { get; set; }
        [Required]
        public virtual Parish Parish { get; set; }
    }
}
