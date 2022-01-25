using Fcc.Aeat.Factura.Contracts.Contracts;
using Fcc.Aeat.Factura.Contracts.Models;
using Fcc.Aeat.Factura.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcc.Aeat.Factura.Managers
{
    public class DeleteFacturaManager : IDeleteFacturaManager
    {
        private readonly IFacturaRepository _facturaRepository;

        // Constructor
        public DeleteFacturaManager(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        public Task DeleteFactura(int id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return _facturaRepository.Delete(id);
        }
    }
}