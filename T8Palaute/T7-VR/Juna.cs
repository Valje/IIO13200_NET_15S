using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace T7_VR
{
    public class Juna
    {
        [JsonProperty("trainNumber")]
        public string JunanNumero { get; set; }

        [JsonProperty("cancelled")]
        public string Peruutettu { get; set; }

        [JsonProperty("departureDate")]
        public string Pvm { get; set; }

    }
}
