using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace encriptExcel
{
    internal class Program : ServiceExcel
    {
        public Program(string path, int Sheet) : base(path, Sheet)
        {
        }

        static void Main(string[] args)
        {

            if(args.Length > 0)
            {
                string pathExcel = args[0];
                string passwordExcel = args[1];
                Program init_program = new Program(pathExcel, 1);
                Console.WriteLine("Su archivo se guardo");
                init_program.ProtectWorkbook(passwordExcel);
                init_program.Close();
            }else
            {
                Console.WriteLine("Los argumentos no son validos");
            }

        }
    }
}
