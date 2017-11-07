namespace GRUNet.Segmentos
{
    public interface ISegmento
    {
        Leiaute Leiaute { get; set; }
        TipoArrecadacao Tipo { get; set; }
        Contribuinte Contribuinte { get; set; }
        string CodigoBarras { get; set; }
        decimal Valor { get; set; }
        void Valida();
    }
}
