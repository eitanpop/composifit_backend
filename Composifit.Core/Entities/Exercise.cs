using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Composifit.Core.Entities
{
    public class Exercise: EntityWithName
    {
        public int Sets { get; set; }

        public int Reps { get; set; }

        public double Weight { get; set; }

        [Write(false)]
        public MuscleGroup MuscleGroup { get; set; }

        public int MuscleGroupId => (int)MuscleGroup;

        public DateTime? Date { get; set; }

        public int MesoId { get; set; }
    }

    public enum MuscleGroup
    {
        Chest = 1,
        Neck = 2
    }
}
