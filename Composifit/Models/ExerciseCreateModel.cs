using System;

namespace Composifit.Models
{
    public class ExerciseCreateModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
       
        public string MuscleGroup { get; set; }
      
        public DateTime? Date { get; set; }

        public int MesoId { get; set; }
    }
}