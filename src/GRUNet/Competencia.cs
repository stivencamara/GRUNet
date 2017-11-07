namespace GRUNet
{
    public class Competencia
    {
        public Competencia(int mes, int ano)
        {
            Mes = mes;
            Ano = ano;
        }
        public int Mes { get; set; }
        public int Ano { get; set; }

        public override string ToString()
        {
            return string.Format("{0}/{1}", Mes, Ano);
        }
    }
}
