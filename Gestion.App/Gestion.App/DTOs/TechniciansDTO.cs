using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Gestion.App.DTOs
{
    public class TechniciansDTO
    {
        [JsonProperty("id_tecnico")]
        public int TechnicianID { get; set; }
        [JsonProperty("nombre_tecnico")]
        public string FirtsName { get; set; }
        [JsonProperty("apellidos_tecnico")]
        public string LastName { get; set; }
        [JsonProperty("email_tecnico")]
        public string Email { get; set; }
        [JsonProperty("nivel_tecnico")]
        public string Level { get; set; }
    }
}
