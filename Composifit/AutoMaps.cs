using AutoMapper;
using Composifit.Core.Entities;
using Composifit.Domain.DomainModels;
using Composifit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Composifit
{
    public class AutoMaps : Profile
    {
        public AutoMaps()
        {
            CreateMap<ExerciseCreateModel, Exercise>()
                .ForMember(x => x.MuscleGroupId, opt => opt.MapFrom(y => GetMuscleGroupIdFromString(y.MuscleGroup)));
            CreateMap<CardioCreateModel, Cardio>();
            CreateMap<Meso, MesoWithExerciseAndUserSets>();
            CreateMap<Exercise, ExerciseDomainModel>();
            CreateMap<UserSet, UserSetDomainModel>();
            CreateMap<Meso, MesoGetModel>();
            CreateMap<SetCreateModel, Set>();
        }

        private int GetMuscleGroupIdFromString(string muscleGroup)
        {
            muscleGroup = Regex.Replace(muscleGroup, @"\s+", "").Trim();
            MuscleGroup result;
            if (!Enum.TryParse(muscleGroup,true, out result))
                return (int)MuscleGroup.Chest;
            return (int)result;
        }
    }
}
