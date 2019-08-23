using Composifit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Composifit.Infrastructure.DAOs
{
    public class CardioDao
    {
        private readonly DapperUtil _db;

        public CardioDao(DapperUtil db)
        {
            _db = db;
        }
        public async Task Add(Cardio cardio)
        {
            await _db.Insert(cardio);

        }

        public async Task DeleteForMeso(int mesoId)
        {
            await _db.Execute("DELETE FROM Cardio WHERE MesoId = @mesoId", new { mesoId });
        }
    }
}
