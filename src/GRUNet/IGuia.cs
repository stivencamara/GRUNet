using GRUNet.Segmentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRUNet
{
    public interface IGuia
    {
        TipoArrecadacao Tipo { get; set; }
        Leiaute Leiaute { get; set; }
        ISegmento Segmento { get; set; }
        Unidade Unidade { get; set; }
        Contribuinte Contribuinte { get; set; }
        decimal Valor { get; set; }
        decimal ValorTotal { get; set; }
        IList<string> Instrucoes { get; set; }
        string NossoNumero { get; set; }
        Competencia Competencia { get; set; }
        DateTime Vencimento { get; set; }
        string LinhaDigitavel { get; set; }
        string Aviso { get; set; }
        string CodigoBarras { get; }
        void Processa();
        void Visualiza();
    }
}
