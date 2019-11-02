using Composifit.Core.Entities;
using Composifit.Domain.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Composifit.Core;

namespace Composifit.Domain
{
    public class ExerciseService : IExerciseService
    {
        private readonly ComposifitDbContext _context;
        private readonly IMesoService _mesoService;
        private readonly IIdentityProvider _identity;

        public ExerciseService(ComposifitDbContext context, IMesoService mesoService, IIdentityProvider identityProvider)
        {
            _context = context;
            _mesoService = mesoService;
            _identity = identityProvider;
        }

        private IQueryable<Exercise> GetUserExercise(int exerciseId)
            => _context.Exercises.Where(x => x.Id == exerciseId && _mesoService.GetUserMesocycles().Any(y => y.Id == x.MesoId));
       
        public async Task<Exercise> FindById(int id) =>
             await GetUserExercise(id).FirstOrDefaultAsync();

        public async Task<int> Update(Exercise exercise)
        {
            if (exercise == null || !_mesoService.GetUserMesocycles().Select(x => x.Id).Any(y => y == exercise.MesoId))
                throw new NullReferenceException("Exercise could not be found");
            _context.Update(exercise);
            return await _context.SaveChangesAsync();
        }

        public async Task DeleteSet(int exerciseId, int setId)
        {
            var exercise = await GetUserExercise(exerciseId).Include(x => x.Sets).FirstOrDefaultAsync();
            var set = exercise.Sets.FirstOrDefault(x => x.Id == setId);
            _context.Sets.Remove(set);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int exerciseId)
        {
            var exercise = await FindById(exerciseId);
            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
        }

        public async Task<dynamic> GetMuscleGroupBreakdown(int mesoId)
        {
            var muscleGroupsWithCount = await _context.MuscleGroupCount.FromSql($"SELECT MuscleGroupId, COUNT(*) AS Count FROM Exercises e INNER JOIN Mesocycles m ON e.MesoId = m.Id WHERE m.UserId = '{_identity.GetUserId()}' AND m.Id = {mesoId} GROUP BY MuscleGroupId").ToListAsync();
            var allMuscleGroups = (int[])Enum.GetValues(typeof(MuscleGroup));
            muscleGroupsWithCount.AddRange(allMuscleGroups.
                Where(x => !muscleGroupsWithCount.Any(y => y.MuscleGroupId == x))
                .Select(z => new MuscleGroupCount { MuscleGroupId = z, Count = 0 }));

            return muscleGroupsWithCount.Select(x => new { Name = Enum.GetName(typeof(MuscleGroup), x.MuscleGroupId), x.Count }).ToList();
        }
        
    }
}
