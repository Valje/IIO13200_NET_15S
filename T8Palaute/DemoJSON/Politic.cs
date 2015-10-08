using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DemoJSON
{
    class Politic : Person
    {
        public String Party { get; set; }
        
        // HUOM! Jos json-attribuutin ja propertyn nimet ovat eri, niin käytä seuraavaa
        [JsonProperty("position")] public String Virka { get; set; }

    }
}
