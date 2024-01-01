using System.Text.Json;
using System.Text.Json.Serialization;

namespace Masuda.QQNT.Models.MasudaProtocol;

public class ProtoEvent
{
    [JsonIgnore]
    public EventType EventType { get; set; }
    [JsonPropertyName("t")]
    public string Type { get => EventType.ToString(); set => EventType = (EventType)Enum.Parse(typeof(EventType), value); }
    [JsonPropertyName("d")]
    // [JsonConverter(typeof(JsonStringEnumConverter))]
    // [JsonConverter(typeof(ProtoDataJsonConverter))]
    public JsonElement Data { get; set; }
}

public class ProtoData
{

}

public enum EventType
{
    Message,
    FriendMessage,
    GroupMessage,
    TempMessage,
    GetUserInfo,
    GetGroupList,
    GetFriendsList,
    GetAccountInfo,
    GetPeer,
}
