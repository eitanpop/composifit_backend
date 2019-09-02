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
    public class ExerciseController : Controller
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

        [Route("/[controller]/set/{id}/delete")]
        [HttpPost]
        public async Task<ActionResult> Post(int id)
        {           
            await _service.DeleteSet(id);
            return Ok();
        }
    }
}