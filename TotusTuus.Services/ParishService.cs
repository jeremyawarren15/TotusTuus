using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotusTuus.Contracts;
using TotusTuus.Data;

namespace TotusTuus.Services
{
    public class ParishService : IParishService
    {
        private ApplicationDbContext _context;

        public ParishService(ApplicationDbContext context)
        {
            _context = context;
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

            _context.Entry(oldParish)
                .CurrentValues
                .SetValues(parish);

            return _context.SaveChanges() == 1;
        }
    }
}
