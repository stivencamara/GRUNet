using GRUNet.Segmentos;

namespace GRUNet
{
    public class FabricaSegmento
    {
        public static ISegmento Segmento(TipoArrecadacao tipo, Leiaute leiaute, Unidade unidade, Contribuinte contribuinte, decimal valor)
        {
            if (leiaute == Leiaute.Segmento5)
                return new Segmento5(tipo, unidade, contribuinte, valor);
            else if (leiaute == Leiaute.Segmento5ComReferencia)
                return new Segmento5ComReferencia(tipo, unidade, contribuinte, valor);
            else if (leiaute == Leiaute.Segmento9)
                return new Segmento9(tipo, unidade, contribuinte, valor);
            else
                throw new GRUException("Segmento não implementado");
        }
    }
}
