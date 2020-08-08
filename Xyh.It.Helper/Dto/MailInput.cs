using System;
using System.Collections.Generic;
using System.Text;

namespace Xyh.It.Helper.Dto
{
    public class MailInput
    {
        /// <summary>
        /// 邮件地址
        /// </summary>
        public string MailAddress { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        public List<string> Attachments { get; set; }
        /// <summary>
        /// 发件人邮件地址
        /// </summary>
        public string SendMailAddress { get; set; }
        /// <summary>
        /// 发件人名称
        /// </summary>
        public string SendMailName { get; set; }
        /// <summary>
        /// 发件人密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 是否发送成功
        /// </summary>
        public int IsSend { get; set; }
    }
}
