using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace merge_file
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                String pathConfig = args[0];
                String pathLocal = args[1];


                ServiceDirectory directory = new ServiceDirectory();
                directory.mergeExecute(pathConfig, pathLocal);
            }
        }
    }
}
