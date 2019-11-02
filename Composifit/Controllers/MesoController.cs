using AutoMapper;
using Composifit.Core;
using Composifit.Core.Entities;
using Composifit.Domain.ServiceContracts;
using Composifit.Models;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class MesoController : BaseController
    {
        private IMesoService _service;
        private IMapper _mapper;
        public MesoController(IMesoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]       
        [Route("/[controller]/{id:int}")]
        public async Task<ActionResult<dynamic>> Get(int id)
        {
            var entity = await _service.FindById(id);
            if (entity == null)
                return new NotFoundResult();         
            return Ok(entity);
        }

        [HttpGet]       
        [Route("/[controller]/{id:int}/date/{date:DateTime?}")]
        public async Task<ActionResult<DayGetModel>> Get(int id, DateTime? date = null)
        {
            var meso = await _service.GetExercisesAndCardio(id, date);
            return new DayGetModel { Exercises = meso.Exercises, Cardios = meso.Cardios, Meso = GetSimpleModelFromMeso(meso.Meso) };
        }

        [HttpGet]
        [Route("/mesos")]
        public async Task<ActionResult<IEnumerable<dynamic>>> Get()
        {
            var entities = await _service.FindAll();
            if (entities == null)
                return new NotFoundResult();
            return Ok(entities);
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
            var exercise = model.Id > 0 ? meso.Exercises.First(x => x.Id == model.Id) : new Exercise();
            meso.AddExercise(_mapper.Map(model, exercise));
            await _service.Update(meso);
            return Ok(meso.Exercises?.Count());
        }

        [HttpPost]
        [Route("/[controller]/cardio")]
        public async Task<ActionResult<int>> Post(CardioCreateModel model)
        {
            Console.WriteLine(JsonConvert.SerializeObject(model));
            var meso = await _service.FindById(model.MesoId);
            var cardio = model.Id > 0 ? meso.Cardios.First(x => x.Id == model.Id) : new Cardio();
            meso.AddCardio(_mapper.Map(model, cardio));
            await _service.Update(meso);
            return Ok(meso.Cardios?.Count());
        }

        [HttpPost]
        [Route("/[controller]/{mesoId}/clone/{fromDate}/{toDate}")]
        public async Task<ActionResult> Post(int mesoId, DateTime fromDate, DateTime toDate)
        {
            await _service.CloneExerciseAndCardioFromDay(mesoId, fromDate, toDate);
            return Ok();
        }

        private MesoSimpleModel GetSimpleModelFromMeso(Meso meso)
        {
            return new MesoSimpleModel { BeginDate = meso.BeginDate, EndDate = meso.EndDate, Id = meso.Id, Name = meso.Name };
        }
    }
}
