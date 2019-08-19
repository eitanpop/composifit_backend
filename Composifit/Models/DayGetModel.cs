using Composifit.Core;
using Composifit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Composifit.Models
{
    public class DayGetModel
    {
        public MesoSimpleModel Meso { get; set; }
        public IEnumerable<Exercise> Exercises { get; set; }
        public IEnumerable<Cardio> Cardios { get; set; }
    }
}
