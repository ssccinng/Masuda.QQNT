using Masuda.QQNT.Models;

namespace Masuda.QQNT;

public class AtMessage: PlainMessage
{
    public AtMessage()
    {
    }
    public AtMessage(string qq)
    {
        
    }
    public AtMessage(Sender sender)
    {
        TextElement.atType = 1;
    }

    

    public TextElement TextElement { get; set; } = new TextElement();
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
