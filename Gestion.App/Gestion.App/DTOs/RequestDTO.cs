using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestion.App.DTOs
{
    public class RequestDTO
    {
        [JsonProperty("id_solicitud")]
        public int RequestID { get; set; }
        [JsonProperty("prioridad")]
        public string Prioridad { get; set; }
        [JsonProperty("id_equipo")]
        public int EquipoID { get; set; }
        [JsonProperty("id_tecnico")]
        public int TechnicianID { get; set; }
        [JsonProperty("tipo_solicitud")]
        public string Tipo { get; set; }
        [JsonProperty("descripcion_solicitud")]
        public string Descripcion { get; set; }
    }
}
