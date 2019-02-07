using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotusTuus.Contracts;
using TotusTuus.Data;
using TotusTuus.Data.Enums;

namespace TotusTuus.Services
{
    public class ParishService : IParishService
    {
        private readonly ApplicationDbContext _context;
        private readonly IParishRequestService _parishRequestService;

        public ParishService(ApplicationDbContext context, IParishRequestService parishRequestService)
        {
            _context = context;
            _parishRequestService = parishRequestService;
        }

        public bool AddParish(Parish parish)
        {
            _context.Parishes.Add(parish);

            return _context.SaveChanges() == 1;
        }

        public IEnumerable<Parish> GetAllParishes()
        {
            return _context.Parishes;
        }

        public IEnumerable<Parish> GetParishesByUserId(string userId)
        {
            return _parishRequestService.GetAcceptedParishRequests(userId)
                .Select(p => p.Parish);
        }

        public int GetNumberOfParishes()
        {
            return _context.Parishes.Count();
        }

        public Parish GetParish(int id)
        {
            return _context.Parishes
                .FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateParish(Parish parish)
        {
            var oldParish = GetParish(parish.Id);

            parish.ModifiedDate = DateTimeOffset.UtcNow;

            _context.Entry(oldParish)
                .CurrentValues
                .SetValues(parish);

            return _context.SaveChanges() == 1;
        }

        public Parish GetHomeParish(string userId)
        {
            return _parishRequestService.GetAcceptedParishRequests(userId)
                .First(p => p.IsHomeParish)
                .Parish;
        }
    }
}
