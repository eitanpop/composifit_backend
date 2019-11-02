using Composifit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Composifit.Domain.ServiceContracts
{
    public interface IExerciseService
    {
        Task<Exercise> FindById(int id);
        Task<int> Update(Exercise exercise);
        Task Delete(int exerciseId);
        Task DeleteSet(int execiseId, int setId);
        Task<dynamic> GetMuscleGroupBreakdown(int mesoId);
    }
}
