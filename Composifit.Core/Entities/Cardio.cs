using System;
using System.Collections.Generic;
using System.Text;

namespace Composifit.Core.Entities
{
    public class Cardio : EntityWithName
    {
        public double TimeInMinutes { get; set; }

        public int IntensityId => (int)Intensity;

        public Intensity Intensity { get; set; }

        public DateTime? Date { get; set; }

        public int MesoId { get; set; }
    }

    public enum Intensity
    {
        VeryLight = 1
    }
}
