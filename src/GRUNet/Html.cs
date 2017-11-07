using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;

namespace GRUNet
{
    public class Html
    {
        public static string Monta(Guia boleto)
        {
            string base64Logo = Convert.ToBase64String(RecuperaLogo());
            string urlBrasao = string.Format("data:image/gif;base64,{0}", base64Logo);

            string base64Pontilhado = Convert.ToBase64String(RecuperaPontilhado());
            string urlPontilhado = string.Format("data:image/gif;base64,{0}", base64Pontilhado);

            var img = new C2of5i(boleto.CodigoBarras, 1, 50, boleto.CodigoBarras.Length).ToBitmap();

            string base64CodigoBarras = Convert.ToBase64String(ImagemToByte(img));
            string urlCodigoBarras = string.Format("data:image/jpeg;base64,{0}", base64CodigoBarras);

            var html = ObterModelo();

            var competencia = "";
            var vencimento = "";

            if (boleto.Vencimento >= DateTime.Now)
                competencia = boleto.Competencia.ToString();

            if (boleto.Competencia != null)
                competencia = boleto.Vencimento.ToString("dd/MM/yyyy");

            return html.Replace("*|BRASAO|*", urlBrasao)
            .Replace("*|PONTILHADO|*", urlPontilhado)
            .Replace("*|CODIGO_BARRAS|*", urlCodigoBarras)
            .Replace("*|NOSSO_NUMERO|*", boleto.NossoNumero)
            .Replace("*|COMPETENCIA|*", competencia)
            .Replace("*|VENCIMENTO|*", vencimento)
            .Replace("*|NOME_CONTRIBUINTE|*", boleto.Contribuinte.Nome)
            .Replace("*|CPF_CNPJ|*", Utils.FormataIdentificador(boleto.Contribuinte.Identificacao))
            .Replace("*|CODIGO_UNIDADE|*", boleto.Unidade.Codigo)
            .Replace("*|GESTAO|*", boleto.Unidade.Gestao)
            .Replace("*|VALOR_PRINCIPAL|*", boleto.Valor.ToString("##,##0.00"))
            .Replace("*|VALOR_TOTAL|*", boleto.ValorTotal.ToString("##,##0.00"))
            .Replace("*|GESTAO|*", boleto.Unidade.Gestao)
            .Replace("*|LINHA_DIGITAVEL|*", boleto.LinhaDigitavel)
            .Replace("*|CODIGO_RECOLHIMENTO|*", boleto.Unidade.CodigoRecolhimento)
            .Replace("*|NOME_UNIDADE|*", boleto.Unidade.Nome)
            .Replace("*|AVISO|*", boleto.Aviso)
            .Replace("*|INSTRUCOES|*", ObterInstrucoes(boleto.Instrucoes));
        }

        private static string ObterInstrucoes(IList<string> instrucoes)
        {
            var html = new StringBuilder();

            foreach (var instrucao in instrucoes)
                html.AppendFormat("<b><div ALIGN='CENTER'><font id='fontemaior'>{0}</font></div></b>", instrucao);

            return html.ToString();
        }

        public static string ObterModelo()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var file = new FileInfo(assembly.CodeBase.Replace("file:///", ""));

            if (file == null)
                throw new GRUException("Arquivo modelo.html não encontrado");

            using (var fileStream = File.OpenRead(string.Format("{0}\\modelo.html", file.Directory)))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    return streamReader.ReadToEnd();
                }
            }            
        }


        public static byte[] ImagemToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public static byte[] RecuperaLogo()
        {
            Stream streamLogo = null;
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                streamLogo = assembly.GetManifestResourceStream("GRUNet.Imagens.brasaopb.jpg");
                return new BinaryReader(streamLogo).ReadBytes((int)streamLogo.Length);
            }
            finally
            {
                if (streamLogo != null)
                {
                    streamLogo.Close();
                }
            }
        }

        public static byte[] RecuperaPontilhado()
        {
            Stream streamLogo = null;
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                streamLogo = assembly.GetManifestResourceStream("GRUNet.Imagens.tespontilhado.jpg");
                return new BinaryReader(streamLogo).ReadBytes((int)streamLogo.Length);
            }
            finally
            {
                if (streamLogo != null)
                {
                    streamLogo.Close();
                }
            }

        }
    }
}
