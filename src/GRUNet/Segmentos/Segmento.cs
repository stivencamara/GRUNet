using System;

namespace GRUNet.Segmentos
{
    public abstract class Segmento : ISegmento
    {
        public Segmento(TipoArrecadacao tipo, Leiaute leiaute, Unidade unidade, Contribuinte contribuinte, decimal valor)
        {
            Tipo = tipo;
            Leiaute = Leiaute;
            Unidade = unidade;
            Contribuinte = contribuinte;
            Valor = valor;
        }
        public Leiaute Leiaute { get; set; }
        public TipoArrecadacao Tipo { get; set; }
        public Contribuinte Contribuinte { get; set; }
        public Unidade Unidade { get; set; }
        public string CodigoBarras { get; set; }
        public decimal Valor { get; set; }
        public abstract void Valida();
    }
}
