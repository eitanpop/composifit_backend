using Composifit.Domain.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Composifit.Controllers
{
    [ApiController]
    public class CardioController : Controller
    {
        private readonly ICardioService _service;

        public CardioController(ICardioService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("/[controller]/{id}/delete")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }

    }
}
