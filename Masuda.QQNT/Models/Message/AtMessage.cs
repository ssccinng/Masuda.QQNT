using Masuda.QQNT.Models;
using System.Text.Json.Serialization;

namespace Masuda.QQNT;

public class AtMessage: MessageBase
{
    public AtMessage()
    {
    }
    public AtMessage(string uid)
    {
        // 暂不支持
        // 要获取一下名字mo
        Rawdata.TextElement.atType = 2;
        Rawdata.TextElement.atNtUid = uid;
        Rawdata.TextElement.content = $"@{uid}";
    }
    public AtMessage(Sender sender)
    {
        Rawdata.TextElement.atType = 2;
        Rawdata.TextElement.atNtUid = sender.Uid;
        Rawdata.TextElement.content = $"@{sender.NickName}";
    }
    [JsonPropertyName("raw")]

    public Raw Rawdata = new();


    public class Raw
    {
        [JsonPropertyName("elementType")]
        public int ElementType = 1;

        [JsonPropertyName("textElement")]

        public TextElement TextElement { get; set; } = new TextElement();

    }
}

public enum AtType
{
    AtOne = 2,
    AtAll = 1

}

public class TextElement
{
    public string content { get; set; } = string.Empty;
    public int atType { get; set; } = 2;
    public string atUid { get; set; }= "0";
    public string atTinyId { get; set; }= "0";
    public string atNtUid { get; set; }= "0";
    public int subElementType { get; set; }
    public string atChannelId { get; set; } = "0";
    public string atRoleId { get; set; }= "0";
    public int atRoleColor { get; set; }
    public string atRoleName { get; set; }= "0";
    public int needNotify { get; set; }
}
