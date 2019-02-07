using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotusTuus.Data;

namespace TotusTuus.Contracts
{
    public interface IParishRequestService
    {
        IEnumerable<ParishRequest> GetAllParishRequests();
        IEnumerable<ParishRequest> GetParishRequestsByUser(string userId);
        IEnumerable<ParishRequest> GetParishRequestsByParish(int id);
        IEnumerable<ParishRequest> GetAcceptedParishRequests(string userId);

        ParishRequest GetParishRequest(int id);

        bool CreateParishRequest(ParishRequest model);

        bool DenyParishRequest(int id);
        bool AcceptParishRequest(int id);
    }
}
