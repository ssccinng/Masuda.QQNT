using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Masuda.QQNT.Models.Message
{
    public class ReplyMessage : MessageBase
    {

        public class Raw
        {
            [JsonPropertyName("elementType")]
            public int ElementType = 1;

            [JsonPropertyName("replyElement")]

            public ReplyElement TextElement { get; set; } = new ReplyElement();
        }
    }

    public class ReplyElement
    {
        public string replayMsgId { get; set; } = "0";
        public string replayMsgSeq { get; set; } = "0";
        public string replayMsgRootSeq { get; set; } = "0";
        public string replayMsgRootMsgId { get; set; } = "0";
        public string replayMsgRootCommentCnt { get; set; } = "0";
        public string sourceMsgIdInRecords { get; set; } = "0";
        public string sourceMsgText { get; set; } = "";
        public Sourcemsgtextelem[] sourceMsgTextElems { get; set; }
        public string senderUid { get; set; } = "0";
        public string senderUidStr { get; set; } = "0";
        public string replyMsgClientSeq { get; set; } = "0";
        public string replyMsgTime { get; set; } = "0";
        public int replyMsgRevokeType { get; set; } 
        public bool sourceMsgIsIncPic { get; set; }
        public bool sourceMsgExpired { get; set; }
        public object? anonymousNickName { get; set; } = null;
        public object? originalMsgState { get; set; } = null;
    }

    public class Sourcemsgtextelem
    {
        public int replyAbsElemType { get; set; } = 1;
        public string textElemContent { get; set; }
        public object? faceElem { get; set; } = null;
    }

}
