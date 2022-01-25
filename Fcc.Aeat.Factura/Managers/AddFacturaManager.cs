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
    public class AddFacturaManager : IAddFacturaManager
    {
        private readonly IFacturaRepository _facturaRepository;

        public AddFacturaManager(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        public Task AddFactura(FacturaRequest facturaRequest)
        {
            if (facturaRequest == null)
                throw new ArgumentNullException(nameof(facturaRequest));

            return _facturaRepository.Add(facturaRequest);
        }
    }
}