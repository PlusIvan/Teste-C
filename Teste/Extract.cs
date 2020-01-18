using System;

namespace Teste
{
    class Extract
    {
        public String get_Produto(string line)
        {
            return line.Split("*")[0];
        }
        public String get_PrecoFinal(string line)
        {
            return line.Substring(line.IndexOf("*") + 1, (line.IndexOf("#") - line.IndexOf("*")) - 1);
        }
        public String get_Quantidade(string line)
        {
            return line.Substring(line.IndexOf("#") + 1, (line.IndexOf("|") - line.IndexOf("#")) - 1);
        }
        public String get_Secao(string line)
        {
            return line.Substring(line.IndexOf("|") + 1, (line.IndexOf("&") - line.IndexOf("|")) - 1);
        }
        public String get_Mercado(string line)
        {
            return line.Split("&")[1];
        }
    }
}
