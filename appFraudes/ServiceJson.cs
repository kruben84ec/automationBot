using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace appFraudes
{
    public class CredentialModel
    {
        public string userName { get; set; }
        public string password { get; set; }
    }
    public class ServiceJson
    {

        public CredentialModel readJsonCredentials(String pathJson)
        {
            StreamReader fileJson = new StreamReader(pathJson);
            string jsonString = fileJson.ReadToEnd();
            CredentialModel configAcces = JsonConvert.DeserializeObject<CredentialModel>(jsonString);
            return configAcces;
        }

      
    }


}
