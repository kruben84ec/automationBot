using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace createDirectory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine("Argumentos");
            }
            else
            {
                Console.WriteLine("Los argumentos no son validos");
            }
        }
    }
}
