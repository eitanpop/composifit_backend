
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Composifit.Core.Entities { 

    public class Exercise : MesoChild
    {
        public Exercise()
        {
            Sets = new HashSet<Set>();
        }       
        public int MuscleGroupId {get;set;}

        public int MesoId { get; set; }

        public ICollection<Set> Sets { get; set; }

        public void AddSet(Set set)
        {
            Sets.Add(set);
        }
    }

    public enum MuscleGroup
    {
        Chest = 1,
        Neck = 2,
        UpperBack= 3,
        LowerBack=4,
        Traps = 5,
        Lats = 6,
        Biceps = 7,
        Triceps = 8,
        Forearms = 9,
        Abs = 10,
        Glutes = 11,
        Quads = 12,
        Hamstring = 13,
        Calves = 14
    }
}
