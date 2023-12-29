using System.Text.Json.Serialization;
using Masuda.QQNT.Models;

namespace Masuda.QQNT;
public class SendMessageComand {
    [JsonPropertyName("target")]
    public string Target { get; set; }
    // 内部需要是messagebase系列的
    [JsonPropertyName("content")]
    public MessageBase[] MessageChain { get; set; }
}

public class SendGroupMessageComand
{

}
