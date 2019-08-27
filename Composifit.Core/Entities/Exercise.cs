
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Composifit.Core.Entities { 

    public class Exercise : EntityWithName
    {
        public Exercise()
        {
            Sets = new HashSet<Set>();
        }       
        public int MuscleGroupId {get;set;}

        public DateTime Date { get; set; }

        public int MesoId { get; set; }

        public ICollection<Set> Sets { get; set; }
    }

    public enum MuscleGroup
    {
        Chest = 1,
        Neck = 2
    }
}
