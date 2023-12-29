using System.Text.Json.Serialization;
using Masuda.QQNT.Models;

namespace Masuda.QQNT;

public class PlainMessage: MessageBase
{
    public PlainMessage()
    {
        Type = "text";
    }

    [JsonPropertyName("content")]
    public required string Content { get; set; } = string.Empty;

}
