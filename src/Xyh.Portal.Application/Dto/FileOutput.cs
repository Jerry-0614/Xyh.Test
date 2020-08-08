using System.Collections.Generic;

namespace Xyh.Portal.Dto
{
    public class FileOutput
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public List<string> FileNames { get; set; }
    }

    public class FileInput
    {
        /// <summary>
        /// 文件内容字符串base64
        /// </summary>
        public string filestr { get; set; }
        /// <summary>
        /// 后缀名
        /// </summary>
        public string Extent { get; set; }
    }
}
