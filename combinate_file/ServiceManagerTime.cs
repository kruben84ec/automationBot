using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace combinate_file
{
    class ServiceManagerTime
    {

        public Dictionary<string, string> getTime()
        {
            Dictionary<string, string> executeTime = new Dictionary<string, string>();
            String hourMinute = DateTime.Now.ToString("HH:mm");
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            String anio = DateTime.Now.ToString("yyyy");
            String mes = DateTime.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("es-ES"));

            executeTime.Add("hour", hourMinute);
            executeTime.Add("fecha", fecha);
            executeTime.Add("anio", anio);
            executeTime.Add("mes", mes);

            return executeTime;
        }

    }
}
