namespace LogicaNegocio.InterfacesServicios;

public interface ILectorExcel
{
    List<Dictionary<string, object?>> Ejecutar(Stream fileStream,string[]columnasesperadas);
}