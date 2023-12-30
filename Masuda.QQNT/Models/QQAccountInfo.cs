using System.Text.Json.Serialization;

namespace Masuda.QQNT
{
    public class QQAccountInfo
    {
        [JsonPropertyName("uid")]
        public string Uid { get; set; }
        
        [JsonPropertyName("uin")]
        public string Uin { get; set; }
    }
}
