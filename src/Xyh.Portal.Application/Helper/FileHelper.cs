using System.IO;

namespace Xyh.Portal.Helper
{
    public static class FileHelper
    {
        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetContentType(string path)
        {
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return GetMimeType(ext);
        }
        /// <summary>
        /// 文件类型
        /// </summary>
        /// <returns></returns>
        public static string GetMimeType(string ext)
        {
            string contentType = string.Empty;
            switch (ext)
            {
                case ".txt":
                    contentType = "text/plain";
                    break;
                case ".pdf":
                    contentType = "application/pdf";
                    break;
                case ".doc":
                case ".docx":
                    contentType = "application/vnd.ms-word";
                    break;
                case ".xls":
                    contentType = "application/vnd.ms-excel";
                    break;
                case ".xlsx":
                    contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    break;
                case ".png":
                    contentType = "image/png";
                    break;
                case ".jpeg":
                    contentType = "image/jpeg";
                    break;
                case ".gif":
                    contentType = "image/gif";
                    break;
                case ".csv":
                    contentType = "text/csv";
                    break;
                default:
                    contentType = "application/octet-stream";
                    break;
            }
            return contentType;
        }

    }
}
