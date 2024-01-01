using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Masuda.QQNT.Models.Message
{
    // 不可send 撕烤解决
    public class GroupMessage : MessageBase
    {
        [JsonPropertyName("raw")]
        public Raw Rawdata { get; set; } = new Raw();
        public class Raw
        {
            [JsonPropertyName("elementType")]
            public int ElementType { get; set; } = 3;

            [JsonPropertyName("grayTipElement")]

            public GrayTipElement GrayTipElement { get; set; } = new();
        }

        public class GrayTipElement
        {
            public int subElementType { get; set; }
            public object revokeElement { get; set; }
            public object proclamationElement { get; set; }
            public object emojiReplyElement { get; set; }
            public Groupelement groupElement { get; set; }
            public object buddyElement { get; set; }
            public object feedMsgElement { get; set; }
            public object essenceElement { get; set; }
            public object groupNotifyElement { get; set; }
            public object buddyNotifyElement { get; set; }
            public object xmlElement { get; set; }
            public object fileReceiptElement { get; set; }
            public object localGrayTipElement { get; set; }
            public object blockGrayTipElement { get; set; }
            public object aioOpGrayTipElement { get; set; }
            public object jsonGrayTipElement { get; set; }
        }

        public class Groupelement
        {
            public int type { get; set; }
            public int role { get; set; }
            public string groupName { get; set; }
            public string memberUid { get; set; }
            public string memberNick { get; set; }
            public string memberRemark { get; set; }
            public string adminUid { get; set; }
            public string adminNick { get; set; }
            public string adminRemark { get; set; }
            public object createGroup { get; set; }
            public Memberadd memberAdd { get; set; }
            public object shutUp { get; set; }
        }

        public class Memberadd
        {
            public int showType { get; set; }
            public Otheradd otherAdd { get; set; }
            public object otherAddByOtherQRCode { get; set; }
            public object otherAddByYourQRCode { get; set; }
            public object youAddByOtherQRCode { get; set; }
            public object otherInviteOther { get; set; }
            public object otherInviteYou { get; set; }
            public object youInviteOther { get; set; }
        }

        public class Otheradd
        {
            public string uid { get; set; }
            public string name { get; set; }
        }

    }
}
