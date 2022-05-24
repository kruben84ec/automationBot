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
                string pathDesteny = args[0];
                ServiceDirectory createDirectory = new ServiceDirectory();
       
                createDirectory.createDirectoryLog(pathDesteny);
            }
            else
            {
                Console.WriteLine("Los argumentos no son validos");
            }
        }
    }
}
