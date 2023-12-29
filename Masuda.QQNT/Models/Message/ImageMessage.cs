using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Masuda.QQNT.Models.Message
{
    public class ImageMessage: MessageBase
    {
        public ImageMessage()
        {
            Type = "image";
        }
        [JsonPropertyName("file")]
        public required string File { get; set; } = string.Empty;
    }
}
