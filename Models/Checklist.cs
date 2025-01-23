using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MauiApp1.Models
{
    public class Checklist
    {
        [JsonProperty("id")]
        public required string Id { get; set; }

        [JsonProperty("pR_NAME")]
        public string? Name { get; set; }

        [JsonProperty("pR_DESCR")]
        public string? Description { get; set; }

        [JsonProperty("pR_WEIGHT")]
        public double? Weight { get; set; }
    }
}