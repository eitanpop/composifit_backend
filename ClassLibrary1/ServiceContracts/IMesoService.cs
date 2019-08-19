using Composifit.Core;
using Composifit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Composifit.Domain.ServiceContracts
{
    public interface IMesoService
    {
        Task<(Meso Meso, IEnumerable<Exercise> Exercises, IEnumerable<Cardio> Cardios)> GetExercisesAndCardio(int mesoId, DateTime date);
        Task<int> Create(Meso meso);
        Task<Meso> FindById(int id);
        Task<IEnumerable<Meso>> FindAll();
        Task Update(Meso meso);
    }
}
