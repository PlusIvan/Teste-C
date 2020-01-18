using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Teste
{
    class Operation
    {
        private List<Action> rule = new List<Action>();
        private List<string> product_info = new List<string>();
        private List<string> colors = new List<string>();
        private string path = @"C:\ficheiros";
        private string core = "auchan.txt";
        static Extract extract = new Extract();
        private string header = "";
        static Style styler = new Style();
        public Operation()
        {
            StreamReader file = File.OpenText($@"{path}\{core}");
            string line = null;
            while ((line = file.ReadLine()) != null) product_info.Add(line);
            header = product_info.First();
            product_info.RemoveAt(0);
            rule.Add(operation_1);
            rule.Add(operation_2);
            rule.Add(operation_3);
            rule.Add(operation_4);
            rule.Add(operation_5);
            rule.Add(operation_6);
            rule.Add(operation_7);
            rule.Add(operation_8);
            file.Close();
            for(int x = 0; x < styler.set_colors.Length; x++)
                colors.Add(styler.set_colors[x]);

            string current_city = "";
            foreach (string info in product_info)
            {
                if (extract.get_Mercado(info.ToLower()) != current_city)
                {
                    if (colors.Count() == 0) return;
                    styler.Form_Color(extract.get_Mercado(info.ToLower()), colors.First());
                    colors.RemoveAt(0);
                    current_city = extract.get_Mercado(info.ToLower());
                }
                else
                {
                    continue;
                }
            }
        }

        public void execute(int dex)
        {
            rule[dex-1].Invoke(); // trigger function
        }
        
         
        static void simple_log(string info)
        {
            if (info == null)
            {
                Console.WriteLine($@"Nao existe esta lista");
                return;
            }
            Console.WriteLine($@"
------------------
Produto: {extract.get_Produto(info)}
Preco: {extract.get_PrecoFinal(info)}
Quantidade: {extract.get_Quantidade(info)}
Secao: {extract.get_Secao(info)}
");
            styler.Re_color(extract.get_Mercado(info));
            Console.WriteLine($"Mercado: { extract.get_Mercado(info)}");
            styler.def_color();
        }
             
        public void operation_1()
        {
            int executed = 0;
foreach (string info in product_info)
            {
                simple_log(info);
                executed++;
            }
            Console.ReadKey();

        }
        public void operation_2()
        {
            // Secçao Frutaria ordenado por quantidade ascendente
            int executed = 0;
            foreach (string info in product_info.Where(x => extract.get_Secao(x.ToLower()) == "frutaria").OrderBy(x => extract.get_Quantidade(x)))
            {
                simple_log(info);
                executed++;
            }
            if (executed == 0) simple_log(null);
            Console.ReadKey();
        } 
        
        public void operation_3()
        {
            //Media dos preços finais
            int median = 0;
            foreach (string info in product_info) median+=Convert.ToInt32(extract.get_PrecoFinal(info));
            Console.WriteLine($@"Median price of all produtcs: {(median/product_info.Count())}");
            Console.ReadKey();
        }
        public void operation_4()
        {
            //Apenas Aamadora secçao Peixaria
            int executed = 0;
            foreach (string info in product_info.Where(x=>extract.get_Mercado(x.ToLower()) == "amadora" && extract.get_Secao(x.ToLower()) == "peixaria"))
            {
                simple_log(info);
                executed++;
            }
            if (executed == 0) simple_log(null);
            Console.ReadKey();
        }
        public void operation_5()
        {
            // Apena Braga ordenado por ascendente em quantidade
            int executed = 0;
            foreach (string info in product_info.Where(x => extract.get_Mercado(x.ToLower()) == "braga").OrderBy(x => extract.get_Quantidade(x))) {
                simple_log(info);
                executed++;
            }
            if (executed == 0) simple_log(null);
            Console.ReadKey();
        }
        public void operation_6()
        {
            //Gerar Alfragide.txt contenha todos produtos da Alfragide
            //todo: fix utf8
            Console.WriteLine($"Indique um nome para o seu ficheiro para gerar produtos do Mercado Alfragide");
            string name = Console.ReadLine();
            FileInfo file  = new FileInfo($@"{path}\{name}.txt");
            StreamWriter write = file.CreateText();
            int executed = 0;
            write.WriteLine(header);
            foreach (string info in product_info.Where(x => extract.get_Mercado(x.ToLower()) == "alfragide"))
            {
                write.WriteLine(info, Encoding.GetEncoding(28591));
                executed++;
            }
            if (executed == 0)
                Console.WriteLine($"Ficheiro criado mas lista esta vazia");
            else
                Console.WriteLine($"Ficheiro criado com lista pre enchida");
            write.Close();
            Console.ReadKey();

        } 
        public void operation_7()
        {
            //Gerar Alfragide.txt contenha todos produtos da Alfragide
            //todo: fix utf8
            Console.WriteLine($"Indique um nome para o seu ficheiro para gerar produtos so de secao Frutaria");
            string name = Console.ReadLine();
            FileInfo file = new FileInfo($@"{path}\{name}.txt");
            StreamWriter write = file.CreateText();
            int executed = 0;
            write.WriteLine(header);

            foreach (string info in product_info.Where(x=>extract.get_Secao(x.ToLower()) == "frutaria"))
            {
                write.WriteLine(info, Encoding.GetEncoding(28591));
                executed++;
            }
            if (executed == 0)
                Console.WriteLine($"Ficheiro criado mas lista esta vazia");
            else
                Console.WriteLine($"Ficheiro criado com lista pre enchida");
            write.Close();
            Console.ReadKey();
        }
        public void operation_8()
        {
            // Sair
            Console.WriteLine($"Terminating Form, adeus");
            Environment.Exit(0);
        }
    }
}
