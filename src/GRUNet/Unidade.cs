namespace GRUNet
{
    public class Unidade
    {
        public Unidade(string nome, string identificador, string codigoSIAFI, string codigo, string gestao, string codigoRecolhimento, string fonte)
        {
            Nome = nome;
            Identificador = identificador;
            Codigo = codigo;
            Gestao = gestao;
            CodigoRecolhimento = codigoRecolhimento;
            CodigoSIAFI = codigoSIAFI;
            Fonte = fonte;
        }
        public string Identificador { get; set; }
        public string Nome { get; set; }
        /// <summary>
        /// Código de identificação da Unidade Gestora
        /// </summary>
        public string Codigo { get; set; }
        public string Gestao { get; set; }
        /// <summary>
        /// Código identificador da UG/Gestão responsável pela arrecadação, obtido por meio da transação >CONCODBBGR do SIAFI Operacional
        /// </summary>
        public string CodigoSIAFI { get; set; }

        /// <summary>
        /// Código do Recolhimento
        /// </summary>
        public string CodigoRecolhimento { get; set; }
        public string Fonte { get; set; }
    }
}

