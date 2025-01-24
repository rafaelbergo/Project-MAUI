using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MauiApp1.Models
{
    public class Task
    {
        [JsonProperty("id")]
        public required string Id { get; set; }

        [JsonProperty("pR_NAME")]
        public string? Name { get; set; }

        [JsonProperty("pR_DESCR")]
        public string? Description { get; set; }

        [JsonProperty("pR_ORDERID")]
        public int? OrderId { get; set; }

        [JsonProperty("pR_TASK_OWNER")]
        public string? TaskOwner { get; set; }

        [JsonProperty("pR_ASPECTOS_RELEVANTES")]
        public string? RelevantAspects { get; set; }

        [JsonProperty("pR_ATIVIDADE_CRITICA")]
        public string? CriticalActivity { get; set; }

        [JsonProperty("pR_COMO_FAZER")]
        public string? HowToDo { get; set; }

        [JsonProperty("pR_PONTO_CHAVE")]
        public string? KeyPoint { get; set; }

        [JsonProperty("pR_LOCAL_COORDINATES")]
        public string? LocalCoordinates { get; set; }

        [JsonProperty("pR_NUM_FOTOS")]
        public int? NumberOfPhotos { get; set; }
    }
}
