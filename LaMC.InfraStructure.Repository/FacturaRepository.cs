using Dapper;
using LaMC.Domain.Entity;
using LaMC.InfraStructure.Interface;
using LaMC.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace LaMC.InfraStructure.Repository
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public FacturaRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<string> InsertAsync(Factura model)
        {
            var jsonDetalle = JsonConvert.SerializeObject(model.DetalleFactura);            

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspFacturaInsert";
                var parameters = new DynamicParameters();

                parameters.Add("IdCliente", model.IdCliente);
                parameters.Add("IdCamarero", model.IdCamarero);
                parameters.Add("IdMesa", model.IdMesa);
                parameters.Add("Detalle", jsonDetalle);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> UpdateAsync(Factura model)
        {
            var jsonDetalle = JsonConvert.SerializeObject(model.DetalleFactura);

            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspFacturaUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("IdFactura", model.IdFactura);
                parameters.Add("IdCliente", model.IdCliente);
                parameters.Add("IdCamarero", model.IdCamarero);
                parameters.Add("IdMesa", model.IdMesa);
                parameters.Add("Detalle", jsonDetalle);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> DeleteAsync(int? Id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspFacturaDelete";
                var parameters = new DynamicParameters();

                parameters.Add("IdFactura", Id);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<IEnumerable<Factura>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetFacturas";
                var result = await connection.QueryAsync<Factura>(query, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<Factura> GetAsync(int? Id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetFacturaByID";
                var parameters = new DynamicParameters();

                parameters.Add("IdFactura", Id);

                var result = await connection.QuerySingleAsync<Factura>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
