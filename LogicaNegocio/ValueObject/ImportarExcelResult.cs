namespace LogicaNegocio.ValueObject;

public class ImportarExcelResult
{
    public int FilasProcesadas { get; set; }
    public int FilasConError { get; set; }
    public List<string> Errores { get; set; }

    public ImportarExcelResult(int filasProcesadas, int filasConError)
    {
        FilasProcesadas = filasProcesadas;
        FilasConError = filasConError;
        Errores = new List<string>();
    }
    
    public ImportarExcelResult()
    {
        FilasProcesadas = 0;
        FilasConError = 0;
        Errores = new List<string>();
    }
}