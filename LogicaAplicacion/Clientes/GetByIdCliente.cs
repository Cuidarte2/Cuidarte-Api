using LogicaAplicacion.Dtos.Clientes;
using LogicaAplicacion.Dtos.MapeosDto;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepocitorio;
using LogicaNegocio.InterfazServicios;

namespace LogicaAplicacion.Clientes
{
	public class GetByIdCliente : IObtener<ClienteDto>
	{
		private readonly IRepositorioCliente _context;
		public GetByIdCliente(IRepositorioCliente repositorioCliente)
		{
			_context = repositorioCliente;
		}

		public ClienteDto Ejecutar(int id)
		{
			ClienteDto cDto = ClienteMapper.ToDto(_context.GetById(id));
			if (cDto.responsablePagoId != null && cDto.responsablePagoId != -1)
			{
				ClienteDto responsable =
					ClienteMapper.ToDto(_context.GetById(cDto.responsablePagoId.Value));

				cDto = cDto with
				{
					clienteResponsable = responsable
				};
			}
			return cDto;
		}

	}
}
