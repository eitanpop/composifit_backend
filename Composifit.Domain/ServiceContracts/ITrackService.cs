using Composifit.Core.Entities;
using Composifit.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Composifit.Domain.ServiceContracts
{
    public interface ITrackService
    {
        Task<dynamic> GetExerciseForDayInMeso(int mesoId, DateTime date);
    }
}
