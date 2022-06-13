using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestion.App.DTOs
{
    public class ComputersDTO
    {
        [JsonProperty("id_equipo")]
        public int ComputerID { get; set; }

        [JsonProperty("marca_equipo")]
        public string Brand { get; set; }

        [JsonProperty("modelo_equipo")]
        public string  Model{ get; set; }

        [JsonProperty("tipo_equipo")]
        public string Type { get; set; }

    }
}
