using Composifit.Core;
using Composifit.Domain.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Composifit.Core.Entities;

namespace Composifit.Domain
{
    public class MesoService : IMesoService
    {
        private IMesoRepository _repository;
        public MesoService(IMesoRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Create(Meso meso)
        {
            return await _repository.Create(meso);
        }

        public async Task<IEnumerable<Meso>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<Meso> FindById(int id)
        {
            return await _repository.FindByID(id);
        }

        public async Task Update(Meso meso)
        {
            await _repository.Update(meso);
        }

        public async Task<(Meso Meso, IEnumerable<Exercise> Exercises, IEnumerable<Cardio> Cardios)> GetExercisesAndCardio(int mesoId, DateTime date)
        {
            var meso = await FindById(mesoId);
            var exercises = meso.Exercises?.Where(x => x.Date.Value.Date == date.Date);
            var cardios = meso.Cardios?.Where(x => x.Date.Value.Date == date.Date);
            return (meso, exercises, cardios);
        }


        public async Task CloneExercisesAndCardioToDate(int mesoId, DateTime dayFrom, DateTime dayTo)
        {
            var meso = await FindById(mesoId);
            var cardioAndExercises = await GetExercisesAndCardio(mesoId, dayFrom);
            meso.Cardios.ToList().ForEach(cardio =>
            {
                cardio.Date = dayTo;
                meso.AddCardio(cardio);
            });

            meso.Exercises.ToList().ForEach(exercise =>
            {
                exercise.Date = dayTo;
                meso.AddExercise(exercise);
            });

            await Update(meso);
        }
    }

}
