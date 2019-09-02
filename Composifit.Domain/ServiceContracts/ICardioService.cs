using Composifit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Composifit.Domain.ServiceContracts
{
    public interface ICardioService
    {
        Task<Cardio> FindById(int id);
        Task<int> Update(Cardio cardio);
        Task Delete(int cardioId);        
    }
}
