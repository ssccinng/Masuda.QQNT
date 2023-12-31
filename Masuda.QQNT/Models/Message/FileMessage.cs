using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Masuda.QQNT.Models.Message
{
   
    public class FileMessage : MessageBase
    {
        public static string CalculateMD5(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
        public FileMessage(string filePath)
        {
            Rawdata.FileElement.filePath = filePath;
            Rawdata.FileElement.fileName = Path.GetFileName(filePath);
            Rawdata.FileElement.fileSize = new FileInfo(filePath).Length.ToString();
            Rawdata.FileElement.fileMd5 = CalculateMD5(filePath).ToLower();

            //if (filePath.EndsWith())
            //Rawdata.FileElement.fileUuid = $"/{Guid.NewGuid()}";
        }

        [JsonPropertyName("raw")]
        public Raw Rawdata { get; set; } = new Raw();
        public class Raw
        {
            [JsonPropertyName("elementType")]
            public int ElementType { get; set; } = 3;

            [JsonPropertyName("fileElement")]

            public FileElement FileElement { get; set; } = new();
        }


        public class FileElement
        {
            public string fileMd5 { get; set; } = string.Empty;
            public string fileName { get; set; } = string.Empty;
            public string filePath { get; set; } = string.Empty;
            public string fileSize { get; set; } = string.Empty;
            public int? picHeight { get; set; } = null;
            public int? picWidth { get; set; } = null;
            public Picthumbpath picThumbPath { get; set; }
            public string expireTime { get; set; } = "0";
            public string file10MMd5 { get; set; } = string.Empty;
            public string fileSha { get; set; } = string.Empty;
            public string fileSha3 { get; set; } = string.Empty;
            public int videoDuration { get; set; }
            public int transferStatus { get; set; } = 2;
            public int progress { get; set; }
            public int invalidState { get; set; }
            public string fileUuid { get; set; } = string.Empty;
            public string fileSubId { get; set; } = string.Empty;
            public int thumbFileSize { get; set; }
            public object? fileBizId { get; set; } = null;
            public object? thumbMd5 { get; set; } = null;
            public object? folderId { get; set; } = null;
            public int fileGroupIndex { get; set; }
            public object? fileTransType { get; set; } = null;
        }

        public class Picthumbpath
        {
        }

    }
}