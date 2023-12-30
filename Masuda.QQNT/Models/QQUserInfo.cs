using System.Text.Json.Serialization;

namespace Masuda.QQNT;


public class QQUserInfo
{
    [JsonPropertyName("uid")]
    public string Uid { get; set; }

    [JsonPropertyName("qid")]
    public string Qid { get; set; }

    [JsonPropertyName("uin")]
    public string Uin { get; set; }

    [JsonPropertyName("avatarUrl")]
    public string AvatarUrl { get; set; }

    [JsonPropertyName("nickName")]
    public string NickName { get; set; }

    [JsonPropertyName("bio")]
    public string Bio { get; set; }

    [JsonPropertyName("sex")]
    public string Sex { get; set; }

    [JsonPropertyName("raw")]
    public Raw Raw { get; set; }
}

public class Raw
{
    public string uid { get; set; }
    public string qid { get; set; }
    public string uin { get; set; }
    public string nick { get; set; }
    public string remark { get; set; }
    public string longNick { get; set; }
    public string avatarUrl { get; set; }
    public int birthday_year { get; set; }
    public int birthday_month { get; set; }
    public int birthday_day { get; set; }
    public int sex { get; set; }
    public string topTime { get; set; }
    public bool isBlock { get; set; }
    public bool isMsgDisturb { get; set; }
    public bool isSpecialCareOpen { get; set; }
    public bool isSpecialCareZone { get; set; }
    public string ringId { get; set; }
    public int status { get; set; }
    public int extStatus { get; set; }
    public int categoryId { get; set; }
    public bool onlyChat { get; set; }
    public bool qzoneNotWatch { get; set; }
    public bool qzoneNotWatched { get; set; }
    public bool vipFlag { get; set; }
    public bool yearVipFlag { get; set; }
    public bool svipFlag { get; set; }
    public int vipLevel { get; set; }
}
