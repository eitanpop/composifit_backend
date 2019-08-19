using System;

namespace Composifit.Models
{
    public class ExerciseCreateModel
    {
        public string Name { get; set; }
        public int Sets { get; set; }

        public int Reps { get; set; }

        public string Weight { get; set; }
        
        public string MuscleGroup { get; set; }
      
        public DateTime? Date { get; set; }

        public int MesoId { get; set; }
    }
}