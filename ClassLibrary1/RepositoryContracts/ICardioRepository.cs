using Composifit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Composifit.Domain.RepositoryContracts
{
    public interface ICardioRepository : IRepository<Cardio, int>
    {
        Task<IEnumerable<Cardio>> FindByDayId(int id);
    }
}
