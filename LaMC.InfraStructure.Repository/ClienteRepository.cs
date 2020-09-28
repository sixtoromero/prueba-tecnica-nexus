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
    public class ClienteRepository : IClienteRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public ClienteRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<string> InsertAsync(Cliente model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspClienteInsert";
                var parameters = new DynamicParameters();

                parameters.Add("Nombre", model.Nombre);
                parameters.Add("Apellido1", model.Apellido1);
                parameters.Add("Apellido2", model.Apellido2);
                parameters.Add("Observaciones", model.Observaciones);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> UpdateAsync(Cliente model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspClienteUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("IdCliente", model.IdCliente);
                parameters.Add("Nombre", model.Nombre);
                parameters.Add("Apellido1", model.Apellido1);
                parameters.Add("Apellido2", model.Apellido2);
                parameters.Add("Observaciones", model.Observaciones);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> DeleteAsync(int? Id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspClienteDelete";
                var parameters = new DynamicParameters();

                parameters.Add("IdCliente", Id);
                
                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetClientes";
                var result = await connection.QueryAsync<Cliente>(query, commandType: CommandType.StoredProcedure);
                
                return result;
            }
        }

        public async Task<Cliente> GetAsync(int? Id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetClienteByID";
                var parameters = new DynamicParameters();

                parameters.Add("IdCliente", Id);

                var result = await connection.QuerySingleAsync<Cliente>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
