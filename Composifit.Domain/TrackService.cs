using Composifit.Domain.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Composifit.Core.Entities;
using AutoMapper;
using Composifit.Domain.DomainModels;

namespace Composifit.Domain
{
    public class TrackService : ITrackService
    {
        private ComposifitDbContext _context;
        private IMapper _mapper;

        public TrackService(ComposifitDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<dynamic> GetExerciseForDayInMeso(int mesoId, DateTime date)
        {
            return await _context.Mesocycles.Where(meso => meso.Id == mesoId)
                .Select(meso => new
                {
                    meso.Name,
                    Exercises = meso.Exercises.Where(exercise => exercise.MesoId == mesoId)
                    .Select(exercise => new
                    {
                        exercise.Id,
                        exercise.Name,
                        Sets = exercise.Sets.Select(set =>
                        new
                        {
                            set.Id,
                            set.Reps,
                            set.Weight,
                            UserSet = set.UserSet
                        })
                    })
                }
             ).FirstOrDefaultAsync();
        }

        private void ConsolidateExercises(MesoWithExerciseAndUserSets myMeso)
        {

        }

        private void PadMesoWithUserSets(MesoWithExerciseAndUserSets meso)
        {
        }

        private void PadUserSets(int sets, IList<UserSetDomainModel> userSets)
        {

        }

        public async Task<UserSet> SaveUserSet(UserSet userSet)
        {
            Console.WriteLine(userSet);
            return await Task.Run(() => userSet);
        }
    }
}
