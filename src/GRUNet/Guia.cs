using GRUNet.Segmentos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;

namespace GRUNet
{
    public class Guia : IGuia
    {
        public Guia(TipoArrecadacao tipo, Leiaute leiaute, Unidade unidade, Contribuinte contribuinte, decimal valor)
        {
            Instrucoes = new List<string>();

            Tipo = tipo;
            Leiaute = leiaute;
            Unidade = unidade;
            Contribuinte = contribuinte;
            Valor = valor;
        }

        public Guia(TipoArrecadacao tipo, Leiaute leiaute, Unidade unidade, Contribuinte contribuinte, string nossoNumero, Competencia competencia, DateTime vencimento, decimal valor)
        {
            Instrucoes = new List<string>();

            Tipo = tipo;
            Leiaute = leiaute;
            Unidade = unidade;
            Contribuinte = contribuinte;
            NossoNumero = nossoNumero;
            Competencia = competencia;
            Vencimento = vencimento;
            Valor = valor;
        }

        public TipoArrecadacao Tipo { get; set; }
        public Leiaute Leiaute { get; set; }
        public ISegmento Segmento { get; set; }
        public Unidade Unidade { get; set; }
        public Contribuinte Contribuinte { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorTotal { get; set; }
        public IList<string> Instrucoes { get; set; }

        /// <summary>
        /// Nosso Número/Número de Referência
        /// </summary>
        public string NossoNumero { get; set; }
        public Competencia Competencia { get; set; }
        public DateTime Vencimento { get; set; }
        public string LinhaDigitavel { get; set; }
        public string Aviso { get; set; }
        public string CodigoBarras
        {
            get
            {
                return Segmento.CodigoBarras;
            }
        }

        public void Processa()
        {
            ValidaUnidade();
            ValidaContribuinte();
            ValidaBoleto();
            ValidaCodigoBarras();
            FormataCodigoBarras();
        }

        private void ValidaBoleto()
        {
            if (Tipo == TipoArrecadacao.Simples && Leiaute == Leiaute.Segmento5)
            {
                ValorTotal = Valor;
            }
            else // Outros segmentos
            {
                if (Vencimento == DateTime.MinValue || Vencimento < DateTime.Now.Date)
                    throw new GRUException("O vencimento é inválido");
            }
        }

        private void ValidaCodigoBarras()
        {
            ValidaSegmento();
        }

        public void Visualiza()
        {
            var context = HttpContext.Current;

            var html = Html.Monta(this);

            context.Response.Clear();
            context.Response.ClearContent();
            context.Response.Write(html);
            context.Response.Flush();
        }

        private void FormataCodigoBarras()
        {
            var grupo1 = CodigoBarras.Substring(0, 11);
            var grupo2 = CodigoBarras.Substring(11, 11);
            var grupo3 = CodigoBarras.Substring(22, 11);
            var grupo4 = CodigoBarras.Substring(33, 11);
            
            var dv1 = Modulo11.Calcula(grupo1);
            var dv2 = Modulo11.Calcula(grupo2);
            var dv3 = Modulo11.Calcula(grupo3);
            var dv4 = Modulo11.Calcula(grupo4);

            LinhaDigitavel = string.Format("{0}-{1} {2}-{3} {4}-{5} {6}-{7}", 
                grupo1, dv1, 
                grupo2, dv2,
                grupo3, dv3,
                grupo4, dv4);
        }

        private void ValidaSegmento()
        {
            Segmento = SegmentoFabrica.Segmento(Tipo, Leiaute, Unidade, Contribuinte, Valor);
            Segmento.Valida();
        }

        private void ValidaUnidade()
        {
            if (Unidade == null)
                throw new GRUException("Unidade Gestora não pode ser nulo");
        }

        private void ValidaContribuinte()
        {
            if (Contribuinte == null)
                throw new GRUException("Contribuinte não pode ser nulo");

        }
    }
}
