using System;
using System.Collections.Generic;
using TotusTuus.Data;
using TotusTuus.Models.Account;

namespace TotusTuus.Models.Parish
{
    public class ParishDetails
    {
        public int Id { get; set; }
        public string ParishName { get; set; }
        public string Address { get; set; }
        public string Pastor { get; set; }
        public string Archdiocese { get; set; }
        public string OfficePhoneNumber { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public IEnumerable<AccountListItem> Parishioners { get; set; }
        public IEnumerable<TimeSlot> TimeSlots { get; set; }
    }
}
