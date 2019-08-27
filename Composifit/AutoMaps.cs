using AutoMapper;
using Composifit.Core.Entities;
using Composifit.Domain.DomainModels;
using Composifit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Composifit
{
    public class AutoMaps : Profile
    {
        public AutoMaps()
        {
            CreateMap<ExerciseCreateModel, Exercise>();
            CreateMap<CardioCreateModel, Cardio>();
            CreateMap<Meso, MesoWithExerciseAndUserSets>();
            CreateMap<Exercise, ExerciseDomainModel>();
            CreateMap<UserSet, UserSetDomainModel>();
            CreateMap<Meso, MesoGetModel>();
        }
    }
}
