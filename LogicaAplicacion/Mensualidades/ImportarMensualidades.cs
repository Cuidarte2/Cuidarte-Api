using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepocitorio;
using LogicaNegocio.InterfacesServicios;
using LogicaNegocio.InterfacesServicios.Mensualidades;
using LogicaNegocio.ValueObject;
using LogicaNegocio.ValueObjects;

public class ImportarMensualidades : IImportarMensualidades
{
    private readonly ILectorExcel _lector;
    private readonly IRepositorioMensualidad _contextMensualidad;
    private readonly IRepositorioCliente _contextCliente;
    private static readonly string[] ColumnasEsperadas = { "Nombre", "Fecha", "Monto" };

    public ImportarMensualidades(ILectorExcel lector, IRepositorioMensualidad contextMensualidad, IRepositorioCliente contextCliente)
    {
        _lector = lector;
        _contextMensualidad = contextMensualidad;
        _contextCliente = contextCliente;
    }

    public async Task<ImportarExcelResult> Ejecutar(Stream fileStream)
    {
        var resultado = new ImportarExcelResult();
        var filas = _lector.Ejecutar(fileStream,ColumnasEsperadas);

        foreach (var fila in filas)
        {
            try
            {
                var mensualidad = MensualidadImportada.DesdeFila(fila);
                var cliente = _contextCliente.GetByTexto(mensualidad.Ci, null)
                              ?? _contextCliente.GetByTexto(mensualidad.NombreCompleto, null)
                              ?? _contextCliente.GetByTexto(mensualidad.Telefono, null);

                if (cliente == null)
                {
                    resultado.FilasConError++;
                    resultado.Errores.Add("Cliente no encontrado");
                    continue;
                }

                resultado.FilasProcesadas++;
            }
            catch (Exception ex)
            {
                resultado.FilasConError++;
                resultado.Errores.Add($"Fila con error: {ex.Message}");
            }
        }
        return resultado;
    }
}