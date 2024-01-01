using System.Text.Json.Serialization;

namespace Masuda.QQNT.Models
{
    public class QQGroupInfo
    {
        [JsonPropertyName("uid")]
        public string Uid { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("maxMembers")]
        public int MaxMembers { get; set; }

        [JsonPropertyName("members")]
        public int Members { get; set; }

        [JsonPropertyName("raw")]
        public Raw Rawdata { get; set; }
    }
    public class Raw
    {
        public string groupCode { get; set; }
        public int maxMember { get; set; }
        public int memberCount { get; set; }
        public string groupName { get; set; }
        public int groupStatus { get; set; }
        public int memberRole { get; set; }
        public bool isTop { get; set; }
        public string toppedTimestamp { get; set; }
        public int privilegeFlag { get; set; }
        public bool isConf { get; set; }
        public bool hasModifyConfGroupFace { get; set; }
        public bool hasModifyConfGroupName { get; set; }
        public string remarkName { get; set; }
        public bool hasMemo { get; set; }
        public string groupShutupExpireTime { get; set; }
        public string personShutupExpireTime { get; set; }
        public string discussToGroupUin { get; set; }
        public int discussToGroupMaxMsgSeq { get; set; }
        public int discussToGroupTime { get; set; }
    }

}

