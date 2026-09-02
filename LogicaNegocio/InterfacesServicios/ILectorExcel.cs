namespace LogicaNegocio.InterfacesServicios;

public interface ILectorExcel
{
    List<Dictionary<string, object?>> Leer(Stream fileStream, string[] columnasEsperadas);
}