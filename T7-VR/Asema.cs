using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T7_VR
{
    public class Asema
    {
        [JsonProperty("stationName")]
        public string AsemanNimi { get; set; }

        [JsonProperty("stationShortCode")]
        public string AsemanKoodi { get; set; }
    }
}
