﻿using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Composifit.Core.Entities
{
    [Table("Cardio")]
    public class Cardio : MesoChild
    {
        public decimal TimeInMinutes { get; set; }

        public int IntensityId { get; set; }       

        public int MesoId { get; set; }
    }

    public enum Intensity
    {
        VeryLight = 1
    }
}
