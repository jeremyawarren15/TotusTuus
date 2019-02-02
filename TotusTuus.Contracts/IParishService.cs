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
        Parish GetParish(int id);
        bool AddParish(Parish parish);
        bool UpdateParish(Parish parish);
    }
}
