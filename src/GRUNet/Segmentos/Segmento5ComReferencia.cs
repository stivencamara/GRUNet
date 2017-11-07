using System;

namespace GRUNet.Segmentos
{
    public class Segmento5ComReferencia : Segmento
    {
        public Segmento5ComReferencia(TipoArrecadacao tipo, Unidade unidade, Contribuinte contribuinte, decimal valor) : base(tipo, Leiaute.Segmento5ComReferencia, unidade, contribuinte, valor)
        {
        }

        public override void Valida()
        {
            throw new NotImplementedException();
        }
    }
}
