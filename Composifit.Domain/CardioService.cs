using Composifit.Core.Entities;
using Composifit.Domain.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Composifit.Domain
{
    public class CardioService : ICardioService
    {
        private readonly ComposifitDbContext _context;
        public CardioService(ComposifitDbContext context)
        {
            _context = context;
        }
        public async Task Delete(int cardioId)
        {
            var cardioToRemove = await _context.FindAsync<Cardio>(cardioId);
            _context.Cardio.Remove(cardioToRemove);
            await _context.SaveChangesAsync();
        }

        public Task<Cardio> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Cardio cardio)
        {
            throw new NotImplementedException();
        }
    }
}
