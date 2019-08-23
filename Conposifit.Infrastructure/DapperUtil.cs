using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Composifit.Infrastructure
{
    public class DapperUtil
    {
        private string _connectionString;
        public DapperUtil(string connectionString)
        {
            if (String.IsNullOrEmpty(connectionString))
                throw new ArgumentException(nameof(connectionString));

            _connectionString = connectionString;
        }
        private IDbConnection GetConnection() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<T>> SelectAsync<T>(string sql, object parameters = null) => await RunQueryOrCommandAsync(x => x.QueryAsync<T>(sql, parameters));
        public async Task<IEnumerable<TReturn>> SelectAsync<T, T2, TReturn>(string sql, Func<T, T2, TReturn> map, object parameters = null, string splitOn = null) =>
            await RunQueryOrCommandAsync(x => x.QueryAsync(sql, map, parameters, splitOn: splitOn));
        public async Task<IEnumerable<TReturn>> SelectAsync<T, T2, T3, TReturn>(string sql, Func<T, T2, T3, TReturn> map, object parameters = null, string splitOn = null) =>
           await RunQueryOrCommandAsync(x => x.QueryAsync(sql, map, parameters, splitOn: splitOn));

        public async Task<int> Insert<T>(T entity) where T : class => await RunQueryOrCommandAsync(x => x.InsertAsync<T>(entity));

        public async Task<bool> Update<T>(T entity) where T : class => await RunQueryOrCommandAsync(x => x.UpdateAsync(entity));

        public async Task Execute(string sql, object parameters) => await RunQueryOrCommandAsync(x => x.ExecuteAsync(sql, parameters));

        private async Task<T> RunQueryOrCommandAsync<T>(Func<IDbConnection, Task<T>> commandOrQueryFunc)
        {
            using (var cn = GetConnection())
                return await commandOrQueryFunc(cn);
        }
    }
}
