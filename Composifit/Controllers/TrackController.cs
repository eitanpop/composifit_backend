using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Composifit.Domain.DomainModels;
using Composifit.Domain.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Composifit.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class TrackController : Controller
    {
        private ITrackService _trackService;

        public TrackController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        [HttpGet]
        [Route("/[controller]/Exercises/{mesoId}/{date}")]
        public async Task<dynamic> GetExerciseForDayInMeso(int mesoId, DateTime date)
        {
            return await _trackService.GetExerciseForDayInMeso(mesoId, date);
        }
    }
}
