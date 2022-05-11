using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upLoadFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                String pathDirectory = @args[0];
                createFile _createFile = new createFile();

                _createFile.createDirectoryPath(pathDirectory);
            }
            else
            {
                Console.WriteLine("Los argumentos no son validos");
            }
        }
    }
}
