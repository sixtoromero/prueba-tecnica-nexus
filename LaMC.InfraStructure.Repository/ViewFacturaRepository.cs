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
    public class ViewFacturaRepository : IViewFacturaRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public ViewFacturaRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<ViewFactura>> getListFactura()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetViewFactura";
                var result = await connection.QueryAsync<ViewFactura>(query, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<ViewFactura>> getListFacturaByFecha(DateTime FechaInicio, DateTime FechaFin)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetViewFacturaByFecha";
                var parameters = new DynamicParameters();
                parameters.Add("FechaInicio", FechaInicio);
                parameters.Add("FechaFin", FechaFin);

                var result = await connection.QueryAsync<ViewFactura>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<TotalesByCamarero>> getTotalesporCamarero()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspGetTotalesporCamarero";                
                var result = await connection.QueryAsync<TotalesByCamarero>(query, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
