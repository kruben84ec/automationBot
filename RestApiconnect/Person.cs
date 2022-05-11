using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiconnect
{
    class Person
    {
        public string Usuario { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"{Usuario}: {Password}";
        }
    }
}
