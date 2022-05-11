using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;


namespace RestApiconnect
{
    class ServiceRest
    {
        private const string urlLogin = "https://dceservice-qa-restapi.onbmc.com/api/jwt/login";
        private static readonly HttpClient client = new HttpClient();



        static async Task Main(string[] args)
        {
           

            string URL = "https://dceservice-qa-restapi.onbmc.com/api/arsys/v1/entry/WOI:WorkOrderInterface_Create/000000000002249";
            var result = await client.GetAsync(URL);
            Console.WriteLine(result.StatusCode);
        }
    }
}
