using System.Text.Json.Serialization;

namespace Masuda.QQNT;

public class Sender 
{
    [JsonPropertyName("uid")]
    public string Uid { get; set; } = string.Empty;
    [JsonPropertyName("memberName")]
    public string MemberName { get; set; } = string.Empty;
    [JsonPropertyName("nickName")]
    public string NickName { get; set; } = string.Empty;
}
