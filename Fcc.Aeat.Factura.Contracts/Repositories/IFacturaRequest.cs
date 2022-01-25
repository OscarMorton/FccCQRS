using Fcc.Aeat.Factura.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcc.Aeat.Factura.Contracts.Repositories
{
    public interface IFacturaRequest
    {
        Task Add(FacturaRequest factura);

        Task Update(FacturaRequest factura);

        Task Delete(int id);
    }
}