using Fcc.Aeat.Factura.Contracts.Commands;
using Fcc.Aeat.Factura.Contracts.Models;
using System;
using System.Globalization;

namespace Fcc.Aeat.Api.Models
{
    public class FacturaRequestDto
    {
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string Nif { get; set; }
        public string Pais { get; set; }

        public string Fecha { get; set; }

        public byte Iva { get; set; }

        public decimal Importe { get; set; }

        public decimal Base { get; set; }

        public FacturaRequestDto(string nif)
        {
            Nif = nif;
        }

        public static FacturaRequest MapToFacturaRequest(FacturaRequestDto facturaRequestDto)
        {
            if (facturaRequestDto == null)
                throw new ArgumentNullException(nameof(facturaRequestDto));

            return new FacturaRequest
            {
                FechaFin = DateTime.ParseExact(facturaRequestDto.FechaFin, "dd-MM-yy",
                CultureInfo.InvariantCulture),

                FechaInicio = DateTime.ParseExact(facturaRequestDto.FechaInicio, "dd-MM-yy",
                CultureInfo.InvariantCulture),
                Nif = facturaRequestDto.Nif
            };
        }

        public static FacturaAddCommand MapToFacturaAddCommand(FacturaRequestDto facturaRequestDto)
        {
            if (facturaRequestDto == null)
                throw new ArgumentNullException(nameof(facturaRequestDto));

            return new FacturaAddCommand
            {
                Pais = facturaRequestDto.Pais,
                Nif = facturaRequestDto.Nif,
                Importe = facturaRequestDto.Importe,
                Fecha = DateTime.ParseExact(facturaRequestDto.Fecha, "dd-MM-yy",
                CultureInfo.InvariantCulture),
                Base = facturaRequestDto.Base,
                Iva = facturaRequestDto.Iva
            };
        }

        public static FacturaUpdateCommand MapToFacturaUpdateCommand(FacturaRequestDto facturaRequestDto, int id)
        {
            if (facturaRequestDto == null)
                throw new ArgumentNullException(nameof(facturaRequestDto));

            return new FacturaUpdateCommand
            {
                // This factura command has the id of the object to update
                Id = id,
                Pais = facturaRequestDto.Pais,
                Nif = facturaRequestDto.Nif,
                Importe = facturaRequestDto.Importe,
                Fecha = DateTime.ParseExact(facturaRequestDto.Fecha, "dd-MM-yy",
                CultureInfo.InvariantCulture),
                Base = facturaRequestDto.Base,
                Iva = facturaRequestDto.Iva
            };
        }

        public static FacturaDeleteCommand MapToFacturaDeleteCommand(int id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return new FacturaDeleteCommand
            {
                Id = id
            };
        }
    }
}