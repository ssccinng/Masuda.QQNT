using System.Text.Json;
using System.Text.Json.Serialization;
using Masuda.QQNT.Models;

namespace Masuda.QQNT;

public class MasudaMessage
{
    [JsonPropertyName("sender")]
    public Sender Sender { get; set; }

    [JsonPropertyName("peer")]
    public Peer Peer { get; set; }

    [JsonPropertyName("msgId")]
    public string Id { get; protected set; }
    [JsonPropertyName("msgSeq")]
    public string MsgSeq { get; protected set; }

    [JsonPropertyName("content")]
    public MessageBase[] Content { get; set; }
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