using Composifit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Composifit.Domain.RepositoryContracts
{
    public interface IExerciseRepository : IRepository<Exercise, int>
    {
        Task<IEnumerable<Exercise>> FindByDayId(int id);
    }
}
