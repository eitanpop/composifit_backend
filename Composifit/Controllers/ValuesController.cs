using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Composifit.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Composifit.Controllers
{
    [Route("/")]
    [Route("/Values")]
    public class ValuesController : Controller
    {
        IValueRepository _repository;
        public ValuesController(IValueRepository repository)
        {
            _repository = repository;
        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get() => await _repository.GetValues();
        

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
