using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Masuda.QQNT.Models.Message.GroupMessage;

namespace Masuda.QQNT.Models.Message
{
    public class RefMessage: MessageBase
    {
        public class Raw
        {
            [JsonPropertyName("elementType")]
            public int ElementType { get; set; } = 16;

            [JsonPropertyName("multiForwardMsgElement")]

            public MultiForwardMsgElement MultiForwardMsgElement { get; set; } = new();
            public string elementId { get; set; } = "7469666414673362042";
            public string extBufForUI { get; set; } = "0x";
        }

        [JsonPropertyName("raw")]
        public Raw Rawdata { get; set; } = new Raw();
    }


    public class MultiForwardMsgElement
    {
        public string xmlContent { get; set; } = "<?xml version='1.0' encoding='UTF-8' standalone=\"yes\"?> <msg serviceID=\"35\" templateID=\"1\" action=\"viewMultiMsg\" brief=\"[聊天记录]\" m_fileName=\"52241bdf-baf6-4d11-b678-aeaec82e91f3\" m_resid=\"Of5B+0AjzQF4VKSg6Kqb05Fsz1gSwP1sY8CYdVyRA51hdTuBRCeAcPaLwMwFpCql\" tSum=\"2\" flag=\"3\"><item layout=\"1\"> <title color=\"#000000\" size=\"34\">群聊的聊天记录</title><title color=\"#777777\" size=\"26\">jx: [动画表情]</title><title color=\"#777777\" size=\"26\">jx: 邀为同道</title> <hr></hr> <summary color=\"#808080\">查看2条转发消息</summary></item> <source name=\"群聊的聊天记录\"></source> </msg>";
        public string resId { get; set; } = "Of5B+0AjzQF4VKSg6Kqb05Fsz1gSwP1sY8CYdVyRA51hdTuBRCeAcPaLwMwFpCql";
        public string fileName { get; set; } = "52241bdf-baf6-4d11-b678-aeaec82e91f3";
    }

}
