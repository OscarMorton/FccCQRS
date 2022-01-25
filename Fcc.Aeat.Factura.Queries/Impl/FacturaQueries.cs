using Fcc.Aeat.core.Data;
using Fcc.Aeat.Factura.Queries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

using System.Threading.Tasks;

namespace Fcc.Aeat.Factura.Queries.Impl
{
    public class FacturaQueries : IFacturaQueries
    {
        private readonly ConnectionString _connectionString;

        public FacturaQueries(ConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Contracts.Models.Factura>> GetAll(string nif)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString.Value))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Adding the
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@Nif", nif);

                var facturas = (await conn
                                   .QueryAsync<Factura.Contracts.Models.Factura>
                                   ("Select * from Factura where Nif = @Nif",
                                   queryParameters)).ToList();

                return facturas;
            }
        }
    }
}