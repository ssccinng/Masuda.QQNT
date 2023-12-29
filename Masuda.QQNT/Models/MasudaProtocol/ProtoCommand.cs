using System.Text.Json.Serialization;

namespace Masuda.QQNT;

public class ProtoCommand
{
    [JsonIgnore]
    public CommandType CommandType { get; set; }
    
    [JsonPropertyName("t")]
    public string Type => CommandType.ToString();

    [JsonPropertyName("d")]
    public object Data { get; set; }
}

public enum CommandType 
{
    /// <summary>
    /// 发送好友消息
    /// </summary>
    SendFriendMessage,
    /// <summary>
    /// 发送群消息
    /// </summary>
    SendGroupMessage,
    /// <summary>
    /// 发送临时消息
    /// </summary>
    SendTempMessage,

    ReplyFriendMessage,
    ReplyGroupMessage,
    ReplyTempMessage,

    GetUserInfo,
    GetGroupList,
}
