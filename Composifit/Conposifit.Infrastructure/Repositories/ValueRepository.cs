using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Composifit.Core;
using Composifit.Domain.Repositories;

namespace Composifit.Infrastructure.Repositories
{
    public class ValueRepository : IValueRepository
    {
        private string _connectionString;
        public ValueRepository(SqlConnectionStringFactory connectionStrings)
        {
            _connectionString = connectionStrings.DefaultConnection;
        }

        public Task<int> Create(string entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<string> FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<string>> GetValues()
        {
            using (var cn = GetConnection())
                return await cn.QueryAsync<string>("SELECT [Value] FROM [Values]");
        }

        public Task Remove(string entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(string entity)
        {
            throw new NotImplementedException();
        }

        private IDbConnection GetConnection() => new SqlConnection(_connectionString);
       
    }
}
