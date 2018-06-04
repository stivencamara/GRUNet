using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GRUNet.Demo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cliente = new Unidade("HOSPITAL DAS FORÇAS ARMADAS", "03.568.867/0001-36", "00204", "112408", "00001", "28883-7", "0150114062");

            var enderecoContribuinte = new Endereco("SQN 416 K 106", "Asa Norte", "Brasília", "DF", "70879-110");

            var contribuinte = new Contribuinte(TipoContribuinte.CPF, "920.742.865-20", "Stiven Fabiano da Câmara", enderecoContribuinte);

            var guia = GRU.Simples(Leiaute.Segmento5, cliente, contribuinte, 120);

            guia.Aviso = "SR. CONTRIBUINTE: ESTA GUIA NÃO PODERÁ SER LIQUIDADA COM CHEQUE";
            guia.Instrucoes.Add("SR. CAIXA: NÃO RECEBER EM CHEQUE");

            guia.Processa();
            guia.Visualiza();
        }
    }
}