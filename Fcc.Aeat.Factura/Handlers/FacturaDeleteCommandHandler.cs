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
    public class FacturaDeleteCommandHandler : IRequestHandler<FacturaDeleteCommand>
    {
        private readonly IDeleteFacturaManager _iDeleteFacturaManager;

        public FacturaDeleteCommandHandler(IDeleteFacturaManager iDeleteFacturaManager)
        {
            _iDeleteFacturaManager = iDeleteFacturaManager;
        }

        public async Task<Unit> Handle(FacturaDeleteCommand request, CancellationToken cancellationToken)
        {
            // Instead  of returning a unit value, the correct way is returning the factura object

            return await _iDeleteFacturaManager.DeleteFactura(request.Id);
        }
    }
}