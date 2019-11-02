using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Composifit.Core.Entities
{
    public class MuscleGroupCount
    {
        [Key]
        public int MuscleGroupId { get; set; }
        public int Count { get; set; }
    }
}
