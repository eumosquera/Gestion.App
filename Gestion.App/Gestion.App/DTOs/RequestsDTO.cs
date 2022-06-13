using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestion.App.DTOs
{
    public class RequestsDTO
    {
        [JsonProperty("id_solicitud")]
        public int RequestID { get; set; }

        [JsonProperty("prioridad")]
        public string Priority { get; set; }

        [JsonProperty("id_equipo")]
        public int ComputerID { get; set; }

        [JsonProperty("id_tecnico")]
        public int TechnicianID { get; set; }

        [JsonProperty("tipo_solicitud")]
        public string Type { get; set; }

        [JsonProperty("descripcion_solicitud")]
        public string Description { get; set; }
    }
}
