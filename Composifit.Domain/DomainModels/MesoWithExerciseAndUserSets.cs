using System;
using System.Collections.Generic;
using System.Text;

namespace Composifit.Domain.DomainModels
{
    public class MesoWithExerciseAndUserSets
    {
        public string Name { get; set; }
        public IList<ExerciseDomainModel> Exercises { get; set; }

    }

    public class ExerciseDomainModel
    {
        public int Id { get; set; }
        public string Name { get; set; }     
        public IList<UserSetDomainModel> UserSets { get; set; }
    }

    public class SetDomainModel
    {
       
    }

    public class UserSetDomainModel
    {
        public int Id { get; set; } 
        public int Reps { get; set; }
        public string Weight { get; set; }
        public int ActualReps { get; set; }
        public string ActualWeight { get; set; }
        public int SetNumber { get; set; }
    }
}
