using System.Text.Json.Serialization;

namespace Masuda.QQNT.Models.Message;

public class PlainMessage : MessageBase
{
    public PlainMessage()
    {
        Type = "text";
    }
    public PlainMessage(string content)
    {
        Type = "text";
        Content = content;
    }

    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;

}
