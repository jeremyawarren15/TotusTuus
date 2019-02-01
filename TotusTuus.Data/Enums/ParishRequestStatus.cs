using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotusTuus.Data.Enums
{
    public enum ParishRequestStatus
    {
        [Description("Pending")]
        Pending,
        [Description("Accepted")]
        Accepted,
        [Description("Denied")]
        Denied
    }
}
