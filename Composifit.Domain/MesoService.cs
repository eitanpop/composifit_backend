using Composifit.Core;
using Composifit.Domain.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Composifit.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Composifit.Domain.Extensions;

namespace Composifit.Domain
{
    public class MesoService : IMesoService
    {
        private ComposifitDbContext _context;
        public MesoService(ComposifitDbContext context)
        {          
            _context = context;
        }
        public async Task<int> Create(Meso meso)
        {
            _context.Add(meso);
            await _context.SaveChangesAsync();
            return meso.Id;
        }

        public async Task<IEnumerable<Meso>> FindAll()
        {
            return await _context.Mesocycles
                 .Include(x => x.Exercises)
                 .Include(x => x.Cardios)
                 .ToListAsync();
        }

        public async Task<Meso> FindById(int id)
        {
            return await _context.Mesocycles
                 .Where(meso => meso.Id == id)
                 .Include(x => x.Exercises)
                 .Include(x => x.Cardios)
                 .FirstOrDefaultAsync();
        }

        public async Task Update(Meso meso)
        {
            _context.Update(meso);
            await _context.SaveChangesAsync();
        }

        public async Task<(Meso Meso, IEnumerable<Exercise> Exercises, IEnumerable<Cardio> Cardios)> GetExercisesAndCardio(int mesoId, DateTime? date)
        {
            var meso = await FindById(mesoId);
            var exercises = meso.Exercises?.Where(x => x.Date.Value.Date == (date?.Date ?? meso.BeginDate));
            var cardios = meso.Cardios?.Where(x => x.Date.Value.Date == (date?.Date ?? meso.BeginDate));
            return (meso, exercises, cardios);
        }

        public async Task CloneExercisesAndCardioToDate(int mesoId, DateTime dayFrom, DateTime dayTo)
        {
            var meso = await FindById(mesoId);
            var cardioAndExercises = await GetExercisesAndCardio(mesoId, dayFrom);
            cardioAndExercises.Cardios.ToList().ForEach(x =>
            {
                var cardio = new Cardio
                {
                    Date = dayTo,
                    MesoId = mesoId,
                    Name = x.Name,
                    TimeInMinutes = x.TimeInMinutes
                };

                meso.AddCardio(cardio);
            });

            cardioAndExercises.Exercises.ToList().ForEach(x =>
            {
                var exercise = new Exercise
                {
                    Date = dayTo,
                    MesoId = x.MesoId,
                    Name = x.Name,
                    Reps = x.Reps,
                    Sets = x.Sets,
                    Weight = x.Weight,

                };
                meso.AddExercise(exercise);
            });

            await Update(meso);
        }


    }

}
