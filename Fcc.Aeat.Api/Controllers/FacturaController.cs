using Fcc.Aeat.Api.Models;
using Fcc.Aeat.Factura.Queries.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fcc.Aeat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IMediator _mediator; // Para transacciones
        private readonly IFacturaQueries _facturaQueries; // Solo para consultas

        public FacturaController(IMediator mediator, IFacturaQueries facturaQueries)
        {
            _facturaQueries = facturaQueries;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string nif)
        {
            try
            {
                var facturas = await _facturaQueries.GetAll(nif);
                return Ok(facturas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new ProblemDetails
                {
                    Status = 500,
                    Detail = ex.Message
                });
            }
        }

        //Get api/<FacturaController>

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FacturaRequestDto facturaRequestDto)
        {
            var facturaAddCommand = FacturaRequestDto.MapToFacturaAddCommand(facturaRequestDto);

            await _mediator.Send(facturaAddCommand);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var facturaDeleteCommand = FacturaRequestDto.MapToFacturaDeleteCommand(id);
            await _mediator.Send(facturaDeleteCommand);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] FacturaRequestDto facturaRequestDto, int id)
        {
            var facturaAddCommand = FacturaRequestDto.MapToFacturaUpdateCommand(facturaRequestDto, id);

            await _mediator.Send(facturaAddCommand);
            return Ok();
        }
    }
}