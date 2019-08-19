using Composifit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conposifit.Infrastructure.DAOs
{
    internal class ExerciseDao
    {
        private readonly DapperUtil _db;

        public ExerciseDao(DapperUtil db)
        {
            _db = db;
        }
        public async Task Add(Exercise exercise)
        {
            await _db.Insert(exercise);
        }

        public async Task DeleteForMeso(int mesoId)
        {
            await _db.Execute("DELETE FROM Exercises WHERE MesoId = @mesoId", new { mesoId });
        }
    }
}