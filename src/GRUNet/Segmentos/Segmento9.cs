using System;

namespace GRUNet.Segmentos
{
    public class Segmento9 : Segmento
    {
        public Segmento9(TipoArrecadacao tipo, Unidade unidade, Contribuinte contribuinte, decimal valor) : base(tipo, Leiaute.Segmento9, unidade, contribuinte, valor)
        {
        }
        public override void Valida()
        {
            throw new NotImplementedException();
        }
    }
}
