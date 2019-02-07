using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotusTuus.Data;

namespace TotusTuus.Contracts
{
    public interface IParishService
    {
        IEnumerable<Parish> GetAllParishes();
        IEnumerable<Parish> GetParishesByUserId(string userId);
        Parish GetParish(int id);
        Parish GetHomeParish(string userId);
        int GetNumberOfParishes();
        bool AddParish(Parish parish);
        bool UpdateParish(Parish parish);
    }
}
