using System.Text.Json.Serialization;

namespace Masuda.QQNT.Models.MasudaProtocol.Models;

public class Peer
{
    [JsonPropertyName("uid")]
    public string Uid { get; set; } = string.Empty;
    [JsonPropertyName("guildid")]
    public string? GuildId { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string? Name { get; set; } = string.Empty;
    [JsonPropertyName("chatType")]
    public string ChatType { get; set; } = string.Empty;
}
