using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Masuda.QQNT.Models.Message.FileMessage;

namespace Masuda.QQNT.Models.Message
{
    public class MusicMessage : MessageBase
    {
        private readonly string _id;
        private readonly string _name;
        private readonly string? _pic;

        public MusicMessage(string id, string name, string? pic = null)
        {
            _id = id;
            _name = name;
            _pic = pic;
            Rawdata.ArkElement = new(
                _id, _name, _pic);
        }
        [JsonPropertyName("raw")]
        public Raw Rawdata { get; set; } = new Raw();
        public class Raw
        {
            [JsonPropertyName("elementType")]
            public int ElementType { get; set; } = 10;
            public string elementId { get; set; } = "7401142092240369404";
            public string extBufForUI { get; set; } = "0x";

            [JsonPropertyName("arkElement")]

            public ArkElement ArkElement { get; set; } 
        }
    }

    public record ArkElement(string id, string name, string? pic = null)
    {
        string _temp1 = "{\"app\":\"com.tencent.structmsg\",\"config\":{\"ctime\":1723212676,\"forward\":1,\"token\":\"da3a7e8b5b0d133133d3a03a7e28c744\",\"type\":\"normal\"},\"extra\":{\"app_type\":1,\"appid\":100495085,\"msg_seq\":7401142080534229608,\"uin\":1078995020},\"meta\":{\"music\":{\"action\":\"\",\"android_pkg_name\":\"\",\"app_type\":1,\"appid\":100495085,\"ctime\":1723212676,\"desc\":\"光田康典/Anúna\",\"jumpUrl\":\"https://y.music.163.com/m/song?id=1968746292&userid=415591944&dlt=0846\",\"musicUrl\":\"http://music.163.com/song/media/outer/url?id=1968746292&userid=415591944\",\"preview\":\"http://p1.music.126.net/uz6z15QyBmrnsC-pSmJMWA==/109951167736550226.jpg?imageView=1&thumbnail=1200z2543&type=webp&quality=80\",\"sourceMsgId\":\"0\",\"source_icon\":\"https://i.gtimg.cn/open/app_icon/00/49/50/85/100495085_100_m.png\",\"source_url\":\"\",\"tag\":\"网易云音乐\",\"title\":\"Where We Belong (我们的归宿)\",\"uin\":1078995020}},\"prompt\":\"[分享]Where We Belong (我们的归宿)\",\"ver\":\"0.0.0.1\",\"view\":\"music\"}";
        string cc = "{\"app\":\"com.tencent.structmsg\",\"config\":{\"ctime\":1723251611,\"forward\":1,\"token\":\"7b5ca2d1bad3cd4348cff9e55dd5b69f\",\"type\":\"normal\"},\"extra\":{\"app_type\":1,\"appid\":100495086,\"msg_seq\":7401309305410793265,\"uin\":1078995021},\"meta\":{\"music\":{\"action\":\"\",\"android_pkg_name\":\"\",\"app_type\":1,\"appid\":100495085,\"ctime\":1723251611,\"desc\":\"高橋李依\",\"jumpUrl\":\"https://y.music.163.com/m/song?id=2061964537&uct2=08H7xiucZK6LN%2BEJJiolkw%3D%3D&playerUIModeId=76001&PlayerStyles_SynchronousSharing=c&dlt=0846&app_version=9.1.30\",\"musicUrl\":\"http://music.163.com/song/media/outer/url?id=2061964537&userid=415591944&sc=wm&tn=\",\"preview\":\"http://p2.music.126.net/BCqnQf0myD2U0uFAjjUEhg==/109951168721931898.jpg?imageView=1&thumbnail=1200z2543&type=webp&quality=80\",\"sourceMsgId\":\"0\",\"source_icon\":\"https://i.gtimg.cn/open/app_icon/00/49/50/85/100495085_100_m.png\",\"source_url\":\"\",\"tag\":\"网易云音乐\",\"title\":\"サインはB -アイ Solo Ver.- (暗号B)\",\"uin\":1078995020}},\"prompt\":\"[分享]サインはB -アイ Solo Ver.- (暗号B)\",\"ver\":\"0.0.0.2\",\"view\":\"music\"}";


        string _temp = "{\"app\":\"com.tencent.structmsg\", \"config\":{\"ctime\":1723212676,\"forward\":1,\"token\":\"da3a7e8b5b0d133133d3a03a7e28c744\",\"type\":\"normal\"},\"extra\":{\"app_type\":1,\"appid\":100495085,\"msg_seq\":7401142080534229608,\"uin\":1078995020},\"meta\":{\"music\":{\"action\":\"\",\"android_pkg_name\":\"\",\"app_type\":1,\"appid\":100495085,\"ctime\":1723212676,\"desc\":\"光田康典/Anúna\",\"jumpUrl\":\"https://y.music.163.com/m/song?id={0}&userid=415591944&dlt=0846\",\"musicUrl\":\"http://music.163.com/song/media/outer/url?id={0}&userid=415591944\",\"preview\":\"{1}\",\"sourceMsgId\":\"0\",\"source_icon\":\"https://i.gtimg.cn/open/app_icon/00/49/50/85/100495085_100_m.png\",\"source_url\":\"\",\"tag\":\"网易云音乐\",\"title\":\"{2}\",\"uin\":1078995020}},\"prompt\":\"[分享]{2}\",\"ver\":\"0.0.0.1\",\"view\":\"music\"}";

        [JsonPropertyName("bytesData")]
        //public string BytesData => _temp1; //.Replace("{0}", id).Replace("{1}", pic).Replace("{2}", name);
        public string BytesData => cc; //.Replace("{0}", id).Replace("{1}", pic).Replace("{2}", name);
        //public string BytesData => _temp.Replace("{0}", id).Replace("{1}", pic).Replace("{2}", name);
    }



    public class Rootobject
    {
        public string app { get; set; }
        public Config config { get; set; }
        public Extra extra { get; set; }
        public Meta meta { get; set; }
        public string prompt { get; set; }
        public string ver { get; set; }
        public string view { get; set; }
    }

    public class Config
    {
        public int ctime { get; set; }
        public int forward { get; set; }
        public string token { get; set; }
        public string type { get; set; }
    }

    public class Extra
    {
        public int app_type { get; set; }
        public int appid { get; set; }
        public long msg_seq { get; set; }
        public int uin { get; set; }
    }

    public class Meta
    {
        public Music music { get; set; }
    }

    public class Music
    {
        public string action { get; set; }
        public string android_pkg_name { get; set; }
        public int app_type { get; set; }
        public int appid { get; set; }
        public int ctime { get; set; }
        public string desc { get; set; }
        public string jumpUrl { get; set; }
        public string musicUrl { get; set; }
        public string preview { get; set; }
        public string sourceMsgId { get; set; }
        public string source_icon { get; set; }
        public string source_url { get; set; }
        public string tag { get; set; }
        public string title { get; set; }
        public int uin { get; set; }
    }

}
