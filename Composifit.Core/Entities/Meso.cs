using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace Composifit.Core.Entities

{
    [Table("Mesocycles")]
    public class Meso : EntityWithName
    {
        public Meso()
        {
            Cardios = new HashSet<Cardio>();
            Exercises = new HashSet<Exercise>();
        }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        
        public ICollection<Exercise> Exercises  {get;  set;}
        public void AddExercise(Exercise exercise)
        {
            if (exercise != null && !Exercises.Any(x=>x.Id == exercise.Id))
                Exercises.Add(exercise);
        }

        public ICollection<Cardio> Cardios { get; set; }
        public void AddCardio(Cardio cardio)
        {
            if (cardio != null && !Cardios.Any(x => x.Id == cardio.Id))
                Cardios.Add(cardio);
        }
    }
}
