using System.Collections.Generic;
using Newtonsoft.Json;

namespace AutoPractice12.Services.Models
{
    public class Response<T>
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
