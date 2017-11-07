using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRUNet
{
    public class FabricaGuia
    {
        public static IGuia GRUSimples(Leiaute leiaute, Unidade unidade, Contribuinte contribuinte, decimal valor)
        {
            return new Guia(TipoArrecadacao.Simples, leiaute, unidade, contribuinte, valor);
        }
    }
}
