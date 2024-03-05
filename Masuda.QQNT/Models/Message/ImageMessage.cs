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
            Type = "image";

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

        public async Task<bool> WaitImageExistAsync(CancellationToken? cancellationToken = null)
        {
            cancellationToken ??= CancellationToken.None;
            string newFile = File.Replace("\\Ori\\", "\\OriTemp\\");
            string newFile1 = File.Replace("\\Ori\\", "\\Thumb\\");
            string ext = System.IO.Path.GetExtension(File);
            newFile1 = newFile1.Replace(ext, $"_0{ext}");
            string newFile2 = File.Replace("\\Ori\\", "\\ThumbTemp\\");
            newFile2 = newFile2.Replace(ext, $"_0{ext}");

            Console.WriteLine(newFile);
            Console.WriteLine(newFile1);
            Console.WriteLine(newFile2);

            while (!cancellationToken.Value.IsCancellationRequested)
            {
                if (System.IO.File.Exists(File))
                {
                    return true;
                }
                if (System.IO.File.Exists(newFile))
                {
                    File = newFile;
                    return true;

                }
                if (System.IO.File.Exists(newFile1))
                {
                    File = newFile1;
                    return true;

                }
                if (System.IO.File.Exists(newFile2))
                {
                    File = newFile2;
                    return true;

                }
                await Task.Delay(1000);
            }

            return false;
        }
    }
}
