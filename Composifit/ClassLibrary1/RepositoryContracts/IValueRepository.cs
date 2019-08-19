using Composifit.Domain.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Composifit.Domain.Repositories
{
    public interface IValueRepository : IRepository<string,int>
    {
        Task<IEnumerable<string>> GetValues();
    }
}
