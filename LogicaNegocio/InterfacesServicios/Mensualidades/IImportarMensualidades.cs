
using LogicaNegocio.ValueObject;

namespace LogicaNegocio.InterfacesServicios.Mensualidades;

public interface IImportarMensualidades
{
    Task<ImportarExcelResult> Ejecutar(Stream fileStream);
}