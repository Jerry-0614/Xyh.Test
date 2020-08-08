using System;
using System.Collections.Generic;
using System.Text;

namespace Xyh.It.Helper.Dto
{
    /// <summary>
    /// 百度翻译接口请求结果
    /// </summary>
    public class TranslationResult
    {
        /// <summary>
        /// 52000	成功	
        /// 52001	请求超时
        /// 52002	系统错误
        /// 52003	未授权用户
        /// 54000	必填参数为空
        /// 54001	签名错误
        /// 54003	访问频率受限
        /// 54004	账户余额不足
        /// 54005	长query请求频繁
        /// 58000	客户端IP非法
        /// 58001	译文语言方向不支持
        /// 58002	服务当前已关闭
        /// </summary>
        public string Error_code { get; set; }
        /// <summary>
        /// 返回的错误信息
        /// </summary>
        public string Error_msg { get; set; }
        /// <summary>
        /// 源语言
        /// </summary>
        public string From { get; set; }
        /// <summary>
        /// 目标语言
        /// </summary>
        public string To { get; set; }
        public string Query { get; set; }
        /// <summary>
        ///翻译正确，返回的结果
        ///这里是数组的原因是百度翻译支持多个单词或多段文本的翻译，在发送的字段q中用换行符（\n）分隔
        /// </summary>
        public Translation[] Trans_result { get; set; }
    }

    /// <summary>
    /// 百度翻译api翻译结果
    /// </summary>
    public class Translation
    {
        /// <summary>
        /// 源语言字符串
        /// </summary>
        public string Src { get; set; }
        /// <summary>
        /// 目标语言字符串
        /// </summary>
        public string Dst { get; set; }
    }

    /// <summary>
    /// api支持语言种类
    /// </summary>
    public enum Language
    {
        /// <summary>
        /// 自动检测（目标语言不能设置此属性）
        /// </summary>
        auto = 0,//    自动检测
        /// <summary>
        /// 中文
        /// </summary>
        zh = 1,//中文
        /// <summary>
        /// 英文
        /// </summary>
        en = 2,//英语
        /// <summary>
        /// 粤语
        /// </summary>
        yue = 3,//粤语
        /// <summary>
        /// 文言文
        /// </summary>
        wyw = 4,//文言文
        /// <summary>
        /// 日语
        /// </summary>
        jp = 5,//日语
        /// <summary>
        /// 韩语
        /// </summary>
        kor = 6,//韩语
        /// <summary>
        /// 法语
        /// </summary>
        fra = 7,//法语
        /// <summary>
        /// 西班牙语
        /// </summary>
        spa = 8,//西班牙语
        /// <summary>
        /// 泰语
        /// </summary>
        th = 9,//泰语
        /// <summary>
        /// 阿拉伯语
        /// </summary>
        ara = 10,//阿拉伯语
        /// <summary>
        /// 俄语
        /// </summary>
        ru = 11,//俄语
        /// <summary>
        /// 葡萄牙语
        /// </summary>
        pt = 12,//葡萄牙语
        /// <summary>
        /// 德语
        /// </summary>
        de = 13,//德语
        /// <summary>
        /// 意大利语
        /// </summary>
        it = 14,//意大利语
        /// <summary>
        /// 希腊语
        /// </summary>
        el = 15,//希腊语
        /// <summary>
        /// 荷兰语
        /// </summary>
        nl = 16,//荷兰语
        /// <summary>
        /// 波兰语
        /// </summary>
        pl = 17,//波兰语
        /// <summary>
        /// 保加利亚语
        /// </summary>
        bul = 18,//保加利亚语
        /// <summary>
        /// 爱沙尼亚语
        /// </summary>
        est = 19,//爱沙尼亚语
        /// <summary>
        /// 丹麦语
        /// </summary>
        dan = 20,//丹麦语
        /// <summary>
        /// 芬兰语
        /// </summary>
        fin = 21,//芬兰语
        /// <summary>
        /// 捷克语
        /// </summary>
        cs = 22,//捷克语
        /// <summary>
        /// 罗马尼亚语
        /// </summary>
        rom = 23,//罗马尼亚语
        /// <summary>
        /// 斯洛文尼亚语
        /// </summary>
        slo = 24,//斯洛文尼亚语
        /// <summary>
        /// 瑞典语
        /// </summary>
        swe = 25,//瑞典语
        /// <summary>
        /// 匈牙利语
        /// </summary>
        hu = 26,//匈牙利语
        /// <summary>
        /// 繁体中文
        /// </summary>
        cht = 27,//繁体中文
        /// <summary>
        /// 越南语
        /// </summary>
        vie = 28,//越南语
    }

    /// <summary>
    /// 用户请求最终结果
    /// </summary>
    public class TranslationDto
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 结果字符串
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// 错误码
        /// </summary>
        public string ErrorCode { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMsg { get; set; }
    }
}
