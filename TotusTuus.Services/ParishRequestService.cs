using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using TotusTuus.Contracts;
using TotusTuus.Data;
using TotusTuus.Data.Enums;

namespace TotusTuus.Services
{
    public class ParishRequestService : IParishRequestService
    {
        private readonly ApplicationDbContext _context;

        public ParishRequestService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AcceptParishRequest(int id)
        {
            return SetParishStatus(id, ParishRequestStatus.Accepted);
        }

        public bool CreateParishRequest(ParishRequest model)
        {
            model.CreatedDate = DateTimeOffset.UtcNow;

            _context.ParishRequests.Add(model);

            return _context.SaveChanges() == 1;
        }

        public bool DenyParishRequest(int id)
        {
            return SetParishStatus(id, ParishRequestStatus.Denied);
        }

        public IEnumerable<ParishRequest> GetAcceptedParishRequests(string userId)
        {
            return _context.ParishRequests
                .Where(p => p.RequestingUser.Id == userId
                            && p.Status == ParishRequestStatus.Accepted);
        }

        public IEnumerable<ParishRequest> GetAllParishRequests()
        {
            return _context.ParishRequests;
        }

        public ParishRequest GetParishRequest(int id)
        {
            return _context.ParishRequests
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<ParishRequest> GetParishRequestsByParish(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ParishRequest> GetParishRequestsByUser(string id)
        {
            throw new NotImplementedException();
        }

        private bool SetParishStatus(int id, ParishRequestStatus status)
        {
            var parishRequest = GetParishRequest(id);

            parishRequest.Status = status;
            parishRequest.DecisionDate = DateTimeOffset.UtcNow;

            return _context.SaveChanges() == 1;
        }
    }
}
