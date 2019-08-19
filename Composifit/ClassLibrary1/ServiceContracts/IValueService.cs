using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Composifit.Domain.ServiceContracts
{
    public interface IValueService
    {
        Task<IEnumerable<string>> GetValues();
    }
}
