using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Composifit.Domain.RepositoryContracts
{
    public interface IRepository<TEntity, Tid>
    {
        Task<int> Create(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
        Task<TEntity> FindByID(Tid id);
        Task<IEnumerable<TEntity>> FindAll();

    }
}
