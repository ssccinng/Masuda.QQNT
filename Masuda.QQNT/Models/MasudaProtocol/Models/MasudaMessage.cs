using System.Text.Json;
using System.Text.Json.Serialization;
using Masuda.QQNT.Models.Message;

namespace Masuda.QQNT.Models.MasudaProtocol.Models;

public class MasudaMessage
{
    [JsonPropertyName("sender")]
    public Sender Sender { get; set; }

    [JsonPropertyName("peer")]
    public Peer Peer { get; set; }

    [JsonPropertyName("msgId")]
    public string Id { get; set; }
    [JsonPropertyName("msgSeq")]
    public string MsgSeq { get; set; }
    [JsonPropertyName("msgTime")]
    public string MsgTime { get; set; }

    [JsonPropertyName("content")]
    public MessageBase[] Content { get; set; } = Array.Empty<MessageBase>();
}


public class MasudaMessageUnit
{
    [JsonPropertyName("peer")]
    public Peer Peer { get; set; }
    [JsonPropertyName("sender")]
    public Sender Sender { get; set; }
    [JsonPropertyName("elements")]
    // [JsonConverter(typeof(MessageJsonConverter))]
    public MessageBase[] Elements { get; set; }
}