using System;
using System.Collections.Generic;
using System.Text;
using Composifit.Core.Entities;
using Dapper.Contrib.Extensions;
using System.Linq;

namespace Composifit.Core.Entities

{
    [Table("Mesocycles")]
    public class Meso : EntityWithName
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        [Write(false)]
        public IList<Exercise> Exercises => _exercises;
        private readonly IList<Exercise> _exercises = new List<Exercise>();
        public void AddExercise(Exercise exercise)
        {
            if (exercise != null && !_exercises.Any(x=>x.Id == exercise.Id))
                _exercises.Add(exercise);
        }

        [Write(false)]
        public IList<Cardio> Cardios => _cardio;
        private readonly IList<Cardio> _cardio = new List<Cardio>();
        public void AddCardio(Cardio cardio)
        {
            if (cardio != null && !_cardio.Any(x => x.Id == cardio.Id))
                _cardio.Add(cardio);
        }
    }
}
