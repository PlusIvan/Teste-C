using System;
using System.IO;
using System.Text;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Signature: Ivan Moroz*/
            Operation oper = new Operation();
            Style styler = new Style();
            string[] mod = { "1","2","3","4","5","6","7","8" };
            string op = null;
            while (true)
            {
                styler.Menu_Render();
                op = Console.ReadLine();
                if (!Array.Exists(mod, x => x == op)) continue;
                    oper.execute(Int32.Parse(op));
                continue;
            }
        }
    }
}

