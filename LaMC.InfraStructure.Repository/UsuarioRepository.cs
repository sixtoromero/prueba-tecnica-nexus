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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public UsuarioRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<string> InsertAsync(Usuario model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspUsuarioInsert";
                var parameters = new DynamicParameters();

                parameters.Add("NombreUsuario", model.NombreUsuario);
                parameters.Add("Clave", model.Clave);                

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> UpdateAsync(Usuario model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspUsuarioUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("IdUsuario", model.IdUsuario);
                parameters.Add("NombreUsuario", model.NombreUsuario);
                parameters.Add("Clave", model.Clave);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> DeleteAsync(int? Id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspUsuarioDelete";
                var parameters = new DynamicParameters();

                parameters.Add("IdUsuario", Id);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetUsuarios";
                var result = await connection.QueryAsync<Usuario>(query, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<Usuario> GetAsync(int? Id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetClienteByID";
                var parameters = new DynamicParameters();

                parameters.Add("IdUsuario", Id);

                var result = await connection.QuerySingleAsync<Usuario>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<Usuario> getLogin(Usuario model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                try
                {
                    var query = "UspgetLogin";
                    var parameters = new DynamicParameters();

                    parameters.Add("NombreUsuario", model.NombreUsuario);
                    parameters.Add("Clave", model.Clave);

                    //var result = await connection.QuerySingleAsync<Usuario>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    var result = await connection.QueryFirstOrDefaultAsync<Usuario>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
                catch (Exception ex)
                {
                    return null;
                }
                
            }
        }
    }
}
