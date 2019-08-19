using Composifit.Domain.Repositories;
using Composifit.Domain.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Composifit.Domain
{
    public class ValueService : IValueService
    {
        private IValueRepository _repository;
        public ValueService(IValueRepository repository)
        {
            _repository = repository;
        }
        public Task<IEnumerable<string>> GetValues()
        {
            return _repository.GetValues();
        }
    }
}
