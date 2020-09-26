using Dapper;
using LaMC.Domain.Entity;
using LaMC.InfraStructure.Interface;
using LaMC.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace LaMC.InfraStructure.Repository
{
    public class CocineroRepository : ICocineroRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public CocineroRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<string> InsertAsync(Cocinero model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspCocineroInsert";
                var parameters = new DynamicParameters();
                
                parameters.Add("Nombre", model.Nombre);
                parameters.Add("Apellido1", model.Apellido1);
                parameters.Add("Apellido2", model.Apellido2);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> UpdateAsync(Cocinero model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspCocineroUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("IdCocinero", model.IdCocinero);
                parameters.Add("Nombre", model.Nombre);
                parameters.Add("Apellido1", model.Apellido1);
                parameters.Add("Apellido2", model.Apellido2);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> DeleteAsync(int? Id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspCocineroDelete";
                var parameters = new DynamicParameters();

                parameters.Add("IdCocinero", Id);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<IEnumerable<Cocinero>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetCocineros";
                var result = await connection.QueryAsync<Cocinero>(query, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<Cocinero> GetAsync(int? Id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetCocineroByID";
                var parameters = new DynamicParameters();

                parameters.Add("IdCocinero", Id);

                var result = await connection.QuerySingleAsync<Cocinero>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
