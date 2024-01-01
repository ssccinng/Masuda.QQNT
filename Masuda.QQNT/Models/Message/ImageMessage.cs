using Masuda.QQNT.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Masuda.QQNT.Models.Message
{
    public class ImageMessage: MessageBase
    {
        public ImageMessage(string auto)
        {
            if (Uri.IsWellFormedUriString(auto, UriKind.Absolute))
            {
                File = FileHelper.DownloadImage(auto).Result;
            }
            else
            {
                File = auto;
            }
        }
        public ImageMessage(string? file = null, string? url = null)
        {
            Type = "image";
            if (file != null)
            {
                File = file;
            }
            else if (url != null)
            {
                File = FileHelper.DownloadImage(url).Result;
            }
        }
        public ImageMessage()
        {
            Type = "image";
        }
        [JsonPropertyName("file")]
        public string File { get; set; } = string.Empty;
    }
}
