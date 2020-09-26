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
    public class MesaRepository : IMesaRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public MesaRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<string> InsertAsync(Mesa model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspMesaInsert";
                var parameters = new DynamicParameters();

                parameters.Add("NumMaxComensa", model.NumMaxComensa);
                parameters.Add("Ubicacion", model.Ubicacion);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> UpdateAsync(Mesa model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspMesaUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("IdMesa", model.IdMesa);
                parameters.Add("NumMaxComensa", model.NumMaxComensa);
                parameters.Add("Ubicacion", model.Ubicacion);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> DeleteAsync(int? Id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspMesaDelete";
                var parameters = new DynamicParameters();

                parameters.Add("IdMesa", Id);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<IEnumerable<Mesa>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetMesas";
                var result = await connection.QueryAsync<Mesa>(query, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<Mesa> GetAsync(int? Id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetMesaByID";
                var parameters = new DynamicParameters();

                parameters.Add("IdMesa", Id);

                var result = await connection.QuerySingleAsync<Mesa>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
