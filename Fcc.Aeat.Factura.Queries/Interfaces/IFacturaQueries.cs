using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcc.Aeat.Factura.Queries.Interfaces
{
    public interface IFacturaQueries
    {
        

        Task<IEnumerable<Factura.Contracts.Models.Factura>>
            GetAll(string nif);
    }
}