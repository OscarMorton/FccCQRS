using Fcc.Aeat.Factura.Contracts.Commands;
using Fcc.Aeat.Factura.Contracts.Contracts;
using Fcc.Aeat.Factura.Contracts.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fcc.Aeat.Factura.Handlers
{
    public class FacturaUpdateCommandHandler : IRequestHandler<FacturaUpdateCommand, FacturaRequest>
    {
        private readonly IUpdateFacturaManager _iUpdateFacturaManager;

        public FacturaUpdateCommandHandler(IUpdateFacturaManager iAddFacturaManager)
        {
            _iUpdateFacturaManager = iAddFacturaManager;
        }

        public async Task<FacturaRequest> Handle(FacturaUpdateCommand request, CancellationToken cancellationToken)
        {
            var facturaRequest = new FacturaRequest
            {
                Id = request.Id,
                Base = request.Base,
                Fecha = request.Fecha,
                Iva = request.Iva,
                Nif = request.Nif,
                Pais = request.Pais,
                Importe = request.Importe
            };
            return await _iUpdateFacturaManager.UpdateFactura(facturaRequest);
        }
    }
}