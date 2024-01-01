using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Masuda.QQNT.Models.Message
{
    public class MessageBase
    {
        [JsonPropertyName("type")]
        public string Type { get; protected set; } = "raw";

    }
}
