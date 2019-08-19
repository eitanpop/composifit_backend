using Composifit.Core;
using Composifit.Domain.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Composifit.Domain.RepositoryContracts;
using Composifit.Core.Entities;
using Conposifit.Infrastructure.DAOs;

namespace Conposifit.Infrastructure.Repositories
{
    public class MesoRepository : IMesoRepository
    {
        private DapperUtil _dapper;

        public MesoRepository(SqlConnectionStringFactory connectionStrings)
        {
            _dapper = new DapperUtil(connectionStrings.DefaultConnection);
        }
        public async Task<int> Create(Meso entity) => await _dapper.Insert(entity);

        public async Task<IEnumerable<Meso>> FindAll()
        {
            return await Build(GetMesoSqlQuery());
        }

        public async Task<Meso> FindByID(int id)
        {
            try
            {
                var mesos = await Build($"{GetMesoSqlQuery()} WHERE m.Id = @id", new { id });
                return mesos?.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new Meso();
            }
        }

        public Task Remove(Meso entity)
        {
            throw new NotImplementedException();
        }

        private static object _sync = new object();
        public async Task Update(Meso entity)
        {
            var exerciseDao = new ExerciseDao(_dapper);
            var cardioDao = new CardioDao(_dapper);

            await exerciseDao.DeleteForMeso(entity.Id);
             await cardioDao.DeleteForMeso(entity.Id);
            foreach(var cardio in entity.Cardios)            
                await cardioDao.Add(cardio);

            foreach (var exercise in entity.Exercises)
                await exerciseDao.Add(exercise);

            // entity.Cardios.ToList().ForEach(async cardio => await cardioDao.Add(cardio));
            //  entity.Exercises.ToList().ForEach(async exercise => await exerciseDao.Add(exercise));           
        }

        private string GetMesoSqlQuery() => "SELECT m.*,e.*,c.* FROM Mesocycles m LEFT JOIN Exercises e ON e.mesoId = m.Id LEFT JOIN Cardio c On c.MesoId = m.Id";

        private async Task<IEnumerable<Meso>> Build(string sql, object parameter = null)
        {
            IDictionary<int, Meso> mesos = new Dictionary<int, Meso>();
            return await _dapper.SelectAsync<Meso, Exercise, Cardio, Meso>(sql, (mesoEntity, exercise, cardio) =>
            {
                Meso meso;
                if (!mesos.TryGetValue(mesoEntity.Id, out meso))
                    mesos.Add(mesoEntity.Id, meso = mesoEntity);
                meso.AddExercise(exercise);
                meso.AddCardio(cardio);

                return meso;
            }, parameter, "Id");
        }
    }
}
