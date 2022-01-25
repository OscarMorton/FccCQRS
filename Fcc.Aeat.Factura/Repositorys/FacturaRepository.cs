using Dapper;
using Fcc.Aeat.core.Data;
using Fcc.Aeat.Factura.Contracts.Models;
using Fcc.Aeat.Factura.Contracts.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcc.Aeat.Factura.Repositorys
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly ConnectionString _ConnectionString;

        public FacturaRepository(ConnectionString connectionString)
        {
            _ConnectionString = connectionString;
        }

        public async Task Add(FacturaRequest factura)
        {
            using (var conn = new SqlConnection(_ConnectionString.Value))
            {
                const string query = "INSERT INTO FACTURA(Nif,Pais,Importe,Base,Iva,fecha) VALUES" +
                    "(@Nif,@Pais,@Importe,@Base,@Iva,@fecha);SELECT CAST(SCOPE_IDENTITY() as int)";

                await conn.ExecuteAsync(query,
                    new
                    {
                        Nif = factura.Nif,
                        Pais = factura.Pais,
                        Importe = factura.Importe,
                        Base = factura.Base,
                        Iva = factura.Iva,
                        Fecha = factura.Fecha
                    });
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var connection = new SqlConnection(_ConnectionString.Value))
            {
                // Adding the id parameters for the SQL query
                var queryParameter = new DynamicParameters();
                queryParameter.Add("@Id", id);

                int validation = await connection.ExecuteAsync("DELETE FROM Factura WHERE Id = @Id", queryParameter);

                if (validation > 0)
                {
                    return true;
                }
                else
                {
                    return true;
                }
            }
        }

        public async Task Update(FacturaRequest factura)
        {
            using (var conn = new SqlConnection(_ConnectionString.Value))
            {
                const string query = "UPDATE FACTURA SET Nif=@Nif,Pais=@Pais,Importe=@Importe,Base=@Base,Iva=@Iva,Fecha=@Fecha WHERE id = @id";

                await conn.ExecuteAsync(query,
                    new
                    {
                        Nif = factura.Nif,
                        Pais = factura.Pais,
                        Importe = factura.Importe,
                        Base = factura.Base,
                        Iva = factura.Iva,
                        Fecha = factura.Fecha,
                        Id = factura.Id
                    });
            }
        }
    }
}