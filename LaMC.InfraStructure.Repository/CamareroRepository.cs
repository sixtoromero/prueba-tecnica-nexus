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
    public class CamareroRepository : ICamareroRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public CamareroRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<string> InsertAsync(Camarero model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspCamareroInsert";
                var parameters = new DynamicParameters();

                parameters.Add("Nombre", model.Nombre);
                parameters.Add("Apellido1", model.Apellido1);
                parameters.Add("Apellido2", model.Apellido2);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> UpdateAsync(Camarero model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspCamareroUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("IdCamarero", model.IdCamarero);
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
                var query = "uspCamareroDelete";
                var parameters = new DynamicParameters();

                parameters.Add("IdCamarero", Id);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<IEnumerable<Camarero>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetCamareros";
                var result = await connection.QueryAsync<Camarero>(query, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<Camarero> GetAsync(int? Id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetCamareroByID";
                var parameters = new DynamicParameters();

                parameters.Add("IdCamarero", Id);

                var result = await connection.QuerySingleAsync<Camarero>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
