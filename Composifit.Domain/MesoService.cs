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
        private IIdentityProvider _identity;
        public MesoService(ComposifitDbContext context, IIdentityProvider identityProvider)
        {
            _context = context;
            _identity = identityProvider;
        }
        public async Task<int> Create(Meso meso)
        {
            meso.UserId = _identity.GetUserId();
            _context.Add(meso);
            await _context.SaveChangesAsync();
            return meso.Id;
        }

        public async Task<IEnumerable<Meso>> FindAll()
        {
            return await GetUserMesocycles()
                .Where(x => x.UserId == _identity.GetUserId())
                 .Include(x => x.Exercises)
                 .ThenInclude(x => x.Sets)
                 .ThenInclude(x => x.UserSet)
                 .Include(x => x.Cardios)
                 .ToListAsync();
        }

        public async Task<Meso> FindById(int id)
        {
            return await GetUserMesocycles()
                 .Where(x => x.UserId == _identity.GetUserId())
                 .Where(meso => meso.Id == id)
                 .Include(x => x.Exercises)
                 .ThenInclude(x => x.Sets)
                 .ThenInclude(x => x.UserSet)
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
            var meso = await GetUserMesocycles().Where(x => x.Id == mesoId)
                .Include(x => x.Exercises)
                 .ThenInclude(x => x.Sets)
                 .Include(x => x.Cardios)
                 .FirstOrDefaultAsync();
            if (meso == null)
                throw new NullReferenceException("Unable to find Mesocycle");
            var exercises = meso.Exercises?.Where(x => x.Date.Date == (date?.Date ?? meso.BeginDate));
            var cardios = meso.Cardios?.Where(x => x.Date.Date == (date?.Date ?? meso.BeginDate));
            return (meso, exercises, cardios);
        }

        public async Task CloneExerciseAndCardioFromDay(int mesoId, DateTime fromDate, DateTime toDate)
        {
            var meso = await GetUserMesocycles().Where(x => x.Id == mesoId)
                .Include(x => x.Exercises)
                 .ThenInclude(x => x.Sets)
                 .ThenInclude(x => x.UserSet)
                .Include(x => x.Cardios)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            var exercises = meso.Exercises.Where(x => x.Date == fromDate);
            var cardios = meso.Cardios.Where(x => x.Date == fromDate);
            foreach (var exercise in exercises)
            {
                exercise.Id = 0;
                exercise.Date = toDate;
                foreach (var set in exercise.Sets)
                    set.Id = 0;
                _context.Exercises.Add(exercise);
            }

            foreach (var cardio in cardios)
            {
                cardio.Id = 0;
                cardio.Date = toDate;
                _context.Cardio.Add(cardio);
            }

            await _context.SaveChangesAsync();
        }

        public IQueryable<Meso> GetUserMesocycles() =>
         _context.Mesocycles.Where(x => x.UserId == _identity.GetUserId());

    }
}
