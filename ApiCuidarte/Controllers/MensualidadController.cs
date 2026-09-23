using Infraestructura.LogicaAccesoDatos.Excepciones;
using LogicaAplicacion.Dtos.Suscripciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones;
using LogicaNegocio.Excepciones.Mensualidad;
using LogicaNegocio.InterfacesServicios;
using LogicaNegocio.InterfacesServicios.Mensualidades;
using LogicaNegocio.InterfazServicios;
using LogicaNegocio.ValueObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCuidarte.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class MensualidadController : ControllerBase
	{
		IObtenerPorCliente<MensualidadDto> _getAll;
		IPagarMensualidades<SuscripcionDto> _pagarMensualidades;
		private IImportarMensualidades _importarMensualidades;
		public MensualidadController
			(
			IObtenerPorCliente<MensualidadDto> getAll,
			IPagarMensualidades<SuscripcionDto> pagarMensualidades,
			IImportarMensualidades importarMensualidades
			)
		{
			this._getAll = getAll;

			this._pagarMensualidades = pagarMensualidades;
			
			this._importarMensualidades= importarMensualidades;
		}

		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[HttpPost]
		[Route("Pagar")]
		public IActionResult Pagar([FromQuery]int idSuscripcion, [FromQuery] int? idCliente)
		{
			try
			{
				Mensualidad mCreado = _pagarMensualidades.Ejecutar(idSuscripcion, idCliente);
				return Ok(mCreado);
			}
			catch (DomainException ex)
			{
				return BadRequest(new { message = ex.Message });
			}
			catch (UnauthorizedAccessException)
			{
				return Unauthorized(new { message = "No autorizado" });
			}
			catch (NotFoundException ex)
			{
				return NotFound(new { message = ex.Message });
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
					new { message = "Hupps hubo un error, intente nuevamente más tarde" });
			}
		}

		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[HttpPost]
		[Route("PagarEmpresa")]
		public IActionResult PagarEmpresa([FromQuery] int idSuscripcion)
		{
			try
			{
				Mensualidad mCreado = _pagarMensualidades.Ejecutar(idSuscripcion, null);
				return Ok(mCreado);
			}
			catch (DomainException ex)
			{
				return BadRequest(new { message = ex.Message });
			}
			catch (UnauthorizedAccessException)
			{
				return Unauthorized(new { message = "No autorizado" });
			}
			catch (NotFoundException ex)
			{
				return NotFound(new { message = ex.Message });
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
					new { message = "Hupps hubo un error, intente nuevamente más tarde" });
			}
		}

		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[HttpGet]
		[Route("ObtenerTodos")]
		public IActionResult GetAll(int idSuscripcion,int idCliente)
		{
			try
			{
			    IEnumerable<MensualidadDto> m = _getAll.Ejecutar(idSuscripcion, idCliente);
				return Ok(m);
			}
			catch (DomainException ex)
			{
				return BadRequest(new { message = ex.Message });
			}
			catch (UnauthorizedAccessException)
			{
				return Unauthorized(new { message = "No autorizado" });
			}
			catch (NotFoundException ex)
			{
				return NotFound(new { message = ex.Message });
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
					new { message = "Hupps hubo un error, intente nuevamente más tarde" });
			}
		}
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[HttpPost]
		[Route("PagarExcel")]
		public IActionResult PagarExcel([FromQuery]Stream file)
		{
			try
			{
				Task<ImportarExcelResult> mensualidadesPagas = _importarMensualidades.Ejecutar(file);
				return Ok(mensualidadesPagas);
			}
			catch (MensualidadException ex)
			{
				return BadRequest(new { message = ex.Message });
			}
			catch (DomainException ex)
			{
				return BadRequest(new { message = ex.Message });
			}
			catch (UnauthorizedAccessException)
			{
				return Unauthorized(new { message = "No autorizado" });
			}
			catch (NotFoundException ex)
			{
				return NotFound(new { message = ex.Message });
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
					new { message = "Hupps hubo un error, intente nuevamente más tarde" });
			}
		}
	}
}
