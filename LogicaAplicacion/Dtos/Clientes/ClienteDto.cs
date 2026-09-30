using LogicaAplicacion.Dtos.Suscripciones;
using LogicaAplicacion.Dtos.TipoPlanes;
namespace LogicaAplicacion.Dtos.Clientes
{
<<<<<<< Updated upstream
	public record ClienteDto (int id,DateTime fecha,string nombre, string apellido,string ci,string Email, DateTime fechaNacimiento, string direccion, string telefono,string celular, string? responsablePago,int? responsablePagoId,ClienteDto? clienteResponsable,string formaPago, string observaciones, int TipoPlanId,SuscripcionDto? suscripcion,IEnumerable<ServicioDto>? serviciosDisponibles)
=======
	public record ClienteDto (int id,DateTime fecha,string nombre, string apellido,string ci,string Email, DateTime fechaNacimiento, string direccion, string telefono,string celular, int? responsablePago, ClienteResumenDto? ResponsablePagoCliente,List<ClienteResumenDto> ClientesACargo, string formaPago, string observaciones, int TipoPlanId,SuscripcionDto? suscripcion,IEnumerable<ServicioDto>? serviciosDisponibles)
>>>>>>> Stashed changes
	{
	}
}
