using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masuda.QQNT.Utils
{
    public class FileHelper
    {
        public static HttpClient HttpClient { get; set; } = new HttpClient();   

        public static async Task<string> DownloadImage(string url)
        {
            var filename = $"{Path.GetTempFileName()}.png";
            var bs = await HttpClient.GetByteArrayAsync(filename);
            await File.WriteAllBytesAsync(filename, bs);
            return filename;
        }

    }
}
