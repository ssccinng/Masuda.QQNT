using System.Text.Json;
using System.Text.Json.Serialization;
using Masuda.QQNT.Models;

namespace Masuda.QQNT;

public class MasudaMessage
{
    [JsonPropertyName("sender")]
    public Sender Sender { get; set; }
    [JsonPropertyName("content")]
    public MasudaMessageUnit[] Content { get; set; }
}


public class MasudaMessageUnit {
    [JsonPropertyName("peer")]
    public Peer Peer { get; set; }
    [JsonPropertyName("sender")]
    public Sender Sender { get; set; }
    [JsonPropertyName("elements")]
    // [JsonConverter(typeof(MessageJsonConverter))]
    public MessageBase[] Elements { get; set; }
}