using System;

namespace GRUNet
{
    public class Contribuinte
    {
        public Contribuinte(TipoContribuinte tipo, string identificao, string nome, Endereco endereco)
        {
            Tipo = tipo;
            Identificacao = identificao;
            Nome = nome;
            Endereco = endereco;

            ValidaTipoContribuinte();
            ValidaEndereco();
        }

        public TipoContribuinte Tipo { get; set; }
        public string Identificacao { get; set; }
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }

        private void ValidaTipoContribuinte()
        {
            if (Tipo == TipoContribuinte.CPF)
            {
                if (!Validacao.ValidaCPF(Identificacao))
                    throw new GRUException("CPF inválido do contribuinte");
            }
            else
            {
                if (!Validacao.ValidaCNPJ(Identificacao))
                    throw new GRUException("CNPJ inválido do contribuinte");
            }
        }

        private void ValidaEndereco()
        {
            if (Endereco == null)
                throw new GRUException("O endereço não pode ser nulo");
        }
    }
}
