using System;
using System.Collections.Generic;

namespace Teste
{
    class Style
    {
        private Dictionary<string, string> color_fun = new Dictionary<string, string>();
        public string[] set_colors = { "Red", "Green", "Yellow", "Blue", "Magenta", "Cyan", "DarkYellow", "DarkBlue", "DarkCyan", "DarkMagenta", "DarkGreen", "DarkGray", "White", "Gray" };
        public void Form_Color(string city, string color)
        {
            if (color_fun.ContainsKey(city)) return;
            color_fun.Add(city, color);
        }

        public void Menu_Render()
        {
Console.Clear();
Console.WriteLine($@"
1 - Conteudo do ficheiro inteiro
2 - Secçao Frutaria ordenado por quantidade ascendente
3 - Media dos preços finais
4 - Apenas Aamadora secçao Peixaria
5 - Apena Braga ordenado por ascendente em quantidade
6 - Gerar Alfragide.txt contenha todos produtos da Alfragide
7 - Gerar Frutaria.txt todos produtos da secçao Frutaria
8 - Sair
");
        }

        public void Re_color(string city)
        {
            if (city == null || color_fun.ContainsKey(city.ToLower()) == false) return;
            string to_color = color_fun[city.ToLower()];
            if (to_color == "Red")
                Console.ForegroundColor = ConsoleColor.Red;
            if (to_color == "Green")
                Console.ForegroundColor = ConsoleColor.Green;
            if (to_color == "Yellow")
                Console.ForegroundColor = ConsoleColor.Yellow;
            if (to_color == "Blue")
                Console.ForegroundColor = ConsoleColor.Blue;
            if (to_color == "Magenta")
                Console.ForegroundColor = ConsoleColor.Magenta;
            if (to_color == "Cyan")
                Console.ForegroundColor = ConsoleColor.Cyan;
            if (to_color == "DarkYellow")
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (to_color == "DarkGray")
                Console.ForegroundColor = ConsoleColor.DarkGray;
            if (to_color == "DarkBlue")
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            if (to_color == "DarkCyan")
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            if (to_color == "DarkMagenta")
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            if (to_color == "DarkGreen")
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (to_color == "White")
                Console.ForegroundColor = ConsoleColor.White;
            if (to_color == "Gray")
                Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void def_color()
        {
            Console.ResetColor();
        }

    }
}
