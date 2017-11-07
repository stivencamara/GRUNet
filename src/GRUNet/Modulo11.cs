using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRUNet
{
    public sealed class Modulo11
    {
        public static int Calcula(string modulo)
        {
            int d = -1, s = 0, p = 2, b = 9;

            var sequencia = "";

            for (int i = 0; i < modulo.Length; i++)
            {
                sequencia += p;

                if (p < b)
                    p = p + 1;
                else
                    p = 2;
            }

            sequencia = Reverse(sequencia);

            var valor = 0;
            var peso = 0;

            for (int j = 0; j < modulo.Length; j++)
            {
                valor = Convert.ToInt32(modulo[j].ToString());
                peso = Convert.ToInt32(sequencia[j].ToString());

                s = s + (valor * peso);
            }

            var r = (s % 11);

            if (r == 0 ||r == 1)
                d = 0;
            else if (r == 10)
                d = 1;
            else
            {
                d = 11 - r;
            }

            return d;
        }

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
