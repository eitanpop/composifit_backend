using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Composifit.Domain.RepositoryContracts;
using Microsoft.AspNetCore.Mvc;

namespace Composifit.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ExerciseController : Controller
    {
        private readonly IExerciseRepository _repository;
        public ExerciseController(IExerciseRepository repository)
        {
            _repository = repository;
        }
        [Route("/[controller]/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var exercises = await _repository.FindByDayId(id);
            return Ok(exercises);
        }
    }
}