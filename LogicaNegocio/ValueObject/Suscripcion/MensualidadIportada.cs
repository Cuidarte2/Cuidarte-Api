namespace LogicaNegocio.ValueObjects;

public class MensualidadImportada
{
    public string? Ci { get; }
    public string? NombreCompleto { get; }
    public string? Telefono { get; }
    public DateTime Fecha { get; }
    public decimal Monto { get; }

    private MensualidadImportada(string? ci, string? nombreCompleto, string? telefono, DateTime fecha, decimal monto)
    {
        Ci = ci;
        NombreCompleto = nombreCompleto;
        Telefono = telefono;
        Fecha = fecha;
        Monto = monto;
    }

    public static MensualidadImportada DesdeFila(Dictionary<string, object?> fila)
    {
        var ci = fila.GetValueOrDefault("CI")?.ToString()?.Trim();
        var nombre = fila.GetValueOrDefault("Nombre")?.ToString()?.Trim();
        var telefono = fila.GetValueOrDefault("Telefono")?.ToString()?.Trim();

        // al menos un identificador tiene que venir para poder buscar al cliente
        if (string.IsNullOrWhiteSpace(ci) && string.IsNullOrWhiteSpace(nombre) && string.IsNullOrWhiteSpace(telefono))
            throw new ArgumentException("La fila no tiene CI, Nombre ni Teléfono para identificar al cliente");

        if (fila.GetValueOrDefault("Fecha") is not DateTime fecha)
            throw new ArgumentException("Fecha inválida");

        if (fila.GetValueOrDefault("Monto") is not double montoRaw)
            throw new ArgumentException("Monto inválido");

        var monto = (decimal)montoRaw;
        if (monto <= 0)
            throw new ArgumentException("El monto debe ser mayor a cero");

        return new MensualidadImportada(
            string.IsNullOrWhiteSpace(ci) ? null : ci,
            string.IsNullOrWhiteSpace(nombre) ? null : nombre,
            string.IsNullOrWhiteSpace(telefono) ? null : telefono,
            fecha,
            monto);
    }
}