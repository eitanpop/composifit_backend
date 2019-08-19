using Composifit.Core;
using Composifit.Core.Entities;
using Composifit.Domain.ServiceContracts;
using Composifit.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Composifit.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class MesoController : Controller
    {
        private IMesoService _service;
        public MesoController(IMesoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(MesoCreateModel model)
        {
            Console.WriteLine(JsonConvert.SerializeObject(model));
            return await _service.Create(new Meso { BeginDate = model.BeginDate, EndDate = model.EndDate, Name = model.Name });
        }

        [HttpPost]
        [Route("/[controller]/exercise")]
        public async Task<ActionResult> Post(ExerciseCreateModel model)
        {
            Console.WriteLine(JsonConvert.SerializeObject(model));
            var meso = await _service.FindById(model.MesoId);

            Console.WriteLine(JsonConvert.SerializeObject(meso));

            var exercise = new Exercise
            {
                Date = model.Date,
                MesoId = model.MesoId,
                Name = model.Name,
                Reps = model.Reps,
                Sets = model.Sets,
                Weight = double.Parse(model.Weight)
            };

            meso.AddExercise(exercise);
            await _service.Update(meso);
            var updatedMeso = await  _service.FindById(model.MesoId);
            Console.WriteLine(JsonConvert.SerializeObject(updatedMeso));

            return Ok(updatedMeso.Exercises?.Count());
        }

        [HttpPost]
        [Route("/[controller]/cardio")]
        public async Task<ActionResult<int>> Post(CardioCreateModel model)
        {
            Console.WriteLine(JsonConvert.SerializeObject(model));
            var meso = await _service.FindById(model.MesoId);
            var cardio = new Cardio
            {
                Date = model.Date,
                MesoId = model.MesoId,
                Name = model.Name,
                TimeInMinutes = model.TimeInMinutes,
                Intensity = (Intensity)Enum.Parse(typeof(Intensity), model.Intensity)
            };
            meso.AddCardio(cardio);
            await _service.Update(meso);

            return Ok(meso.Cardios?.Count() );
        }


        [HttpGet]
        [Route("/[controller]/{id:int}")]
        public async Task<ActionResult<IEnumerable<MesoGetModel>>> Get(int id)
        {
            var entity = await _service.FindById(id);
            if (entity == null)
                return new NotFoundResult();
            return new OkObjectResult(entity);
        }


        [HttpGet]
        [Route("/[controller]/{id:int}/{date:DateTime}")]
        public async Task<ActionResult<DayGetModel>> Get(int id, DateTime date)
        {
            var meso = await _service.GetExercisesAndCardio(id, date);
            return new DayGetModel { Exercises = meso.Exercises, Cardios = meso.Cardios, Meso = GetSimpleModelFromMeso(meso.Meso) };
        }

        private MesoSimpleModel GetSimpleModelFromMeso(Meso meso)
        {
            return new MesoSimpleModel { BeginDate = meso.BeginDate, EndDate = meso.EndDate, Id = meso.Id, Name = meso.Name };
        }
    }
}
