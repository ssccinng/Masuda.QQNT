using System.Text.Json.Serialization;
using Masuda.QQNT.Models;

namespace Masuda.QQNT;

public class PlainMessage: MessageBase
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
