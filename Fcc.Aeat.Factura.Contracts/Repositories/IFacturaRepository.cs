using Fcc.Aeat.Factura.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcc.Aeat.Factura.Contracts.Repositories
{
    public interface IFacturaRepository
    {
        Task<FacturaRequest> Add(FacturaRequest factura);

        Task<FacturaRequest> Update(FacturaRequest factura);

        Task<bool> Delete(int id);
    }
}