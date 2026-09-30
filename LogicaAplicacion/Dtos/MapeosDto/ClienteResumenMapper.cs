using LogicaAplicacion.Dtos.Clientes;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Dtos.MapeosDto
{
    public static class ClienteResumenMapper
    {
        public static ClienteResumenDto? ToDto(Cliente? cliente)
        {
            if (cliente is null) return null;

            return new ClienteResumenDto(
                cliente.Id,
                cliente.NombreCompleto.Nombre,
                cliente.NombreCompleto.Apellido,
                cliente.CI,
                cliente.Telefono.Value
            );
        }

        public static List<ClienteResumenDto> ToListaDto(IEnumerable<Cliente>? clientes)
        {
            return clientes?.Select(ToDto).Where(dto => dto is not null).Select(dto => dto!).ToList()
                   ?? new List<ClienteResumenDto>();
        }
    }
}
