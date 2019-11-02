using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Composifit.Core.Entities;
using Composifit.Domain.ServiceContracts;
using Composifit.Models;
using Microsoft.AspNetCore.Mvc;

namespace Composifit.Controllers
{
    [ApiController]
    public class ExerciseController : BaseController
    {
        private readonly IExerciseService _service;
        private readonly IMapper _mapper;
        public ExerciseController(IExerciseService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
                
        [Route("/[controller]/set")]
        [HttpPost]
        public async Task<ActionResult<int>> Post(SetCreateModel model)
        {
            var exercise = await _service.FindById(model.ExerciseId);
            var set = _mapper.Map<Set>(model);
            exercise.AddSet(set);
            await _service.Update(exercise);
            return Ok(set.Id);           
        }

        [Route("/[controller]/{id}/delete")]
        [HttpDelete]       
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }

        [Route("/[controller]/{exerciseId}/set/{setId}/delete")]
        [HttpDelete]
        public async Task<ActionResult> DeleteSet(int exerciseId, int setId)
        {           
            await _service.DeleteSet(exerciseId, setId);
            return Ok();
        }

        [Route("/meso/{mesoId}/MuscleGroups")]
        [HttpGet]
        public async Task<ActionResult<dynamic>> Get(int mesoId)
        {
           return await _service.GetMuscleGroupBreakdown(mesoId);
        }
    }
}