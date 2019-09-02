using Composifit.Core.Entities;
using Composifit.Domain.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Composifit.Domain
{
    public class ExerciseService : IExerciseService
    {
        private readonly ComposifitDbContext _context;
        public ExerciseService(ComposifitDbContext context)
        {
            _context = context;
        }

        public async Task<Exercise> FindById(int id)
        {
            return await _context.FindAsync<Exercise>(id);
        }
        public async Task<int> Update(Exercise exercise)
        {
            _context.Update(exercise);
            return await _context.SaveChangesAsync();
        }

        public async Task DeleteSet(int setId)
        {
            var set = await _context.FindAsync<Set>(setId);
            _context.Sets.Remove(set);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int exerciseId)
        {
            var exercise = await _context.FindAsync<Exercise>(exerciseId);
            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
        }
    }
}
