using System;
using System.Collections.Generic;
using System.Text;

namespace Composifit.Core.Entities
{
    public class Set : Entity
    {
        public int Reps { get; set; }
        public decimal Weight { get; set; }
        public int ExerciseId { get; set; }
        public UserSet UserSet { get; set; }
    }
}
