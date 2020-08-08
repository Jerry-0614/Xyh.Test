using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace Xyh.It.Helper
{
    public static class CommonClass
    {


        /// <summary>
        ///     获取随机四位数
        /// </summary>
        /// <param name="length">长度</param>
        public static int GetRandomDefault(int length)
        {
            var ro = new Random(unchecked((int)DateTime.Now.Ticks));
            string minStr = "", maxStr = "";
            for (int i = 0; i < length; i++)
            {
                if (i == 0)
                {
                    minStr += "1";
                }
                else
                {
                    minStr += "0";
                }
                maxStr += "9";
            }

            return ro.Next(Convert.ToInt32(minStr), Convert.ToInt32(maxStr));
        }

        // 获取AppSettings节点值
        public static string GetAppSettingsValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// 获取Config文件夹下自定义配置文件的值
        /// 根节点须为appSettings
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="fileName">文件名(不需要扩展名，如：NC)</param>
        /// <returns>结果值</returns>
        public static string GetConfigValue(string key, string fileName)
        {
            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(fileName))
            {
                return "";
            }
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "\\Config\\" + fileName + ".config");
                return xDoc.SelectSingleNode("appSettings/add[@key='" + key + "']").Attributes["value"].Value;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        /// <summary>
        ///     计算日期是周几
        /// </summary>
        /// <returns>返回整型</returns>
        public static int GetWeekInt(DateTime dt)
        {
            var retI = 1;
            var strWeek = dt.DayOfWeek.ToString();
            if (strWeek == "Monday")
            {
                retI = 1;
            }
            else if (strWeek == "Tuesday")
            {
                retI = 2;
            }
            else if (strWeek == "Wednesday")
            {
                retI = 3;
            }
            else if (strWeek == "Thursday")
            {
                retI = 4;
            }
            else if (strWeek == "Friday")
            {
                retI = 5;
            }
            else if (strWeek == "Saturday")
            {
                retI = 6;
            }
            else
            {
                retI = 7;
            }

            return retI;
        }

        public static string UseMd5(string str)
        {
            var cl = str;
            var pwd = "";
            var md5 = MD5.Create(); //实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            var s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (var i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                pwd = pwd + s[i].ToString("x2");
            }
            return pwd.ToLower();
        }


        #region 根据字母取Excel的列数

        /// <summary>
        ///     Excel文件列号
        /// </summary>
        /// <param name="columnEn"></param>
        /// <returns></returns>
        public static int ExcelColumnNumber(string columnEn)
        {
            int reInt;
            switch (columnEn.ToUpper().Trim())
            {
                case "A":
                    reInt = 0;
                    break;
                case "B":
                    reInt = 1;
                    break;
                case "C":
                    reInt = 2;
                    break;
                case "D":
                    reInt = 3;
                    break;
                case "E":
                    reInt = 4;
                    break;
                case "F":
                    reInt = 5;
                    break;
                case "G":
                    reInt = 6;
                    break;
                case "H":
                    reInt = 7;
                    break;
                case "I":
                    reInt = 8;
                    break;
                case "J":
                    reInt = 9;
                    break;
                case "K":
                    reInt = 10;
                    break;
                case "L":
                    reInt = 11;
                    break;
                case "M":
                    reInt = 12;
                    break;
                case "N":
                    reInt = 13;
                    break;
                case "O":
                    reInt = 14;
                    break;
                case "P":
                    reInt = 15;
                    break;
                case "Q":
                    reInt = 16;
                    break;
                case "R":
                    reInt = 17;
                    break;
                case "S":
                    reInt = 18;
                    break;
                case "T":
                    reInt = 19;
                    break;
                case "U":
                    reInt = 20;
                    break;
                case "V":
                    reInt = 21;
                    break;
                case "W":
                    reInt = 22;
                    break;
                case "X":
                    reInt = 23;
                    break;
                case "Y":
                    reInt = 24;
                    break;
                case "Z":
                    reInt = 25;
                    break;
                case "AA":
                    reInt = 26;
                    break;
                case "AB":
                    reInt = 27;
                    break;
                case "AC":
                    reInt = 28;
                    break;
                case "AD":
                    reInt = 29;
                    break;
                case "AE":
                    reInt = 30;
                    break;
                case "AF":
                    reInt = 31;
                    break;
                case "AG":
                    reInt = 32;
                    break;
                case "AH":
                    reInt = 33;
                    break;
                case "AI":
                    reInt = 34;
                    break;
                case "AJ":
                    reInt = 35;
                    break;
                case "AK":
                    reInt = 36;
                    break;
                case "AL":
                    reInt = 37;
                    break;
                case "AM":
                    reInt = 38;
                    break;
                case "AN":
                    reInt = 39;
                    break;
                case "AO":
                    reInt = 40;
                    break;
                case "AP":
                    reInt = 41;
                    break;
                case "AQ":
                    reInt = 42;
                    break;
                case "AR":
                    reInt = 43;
                    break;
                case "AS":
                    reInt = 44;
                    break;
                case "AT":
                    reInt = 45;
                    break;
                case "AU":
                    reInt = 46;
                    break;
                case "AV":
                    reInt = 47;
                    break;
                case "AW":
                    reInt = 48;
                    break;
                case "AX":
                    reInt = 49;
                    break;
                case "AY":
                    reInt = 50;
                    break;
                case "AZ":
                    reInt = 51;
                    break;
                default:
                    reInt = -1;
                    break;
            }
            return reInt;
        }

        #endregion

        /// <summary>
        ///     深度复制引用类
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T Clone<T>(T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        /// <summary>
        /// 把子对象的属性的值赋予给父对象
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        public static void SetValueToParent(object parent, object child)
        {
            Type ntype = parent.GetType();
            Type nnt = child.GetType();
            foreach (var p in ntype.GetProperties())
            {
                if (nnt.GetProperty(p.Name) != null)
                {
                    p.SetValue(parent, nnt.GetProperty(p.Name).GetValue(child, null), null);
                }
            }
        }

        /// <summary>
        ///     获取金额
        /// </summary>
        /// <param name="MoneyObj"></param>
        /// <returns></returns>
        public static decimal GetdecimalMoney(object MoneyObj)
        {
            var newMoney = 0.00m;
            if (MoneyObj != null && MoneyObj.ToString() != "")
            {
                decimal.TryParse(MoneyObj.ToString(), out newMoney);
            }
            return newMoney;
        }

        /// <summary>
        /// 获取年龄
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public static int GetAge(DateTime birthday)
        {
            var year = DateTime.Now.Year - birthday.Year;
            var month = DateTime.Now.Month - birthday.Month;
            var day = DateTime.Now.Day - birthday.Day;

            if (month < 0 || day < 0)
                year = year - 1;

            return year;
        }

        /// <summary>
        /// 获取年龄
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        public static int GetAge(DateTime birthday, DateTime targetDate)
        {
            var year = targetDate.Year - birthday.Year;
            var month = targetDate.Month - birthday.Month;
            var day = targetDate.Day - birthday.Day;

            if (month < 0 || day < 0)
                year = year - 1;

            return year;
        }

        /// <summary>
        ///     日期计算
        /// </summary>
        /// <param name="format">日期格式（yyyy,MM,dd）</param>
        /// <param name="oldDate">原日期</param>
        /// <param name="dateNum">数值（正值为以后，负值为以前）</param>
        /// <returns>计算后的日期(yyyy-MM-dd)</returns>
        public static string DateAdd(string format, string oldDate, int dateNum)
        {
            var newDate = "";
            if (oldDate != "")
            {
                DateTime dt;
                if (DateTime.TryParse(oldDate, out dt))
                {
                    dt = DateTime.Parse(oldDate);
                    switch (format)
                    {
                        case "yyyy":
                            {
                                newDate = dt.AddYears(dateNum).ToStringBit23(10);
                                break;
                            }
                        case "MM":
                            {
                                newDate = dt.AddMonths(dateNum).ToStringBit23(10);
                                break;
                            }
                        case "dd":
                            {
                                newDate = dt.AddDays(dateNum).ToStringBit23(10);
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }

            return newDate;
        }

        #region Money值和中文大写数的转换

        public static string ConvertSum(string str)
        {
            var ch = new char[1];
            ch[0] = '.'; //小数点 
            string[] splitstr = null; //定义按小数点分割后的字符串数组 
            splitstr = str.Split(ch[0]); //按小数点分割字符串 
            if (splitstr.Length == 1) //只有整数部分 
                return ConvertData(str) + "元整";
            var zspart = ConvertData(splitstr[0]) + "元"; //转换整数部分 
            var xspart = ConvertXiaoShu(splitstr[1]); //转换小数部分 
            return zspart + (string.IsNullOrWhiteSpace(xspart) ? "整" : xspart);
        }

        /// 转换数字（整数） 
        /// 需要转换的整数数字字符串 
        /// 转换成中文大写后的字符串
        public static string ConvertData(string str)
        {
            var tmpstr = "";
            var rstr = "";
            var strlen = str.Length;
            if (strlen <= 4) //数字长度小于四位 
            {
                rstr = ConvertDigit(str);
            }
            else
            {
                if (strlen <= 8) //数字长度大于四位，小于八位 
                {
                    tmpstr = str.Substring(strlen - 4, 4); //先截取最后四位数字 
                    rstr = ConvertDigit(tmpstr); //转换最后四位数字 
                    tmpstr = str.Substring(0, strlen - 4); //截取其余数字 
                    //将两次转换的数字加上萬后相连接 
                    rstr = string.Concat(ConvertDigit(tmpstr) + "万", rstr);
                    rstr = rstr.Replace("零万", "万");
                    rstr = rstr.Replace("零零", "零");
                }
                else if (strlen <= 12) //数字长度大于八位，小于十二位 
                {
                    tmpstr = str.Substring(strlen - 4, 4); //先截取最后四位数字 
                    rstr = ConvertDigit(tmpstr); //转换最后四位数字 
                    tmpstr = str.Substring(strlen - 8, 4); //再截取四位数字 
                    rstr = string.Concat(ConvertDigit(tmpstr) + "万", rstr);
                    tmpstr = str.Substring(0, strlen - 8);
                    rstr = string.Concat(ConvertDigit(tmpstr) + "亿", rstr);
                    rstr = rstr.Replace("零亿", "亿");
                    rstr = rstr.Replace("零万", "零");
                    rstr = rstr.Replace("零零", "零");
                    rstr = rstr.Replace("零零", "零");
                }
            }
            strlen = rstr.Length;
            if (strlen >= 2)
            {
                switch (rstr.Substring(strlen - 2, 2))
                {
                    case "佰零":
                        rstr = rstr.Substring(0, strlen - 2) + "佰";
                        break;
                    case "仟零":
                        rstr = rstr.Substring(0, strlen - 2) + "仟";
                        break;
                    case "万零":
                        rstr = rstr.Substring(0, strlen - 2) + "万";
                        break;
                    case "亿零":
                        rstr = rstr.Substring(0, strlen - 2) + "亿";
                        break;
                }
            }

            return rstr;
        }

        /// 转换数字（小数部分）
        /// 需要转换的小数部分数字字符串 
        /// 转换成中文大写后的字符串
        public static string ConvertXiaoShu(string str)
        {
            var strlen = str.Length;
            string rstr;
            if (strlen == 1)
            {
                rstr = ConvertChinese(str) + "角";
                return rstr;
            }
            var tmpstr = str.Substring(0, 1);
            rstr = ConvertChinese(tmpstr) + "角";
            tmpstr = str.Substring(1, 1);
            rstr += ConvertChinese(tmpstr) + "分";
            rstr = rstr.Replace("零分", "");
            rstr = rstr.Replace("零角", "");
            return rstr;
        }

        /// 转换数字 
        /// 
        /// 转换的字符串（四位以内）
        public static string ConvertDigit(string str)
        {
            var strlen = str.Length;
            var rstr = "";
            switch (strlen)
            {
                case 1:
                    rstr = ConvertChinese(str);
                    break;
                case 2:
                    rstr = Convert2Digit(str);
                    break;
                case 3:
                    rstr = Convert3Digit(str);
                    break;
                case 4:
                    rstr = Convert4Digit(str);
                    break;
            }
            rstr = rstr.Replace("拾零", "拾");
            return rstr;
        }

        /// 转换四位数字
        public static string Convert4Digit(string str)
        {
            var str1 = str.Substring(0, 1);
            var str2 = str.Substring(1, 1);
            var str3 = str.Substring(2, 1);
            var str4 = str.Substring(3, 1);
            var rstring = "";
            rstring += ConvertChinese(str1) + "仟";
            rstring += ConvertChinese(str2) + "佰";
            rstring += ConvertChinese(str3) + "拾";
            rstring += ConvertChinese(str4);
            rstring = rstring.Replace("零仟", "零");
            rstring = rstring.Replace("零佰", "零");
            rstring = rstring.Replace("零拾", "零");
            rstring = rstring.Replace("零零", "零");
            rstring = rstring.Replace("零零", "零");
            rstring = rstring.Replace("零零", "零");
            return rstring;
        }

        /// 转换三位数字
        public static string Convert3Digit(string str)
        {
            var str1 = str.Substring(0, 1);
            var str2 = str.Substring(1, 1);
            var str3 = str.Substring(2, 1);
            var rstring = "";
            rstring += ConvertChinese(str1) + "佰";
            rstring += ConvertChinese(str2) + "拾";
            rstring += ConvertChinese(str3);
            rstring = rstring.Replace("零佰", "零");
            rstring = rstring.Replace("零拾", "零");
            rstring = rstring.Replace("零零", "零");
            rstring = rstring.Replace("零零", "零");
            return rstring;
        }

        /// 转换二位数字
        public static string Convert2Digit(string str)
        {
            var str1 = str.Substring(0, 1);
            var str2 = str.Substring(1, 1);
            var rstring = "";
            rstring += ConvertChinese(str1) + "拾";
            rstring += ConvertChinese(str2);
            rstring = rstring.Replace("零拾", "零");
            rstring = rstring.Replace("零零", "零");
            return rstring;
        }

        /// 将一位数字转换成中文大写数字
        public static string ConvertChinese(string str)
        {
            //"零壹贰叁肆伍陆柒捌玖拾佰仟万亿元整角分" 
            var cstr = "";
            switch (str)
            {
                case "0":
                    cstr = "零";
                    break;
                case "1":
                    cstr = "壹";
                    break;
                case "2":
                    cstr = "贰";
                    break;
                case "3":
                    cstr = "叁";
                    break;
                case "4":
                    cstr = "肆";
                    break;
                case "5":
                    cstr = "伍";
                    break;
                case "6":
                    cstr = "陆";
                    break;
                case "7":
                    cstr = "柒";
                    break;
                case "8":
                    cstr = "捌";
                    break;
                case "9":
                    cstr = "玖";
                    break;
            }
            return (cstr);
        }

        #endregion

        #region 格式验证

        /// <summary>
        ///     电话号码、传真号验证
        /// </summary>
        /// <param name="Tel"></param>
        /// <returns></returns>
        public static int CheckTel(string Tel)
        {
            int i, j, len = 0;
            len = Tel.Length;
            if (len < 7 || len > 32)
            {
                return 0;
            }
            var strTemp = "0123456789-()# ";
            for (i = 0; i < len; i++)
            {
                j = strTemp.IndexOf(Tel[i]);
                if (j == -1)
                {
                    return 0;
                }
            }
            return 1;
        }

        /// <summary>
        /// 验证手机号
        /// </summary>
        /// <param name="Tel"></param>
        /// <returns></returns>
        public static int CheckMobile(string Tel)
        {
            int i, j, len = 0;
            len = Tel.Length;
            if (!(len == 11 || len == 12))
            {
                return 0;
            }
            var strTemp = "0123456789";
            for (i = 0; i < len; i++)
            {
                j = strTemp.IndexOf(Tel[i]);
                if (j == -1)
                    return 0;
            }
            return 1;
        }

        #region 验证身份证号

        public static bool CheckIdCard(string Id)
        {
            if (Id.Length == 18)
            {
                var check = CheckIdCard18(Id);
                return check;
            }
            if (Id.Length == 15)
            {
                var check = CheckIdCard15(Id);
                return check;
            }
            return false;
        }

        private static bool CheckIdCard18(string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false; //数字验证
            }
            var address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false; //省份验证
            }
            var birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            var time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false; //生日 验证
            }
            var arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            var Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            var Ai = Id.Remove(17).ToCharArray();
            var sum = 0;
            for (var i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            var y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false; //校验码验证
            }
            return true; //符合GB11643-1999标准 
        }

        private static bool CheckIdCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false; //数字验证
            }
            var address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x 63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false; //省份验证
            }
            var birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "- ");
            var time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false; //生日验证
            }
            return true; //符合15位身份证标准
        }

        #endregion

        #endregion


        /// <summary>
        /// 对字符串进行MD5加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetMD5String(string input)
        {
            if (input == null)
            {
                return null;
            }
            MD5 md5Hash = MD5.Create();
            //将输入字符串转换为字节数组并计算哈希数据  
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            //创建一个 Stringbuilder 来收集字节并创建字符串  
            StringBuilder sBuilder = new StringBuilder();
            //循环遍历哈希数据的每一个字节并格式化为十六进制字符串  
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            //返回十六进制字符串  
            return sBuilder.ToString();
        }

        public static Dictionary<string, string> FileExtensionContentType = new Dictionary<string, string>(){
                    { ".*", "application/octet-stream" },
                    {".apk", "application/vnd.android.package-archive"},
                    {".png", "image/png"},
                    {".jpg", "image/jpeg"},
                    {".jpeg", "image/jpeg"},
                    {".html", "text/html"},
                    {".ipa", "application/octet-stream.ipa"},
                    {".plist", "application/xml"},
                    {".xls", "application/vnd.ms-excel"},
                    {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                    {".pdf", "application/pdf"},
                    {".txt", "text/plain"},
                    {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
                    {".ppt", "application/vnd.ms-powerpoint"},
                    {".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation"},
                    {".gif", "image/gif"},
                    {".zip", "application/zip"},
                    {".doc", "application/msword"},
                    {".mp4", "video/mp4"},
                    {".mp3", "audio/mp3"},
                    {".mov", "video/quicktime"},
                    {".mobileprovision", "application/octet-stream"},


{".3dml", "text/vnd.in3d.3dml"},
{".3ds", "image/x-3ds"},
{".3g2", "video/3gpp2"},
{".3gp", "video/3gpp"},
{".7z", "application/x-7z-compressed"},
{".aab", "application/x-authorware-bin"},
{".aac", "audio/x-aac"},
{".aam", "application/x-authorware-map"},
{".aas", "application/x-authorware-seg"},
{".abw", "application/x-abiword"},
{".ac", "application/pkix-attr-cert"},
{".acc", "application/vnd.americandynamics.acc"},
{".ace", "application/x-ace-compressed"},
{".acu", "application/vnd.acucobol"},
{".acutc", "application/vnd.acucorp"},
{".adp", "audio/adpcm"},
{".aep", "application/vnd.audiograph"},
{".afm", "application/x-font-type1"},
{".afp", "application/vnd.ibm.modcap"},
{".ahead", "application/vnd.ahead.space"},
{".ai", "application/postscript"},
{".aif", "audio/x-aiff"},
{".aifc", "audio/x-aiff"},
{".aiff", "audio/x-aiff"},
{".air", "application/vnd.adobe.air-application-installer-package+zip"},
{".ait", "application/vnd.dvb.ait"},
{".ami", "application/vnd.amiga.ami"},
{".appcache", "text/cache-manifest"},
{".application", "application/x-ms-application"},
{".apr", "application/vnd.lotus-approach"},
{".arc", "application/x-freearc"},
{".asc", "application/pgp-signature"},
{".asf", "video/x-ms-asf"},
{".asm", "text/x-asm"},
{".aso", "application/vnd.accpac.simply.aso"},
{".asx", "video/x-ms-asf"},
{".atc", "application/vnd.acucorp"},
{".atom", "application/atom+xml"},
{".atomcat", "application/atomcat+xml"},
{".atomsvc", "application/atomsvc+xml"},
{".atx", "application/vnd.antix.game-component"},
{".au", "audio/basic"},
{".avi", "video/x-msvideo"},
{".aw", "application/applixware"},
{".azf", "application/vnd.airzip.filesecure.azf"},
{".azs", "application/vnd.airzip.filesecure.azs"},
{".azw", "application/vnd.amazon.ebook"},
{".bat", "application/x-msdownload"},
{".bcpio", "application/x-bcpio"},
{".bdf", "application/x-font-bdf"},
{".bdm", "application/vnd.syncml.dm+wbxml"},
{".bed", "application/vnd.realvnc.bed"},
{".bh2", "application/vnd.fujitsu.oasysprs"},
{".bin", "application/octet-stream"},
{".blb", "application/x-blorb"},
{".blorb", "application/x-blorb"},
{".bmi", "application/vnd.bmi"},
{".bmp", "image/bmp"},
{".book", "application/vnd.framemaker"},
{".box", "application/vnd.previewsystems.box"},
{".boz", "application/x-bzip2"},
{".bpk", "application/octet-stream"},
{".btif", "image/prs.btif"},
{".bz", "application/x-bzip"},
{".bz2", "application/x-bzip2"},
{".c", "text/x-c"},
{".c11amc", "application/vnd.cluetrust.cartomobile-config"},
{".c11amz", "application/vnd.cluetrust.cartomobile-config-pkg"},
{".c4d", "application/vnd.clonk.c4group"},
{".c4f", "application/vnd.clonk.c4group"},
{".c4g", "application/vnd.clonk.c4group"},
{".c4p", "application/vnd.clonk.c4group"},
{".c4u", "application/vnd.clonk.c4group"},
{".cab", "application/vnd.ms-cab-compressed"},
{".caf", "audio/x-caf"},
{".cap", "application/vnd.tcpdump.pcap"},
{".car", "application/vnd.curl.car"},
{".cat", "application/vnd.ms-pki.seccat"},
{".cb7", "application/x-cbr"},
{".cba", "application/x-cbr"},
{".cbr", "application/x-cbr"},
{".cbt", "application/x-cbr"},
{".cbz", "application/x-cbr"},
{".cc", "text/x-c"},
{".cct", "application/x-director"},
{".ccxml", "application/ccxml+xml"},
{".cdbcmsg", "application/vnd.contact.cmsg"},
{".cdf", "application/x-netcdf"},
{".cdkey", "application/vnd.mediastation.cdkey"},
{".cdmia", "application/cdmi-capability"},
{".cdmic", "application/cdmi-container"},
{".cdmid", "application/cdmi-domain"},
{".cdmio", "application/cdmi-object"},
{".cdmiq", "application/cdmi-queue"},
{".cdx", "chemical/x-cdx"},
{".cdxml", "application/vnd.chemdraw+xml"},
{".cdy", "application/vnd.cinderella"},
{".cer", "application/pkix-cert"},
{".cfs", "application/x-cfs-compressed"},
{".cgm", "image/cgm"},
{".chat", "application/x-chat"},
{".chm", "application/vnd.ms-htmlhelp"},
{".chrt", "application/vnd.kde.kchart"},
{".cif", "chemical/x-cif"},
{".cii", "application/vnd.anser-web-certificate-issue-initiation"},
{".cil", "application/vnd.ms-artgalry"},
{".cla", "application/vnd.claymore"},
{".class", "application/java-vm"},
{".clkk", "application/vnd.crick.clicker.keyboard"},
{".clkp", "application/vnd.crick.clicker.palette"},
{".clkt", "application/vnd.crick.clicker.template"},
{".clkw", "application/vnd.crick.clicker.wordbank"},
{".clkx", "application/vnd.crick.clicker"},
{".clp", "application/x-msclip"},
{".cmc", "application/vnd.cosmocaller"},
{".cmdf", "chemical/x-cmdf"},
{".cml", "chemical/x-cml"},
{".cmp", "application/vnd.yellowriver-custom-menu"},
{".cmx", "image/x-cmx"},
{".cod", "application/vnd.rim.cod"},
{".com", "application/x-msdownload"},
{".conf", "text/plain"},
{".cpio", "application/x-cpio"},
{".cpp", "text/x-c"},
{".cpt", "application/mac-compactpro"},
{".crd", "application/x-mscardfile"},
{".crl", "application/pkix-crl"},
{".crt", "application/x-x509-ca-cert"},
{".cryptonote", "application/vnd.rig.cryptonote"},
{".csh", "application/x-csh"},
{".csml", "chemical/x-csml"},
{".csp", "application/vnd.commonspace"},
{".css", "text/css"},
{".cst", "application/x-director"},
{".csv", "text/csv"},
{".cu", "application/cu-seeme"},
{".curl", "text/vnd.curl"},
{".cww", "application/prs.cww"},
{".cxt", "application/x-director"},
{".cxx", "text/x-c"},
{".dae", "model/vnd.collada+xml"},
{".daf", "application/vnd.mobius.daf"},
{".dart", "application/vnd.dart"},
{".dataless", "application/vnd.fdsn.seed"},
{".davmount", "application/davmount+xml"},
{".dbk", "application/docbook+xml"},
{".dcr", "application/x-director"},
{".dcurl", "text/vnd.curl.dcurl"},
{".dd2", "application/vnd.oma.dd2+xml"},
{".ddd", "application/vnd.fujixerox.ddd"},
{".deb", "application/x-debian-package"},
{".def", "text/plain"},
{".deploy", "application/octet-stream"},
{".der", "application/x-x509-ca-cert"},
{".dfac", "application/vnd.dreamfactory"},
{".dgc", "application/x-dgc-compressed"},
{".dic", "text/x-c"},
{".dir", "application/x-director"},
{".dis", "application/vnd.mobius.dis"},
{".dist", "application/octet-stream"},
{".distz", "application/octet-stream"},
{".djv", "image/vnd.djvu"},
{".djvu", "image/vnd.djvu"},
{".dll", "application/x-msdownload"},
{".dmg", "application/x-apple-diskimage"},
{".dmp", "application/vnd.tcpdump.pcap"},
{".dms", "application/octet-stream"},
{".dna", "application/vnd.dna"},
{".docm", "application/vnd.ms-word.document.macroenabled.12"},
{".dot", "application/msword"},
{".dotm", "application/vnd.ms-word.template.macroenabled.12"},
{".dotx", "application/vnd.openxmlformats-officedocument.wordprocessingml.template"},
{".dp", "application/vnd.osgi.dp"},
{".dpg", "application/vnd.dpgraph"},
{".dra", "audio/vnd.dra"},
{".dsc", "text/prs.lines.tag"},
{".dssc", "application/dssc+der"},
{".dtb", "application/x-dtbook+xml"},
{".dtd", "application/xml-dtd"},
{".dts", "audio/vnd.dts"},
{".dtshd", "audio/vnd.dts.hd"},
{".dump", "application/octet-stream"},
{".dvb", "video/vnd.dvb.file"},
{".dvi", "application/x-dvi"},
{".dwf", "model/vnd.dwf"},
{".dwg", "image/vnd.dwg"},
{".dxf", "image/vnd.dxf"},
{".dxp", "application/vnd.spotfire.dxp"},
{".dxr", "application/x-director"},
{".ecelp4800", "audio/vnd.nuera.ecelp4800"},
{".ecelp7470", "audio/vnd.nuera.ecelp7470"},
{".ecelp9600", "audio/vnd.nuera.ecelp9600"},
{".ecma", "application/ecmascript"},
{".edm", "application/vnd.novadigm.edm"},
{".edx", "application/vnd.novadigm.edx"},
{".efif", "application/vnd.picsel"},
{".ei6", "application/vnd.pg.osasli"},
{".elc", "application/octet-stream"},
{".emf", "application/x-msmetafile"},
{".eml", "message/rfc822"},
{".emma", "application/emma+xml"},
{".emz", "application/x-msmetafile"},
{".eol", "audio/vnd.digital-winds"},
{".eot", "application/vnd.ms-fontobject"},
{".eps", "application/postscript"},
{".epub", "application/epub+zip"},
{".es3", "application/vnd.eszigno3+xml"},
{".esa", "application/vnd.osgi.subsystem"},
{".esf", "application/vnd.epson.esf"},
{".et3", "application/vnd.eszigno3+xml"},
{".etx", "text/x-setext"},
{".eva", "application/x-eva"},
{".evy", "application/x-envoy"},
{".exe", "application/x-msdownload"},
{".exi", "application/exi"},
{".ext", "application/vnd.novadigm.ext"},
{".ez", "application/andrew-inset"},
{".ez2", "application/vnd.ezpix-album"},
{".ez3", "application/vnd.ezpix-package"},
{".f", "text/x-fortran"},
{".f4v", "video/x-f4v"},
{".f77", "text/x-fortran"},
{".f90", "text/x-fortran"},
{".fbs", "image/vnd.fastbidsheet"},
{".fcdt", "application/vnd.adobe.formscentral.fcdt"},
{".fcs", "application/vnd.isac.fcs"},
{".fdf", "application/vnd.fdf"},
{".fe_launch", "application/vnd.denovo.fcselayout-link"},
{".fg5", "application/vnd.fujitsu.oasysgp"},
{".fgd", "application/x-director"},
{".fh", "image/x-freehand"},
{".fh4", "image/x-freehand"},
{".fh5", "image/x-freehand"},
{".fh7", "image/x-freehand"},
{".fhc", "image/x-freehand"},
{".fig", "application/x-xfig"},
{".flac", "audio/x-flac"},
{".fli", "video/x-fli"},
{".flo", "application/vnd.micrografx.flo"},
{".flv", "video/x-flv"},
{".flw", "application/vnd.kde.kivio"},
{".flx", "text/vnd.fmi.flexstor"},
{".fly", "text/vnd.fly"},
{".fm", "application/vnd.framemaker"},
{".fnc", "application/vnd.frogans.fnc"},
{".for", "text/x-fortran"},
{".fpx", "image/vnd.fpx"},
{".frame", "application/vnd.framemaker"},
{".fsc", "application/vnd.fsc.weblaunch"},
{".fst", "image/vnd.fst"},
{".ftc", "application/vnd.fluxtime.clip"},
{".fti", "application/vnd.anser-web-funds-transfer-initiation"},
{".fvt", "video/vnd.fvt"},
{".fxp", "application/vnd.adobe.fxp"},
{".fxpl", "application/vnd.adobe.fxp"},
{".fzs", "application/vnd.fuzzysheet"},
{".g2w", "application/vnd.geoplan"},
{".g3", "image/g3fax"},
{".g3w", "application/vnd.geospace"},
{".gac", "application/vnd.groove-account"},
{".gam", "application/x-tads"},
{".gbr", "application/rpki-ghostbusters"},
{".gca", "application/x-gca-compressed"},
{".gdl", "model/vnd.gdl"},
{".geo", "application/vnd.dynageo"},
{".gex", "application/vnd.geometry-explorer"},
{".ggb", "application/vnd.geogebra.file"},
{".ggt", "application/vnd.geogebra.tool"},
{".ghf", "application/vnd.groove-help"},
{".gim", "application/vnd.groove-identity-message"},
{".gml", "application/gml+xml"},
{".gmx", "application/vnd.gmx"},
{".gnumeric", "application/x-gnumeric"},
{".gph", "application/vnd.flographit"},
{".gpx", "application/gpx+xml"},
{".gqf", "application/vnd.grafeq"},
{".gqs", "application/vnd.grafeq"},
{".gram", "application/srgs"},
{".gramps", "application/x-gramps-xml"},
{".gre", "application/vnd.geometry-explorer"},
{".grv", "application/vnd.groove-injector"},
{".grxml", "application/srgs+xml"},
{".gsf", "application/x-font-ghostscript"},
{".gtar", "application/x-gtar"},
{".gtm", "application/vnd.groove-tool-message"},
{".gtw", "model/vnd.gtw"},
{".gv", "text/vnd.graphviz"},
{".gxf", "application/gxf"},
{".gxt", "application/vnd.geonext"},
{".h", "text/x-c"},
{".h261", "video/h261"},
{".h263", "video/h263"},
{".h264", "video/h264"},
{".hal", "application/vnd.hal+xml"},
{".hbci", "application/vnd.hbci"},
{".hdf", "application/x-hdf"},
{".hh", "text/x-c"},
{".hlp", "application/winhlp"},
{".hpgl", "application/vnd.hp-hpgl"},
{".hpid", "application/vnd.hp-hpid"},
{".hps", "application/vnd.hp-hps"},
{".hqx", "application/mac-binhex40"},
{".htke", "application/vnd.kenameaapp"},
{".htm", "text/html"},
{".hvd", "application/vnd.yamaha.hv-dic"},
{".hvp", "application/vnd.yamaha.hv-voice"},
{".hvs", "application/vnd.yamaha.hv-script"},
{".i2g", "application/vnd.intergeo"},
{".icc", "application/vnd.iccprofile"},
{".ice", "x-conference/x-cooltalk"},
{".icm", "application/vnd.iccprofile"},
{".ico", "image/x-icon"},
{".ics", "text/calendar"},
{".ief", "image/ief"},
{".ifb", "text/calendar"},
{".ifm", "application/vnd.shana.informed.formdata"},
{".iges", "model/iges"},
{".igl", "application/vnd.igloader"},
{".igm", "application/vnd.insors.igm"},
{".igs", "model/iges"},
{".igx", "application/vnd.micrografx.igx"},
{".iif", "application/vnd.shana.informed.interchange"},
{".imp", "application/vnd.accpac.simply.imp"},
{".ims", "application/vnd.ms-ims"},
{".in", "text/plain"},
{".ink", "application/inkml+xml"},
{".inkml", "application/inkml+xml"},
{".install", "application/x-install-instructions"},
{".iota", "application/vnd.astraea-software.iota"},
{".ipfix", "application/ipfix"},
{".ipk", "application/vnd.shana.informed.package"},
{".irm", "application/vnd.ibm.rights-management"},
{".irp", "application/vnd.irepository.package+xml"},
{".iso", "application/x-iso9660-image"},
{".itp", "application/vnd.shana.informed.formtemplate"},
{".ivp", "application/vnd.immervision-ivp"},
{".ivu", "application/vnd.immervision-ivu"},
{".jad", "text/vnd.sun.j2me.app-descriptor"},
{".jam", "application/vnd.jam"},
{".jar", "application/java-archive"},
{".java", "text/x-java-source"},
{".jisp", "application/vnd.jisp"},
{".jlt", "application/vnd.hp-jlyt"},
{".jnlp", "application/x-java-jnlp-file"},
{".joda", "application/vnd.joost.joda-archive"},
{".jpe", "image/jpeg"},
{".jpgm", "video/jpm"},
{".jpgv", "video/jpeg"},
{".jpm", "video/jpm"},
{".js", "application/javascript"},
{".json", "application/json"},
{".jsonml", "application/jsonml+json"},
{".kar", "audio/midi"},
{".karbon", "application/vnd.kde.karbon"},
{".kfo", "application/vnd.kde.kformula"},
{".kia", "application/vnd.kidspiration"},
{".kml", "application/vnd.google-earth.kml+xml"},
{".kmz", "application/vnd.google-earth.kmz"},
{".kne", "application/vnd.kinar"},
{".knp", "application/vnd.kinar"},
{".kon", "application/vnd.kde.kontour"},
{".kpr", "application/vnd.kde.kpresenter"},
{".kpt", "application/vnd.kde.kpresenter"},
{".kpxx", "application/vnd.ds-keypoint"},
{".ksp", "application/vnd.kde.kspread"},
{".ktr", "application/vnd.kahootz"},
{".ktx", "image/ktx"},
{".ktz", "application/vnd.kahootz"},
{".kwd", "application/vnd.kde.kword"},
{".kwt", "application/vnd.kde.kword"},
{".lasxml", "application/vnd.las.las+xml"},
{".latex", "application/x-latex"},
{".lbd", "application/vnd.llamagraphics.life-balance.desktop"},
{".lbe", "application/vnd.llamagraphics.life-balance.exchange+xml"},
{".les", "application/vnd.hhe.lesson-player"},
{".lha", "application/x-lzh-compressed"},
{".link66", "application/vnd.route66.link66+xml"},
{".list", "text/plain"},
{".list3820", "application/vnd.ibm.modcap"},
{".listafp", "application/vnd.ibm.modcap"},
{".lnk", "application/x-ms-shortcut"},
{".log", "text/plain"},
{".lostxml", "application/lost+xml"},
{".lrf", "application/octet-stream"},
{".lrm", "application/vnd.ms-lrm"},
{".ltf", "application/vnd.frogans.ltf"},
{".lvp", "audio/vnd.lucent.voice"},
{".lwp", "application/vnd.lotus-wordpro"},
{".lzh", "application/x-lzh-compressed"},
{".m13", "application/x-msmediaview"},
{".m14", "application/x-msmediaview"},
{".m1v", "video/mpeg"},
{".m21", "application/mp21"},
{".m2a", "audio/mpeg"},
{".m2v", "video/mpeg"},
{".m3a", "audio/mpeg"},
{".m3u", "audio/x-mpegurl"},
{".m3u8", "application/vnd.apple.mpegurl"},
{".m4u", "video/vnd.mpegurl"},
{".m4v", "video/x-m4v"},
{".ma", "application/mathematica"},
{".mads", "application/mads+xml"},
{".mag", "application/vnd.ecowin.chart"},
{".maker", "application/vnd.framemaker"},
{".man", "text/troff"},
{".mar", "application/octet-stream"},
{".mathml", "application/mathml+xml"},
{".mb", "application/mathematica"},
{".mbk", "application/vnd.mobius.mbk"},
{".mbox", "application/mbox"},
{".mc1", "application/vnd.medcalcdata"},
{".mcd", "application/vnd.mcd"},
{".mcurl", "text/vnd.curl.mcurl"},
{".mdb", "application/x-msaccess"},
{".mdi", "image/vnd.ms-modi"},
{".me", "text/troff"},
{".mesh", "model/mesh"},
{".meta4", "application/metalink4+xml"},
{".metalink", "application/metalink+xml"},
{".mets", "application/mets+xml"},
{".mfm", "application/vnd.mfmp"},
{".mft", "application/rpki-manifest"},
{".mgp", "application/vnd.osgeo.mapguide.package"},
{".mgz", "application/vnd.proteus.magazine"},
{".mid", "audio/midi"},
{".midi", "audio/midi"},
{".mie", "application/x-mie"},
{".mif", "application/vnd.mif"},
{".mime", "message/rfc822"},
{".mj2", "video/mj2"},
{".mjp2", "video/mj2"},
{".mk3d", "video/x-matroska"},
{".mka", "audio/x-matroska"},
{".mks", "video/x-matroska"},
{".mkv", "video/x-matroska"},
{".mlp", "application/vnd.dolby.mlp"},
{".mmd", "application/vnd.chipnuts.karaoke-mmd"},
{".mmf", "application/vnd.smaf"},
{".mmr", "image/vnd.fujixerox.edmics-mmr"},
{".mng", "video/x-mng"},
{".mny", "application/x-msmoney"},
{".mobi", "application/x-mobipocket-ebook"},
{".mods", "application/mods+xml"},
//{".mov", "video/quicktime"},
{".movie", "video/x-sgi-movie"},
{".mp2", "audio/mpeg"},
{".mp21", "application/mp21"},
{".mp2a", "audio/mpeg"},
//{".mp3", "audio/mpeg"},
//{".mp4", "video/mp4"},
{".mp4a", "audio/mp4"},
{".mp4s", "application/mp4"},
{".mp4v", "video/mp4"},
{".mpc", "application/vnd.mophun.certificate"},
{".mpe", "video/mpeg"},
{".mpeg", "video/mpeg"},
{".mpg", "video/mpeg"},
{".mpg4", "video/mp4"},
{".mpga", "audio/mpeg"},
{".mpkg", "application/vnd.apple.installer+xml"},
{".mpm", "application/vnd.blueice.multipass"},
{".mpn", "application/vnd.mophun.application"},
{".mpp", "application/vnd.ms-project"},
{".mpt", "application/vnd.ms-project"},
{".mpy", "application/vnd.ibm.minipay"},
{".mqy", "application/vnd.mobius.mqy"},
{".mrc", "application/marc"},
{".mrcx", "application/marcxml+xml"},
{".ms", "text/troff"},
{".mscml", "application/mediaservercontrol+xml"},
{".mseed", "application/vnd.fdsn.mseed"},
{".mseq", "application/vnd.mseq"},
{".msf", "application/vnd.epson.msf"},
{".msh", "model/mesh"},
{".msi", "application/x-msdownload"},
{".msl", "application/vnd.mobius.msl"},
{".msty", "application/vnd.muvee.style"},
{".mts", "model/vnd.mts"},
{".mus", "application/vnd.musician"},
{".musicxml", "application/vnd.recordare.musicxml+xml"},
{".mvb", "application/x-msmediaview"},
{".mwf", "application/vnd.mfer"},
{".mxf", "application/mxf"},
{".mxl", "application/vnd.recordare.musicxml"},
{".mxml", "application/xv+xml"},
{".mxs", "application/vnd.triscape.mxs"},
{".mxu", "video/vnd.mpegurl"},
{".n-gage", "application/vnd.nokia.n-gage.symbian.install"},
{".n3", "text/n3"},
{".nb", "application/mathematica"},
{".nbp", "application/vnd.wolfram.player"},
{".nc", "application/x-netcdf"},
{".ncx", "application/x-dtbncx+xml"},
{".nfo", "text/x-nfo"},
{".ngdat", "application/vnd.nokia.n-gage.data"},
{".nitf", "application/vnd.nitf"},
{".nlu", "application/vnd.neurolanguage.nlu"},
{".nml", "application/vnd.enliven"},
{".nnd", "application/vnd.noblenet-directory"},
{".nns", "application/vnd.noblenet-sealer"},
{".nnw", "application/vnd.noblenet-web"},
{".npx", "image/vnd.net-fpx"},
{".nsc", "application/x-conference"},
{".nsf", "application/vnd.lotus-notes"},
{".ntf", "application/vnd.nitf"},
{".nzb", "application/x-nzb"},
{".oa2", "application/vnd.fujitsu.oasys2"},
{".oa3", "application/vnd.fujitsu.oasys3"},
{".oas", "application/vnd.fujitsu.oasys"},
{".obd", "application/x-msbinder"},
{".obj", "application/x-tgif"},
{".oda", "application/oda"},
{".odb", "application/vnd.oasis.opendocument.database"},
{".odc", "application/vnd.oasis.opendocument.chart"},
{".odf", "application/vnd.oasis.opendocument.formula"},
{".odft", "application/vnd.oasis.opendocument.formula-template"},
{".odg", "application/vnd.oasis.opendocument.graphics"},
{".odi", "application/vnd.oasis.opendocument.image"},
{".odm", "application/vnd.oasis.opendocument.text-master"},
{".odp", "application/vnd.oasis.opendocument.presentation"},
{".ods", "application/vnd.oasis.opendocument.spreadsheet"},
{".odt", "application/vnd.oasis.opendocument.text"},
{".oga", "audio/ogg"},
{".ogg", "audio/ogg"},
{".ogv", "video/ogg"},
{".ogx", "application/ogg"},
{".omdoc", "application/omdoc+xml"},
{".onepkg", "application/onenote"},
{".onetmp", "application/onenote"},
{".onetoc", "application/onenote"},
{".onetoc2", "application/onenote"},
{".opf", "application/oebps-package+xml"},
{".opml", "text/x-opml"},
{".oprc", "application/vnd.palm"},
{".org", "application/vnd.lotus-organizer"},
{".osf", "application/vnd.yamaha.openscoreformat"},
{".osfpvg", "application/vnd.yamaha.openscoreformat.osfpvg+xml"},
{".otc", "application/vnd.oasis.opendocument.chart-template"},
{".otf", "application/x-font-otf"},
{".otg", "application/vnd.oasis.opendocument.graphics-template"},
{".oth", "application/vnd.oasis.opendocument.text-web"},
{".oti", "application/vnd.oasis.opendocument.image-template"},
{".otp", "application/vnd.oasis.opendocument.presentation-template"},
{".ots", "application/vnd.oasis.opendocument.spreadsheet-template"},
{".ott", "application/vnd.oasis.opendocument.text-template"},
{".oxps", "application/oxps"},
{".oxt", "application/vnd.openofficeorg.extension"},
{".p", "text/x-pascal"},
{".p10", "application/pkcs10"},
{".p12", "application/x-pkcs12"},
{".p7b", "application/x-pkcs7-certificates"},
{".p7c", "application/pkcs7-mime"},
{".p7m", "application/pkcs7-mime"},
{".p7r", "application/x-pkcs7-certreqresp"},
{".p7s", "application/pkcs7-signature"},
{".p8", "application/pkcs8"},
{".pas", "text/x-pascal"},
{".paw", "application/vnd.pawaafile"},
{".pbd", "application/vnd.powerbuilder6"},
{".pbm", "image/x-portable-bitmap"},
{".pcap", "application/vnd.tcpdump.pcap"},
{".pcf", "application/x-font-pcf"},
{".pcl", "application/vnd.hp-pcl"},
{".pclxl", "application/vnd.hp-pclxl"},
{".pct", "image/x-pict"},
{".pcurl", "application/vnd.curl.pcurl"},
{".pcx", "image/x-pcx"},
{".pdb", "application/vnd.palm"},
{".pfa", "application/x-font-type1"},
{".pfb", "application/x-font-type1"},
{".pfm", "application/x-font-type1"},
{".pfr", "application/font-tdpfr"},
{".pfx", "application/x-pkcs12"},
{".pgm", "image/x-portable-graymap"},
{".pgn", "application/x-chess-pgn"},
{".pgp", "application/pgp-encrypted"},
{".pic", "image/x-pict"},
{".pkg", "application/octet-stream"},
{".pki", "application/pkixcmp"},
{".pkipath", "application/pkix-pkipath"},
{".plb", "application/vnd.3gpp.pic-bw-large"},
{".plc", "application/vnd.mobius.plc"},
{".plf", "application/vnd.pocketlearn"},
{".pls", "application/pls+xml"},
{".pml", "application/vnd.ctc-posml"},
{".pnm", "image/x-portable-anymap"},
{".portpkg", "application/vnd.macports.portpkg"},
{".pot", "application/vnd.ms-powerpoint"},
{".potm", "application/vnd.ms-powerpoint.template.macroenabled.12"},
{".potx", "application/vnd.openxmlformats-officedocument.presentationml.template"},
{".ppam", "application/vnd.ms-powerpoint.addin.macroenabled.12"},
{".ppd", "application/vnd.cups-ppd"},
{".ppm", "image/x-portable-pixmap"},
{".pps", "application/vnd.ms-powerpoint"},
{".ppsm", "application/vnd.ms-powerpoint.slideshow.macroenabled.12"},
{".ppsx", "application/vnd.openxmlformats-officedocument.presentationml.slideshow"},
{".pptm", "application/vnd.ms-powerpoint.presentation.macroenabled.12"},
{".pqa", "application/vnd.palm"},
{".prc", "application/x-mobipocket-ebook"},
{".pre", "application/vnd.lotus-freelance"},
{".prf", "application/pics-rules"},
{".ps", "application/postscript"},
{".psb", "application/vnd.3gpp.pic-bw-small"},
{".psd", "image/vnd.adobe.photoshop"},
{".psf", "application/x-font-linux-psf"},
{".pskcxml", "application/pskc+xml"},
{".ptid", "application/vnd.pvi.ptid1"},
{".pub", "application/x-mspublisher"},
{".pvb", "application/vnd.3gpp.pic-bw-var"},
{".pwn", "application/vnd.3m.post-it-notes"},
{".pya", "audio/vnd.ms-playready.media.pya"},
{".pyv", "video/vnd.ms-playready.media.pyv"},
{".qam", "application/vnd.epson.quickanime"},
{".qbo", "application/vnd.intu.qbo"},
{".qfx", "application/vnd.intu.qfx"},
{".qps", "application/vnd.publishare-delta-tree"},
{".qt", "video/quicktime"},
{".qwd", "application/vnd.quark.quarkxpress"},
{".qwt", "application/vnd.quark.quarkxpress"},
{".qxb", "application/vnd.quark.quarkxpress"},
{".qxd", "application/vnd.quark.quarkxpress"},
{".qxl", "application/vnd.quark.quarkxpress"},
{".qxt", "application/vnd.quark.quarkxpress"},
{".ra", "audio/x-pn-realaudio"},
{".ram", "audio/x-pn-realaudio"},
{".rar", "application/x-rar-compressed"},
{".ras", "image/x-cmu-raster"},
{".rcprofile", "application/vnd.ipunplugged.rcprofile"},
{".rdf", "application/rdf+xml"},
{".rdz", "application/vnd.data-vision.rdz"},
{".rep", "application/vnd.businessobjects"},
{".res", "application/x-dtbresource+xml"},
{".rgb", "image/x-rgb"},
{".rif", "application/reginfo+xml"},
{".rip", "audio/vnd.rip"},
{".ris", "application/x-research-info-systems"},
{".rl", "application/resource-lists+xml"},
{".rlc", "image/vnd.fujixerox.edmics-rlc"},
{".rld", "application/resource-lists-diff+xml"},
{".rm", "application/vnd.rn-realmedia"},
{".rmi", "audio/midi"},
{".rmp", "audio/x-pn-realaudio-plugin"},
{".rms", "application/vnd.jcp.javame.midlet-rms"},
{".rmvb", "application/vnd.rn-realmedia-vbr"},
{".rnc", "application/relax-ng-compact-syntax"},
{".roa", "application/rpki-roa"},
{".roff", "text/troff"},
{".rp9", "application/vnd.cloanto.rp9"},
{".rpss", "application/vnd.nokia.radio-presets"},
{".rpst", "application/vnd.nokia.radio-preset"},
{".rq", "application/sparql-query"},
{".rs", "application/rls-services+xml"},
{".rsd", "application/rsd+xml"},
{".rss", "application/rss+xml"},
{".rtf", "application/rtf"},
{".rtx", "text/richtext"},
{".s", "text/x-asm"},
{".s3m", "audio/s3m"},
{".saf", "application/vnd.yamaha.smaf-audio"},
{".sbml", "application/sbml+xml"},
{".sc", "application/vnd.ibm.secure-container"},
{".scd", "application/x-msschedule"},
{".scm", "application/vnd.lotus-screencam"},
{".scq", "application/scvp-cv-request"},
{".scs", "application/scvp-cv-response"},
{".scurl", "text/vnd.curl.scurl"},
{".sda", "application/vnd.stardivision.draw"},
{".sdc", "application/vnd.stardivision.calc"},
{".sdd", "application/vnd.stardivision.impress"},
{".sdkd", "application/vnd.solent.sdkm+xml"},
{".sdkm", "application/vnd.solent.sdkm+xml"},
{".sdp", "application/sdp"},
{".sdw", "application/vnd.stardivision.writer"},
{".see", "application/vnd.seemail"},
{".seed", "application/vnd.fdsn.seed"},
{".sema", "application/vnd.sema"},
{".semd", "application/vnd.semd"},
{".semf", "application/vnd.semf"},
{".ser", "application/java-serialized-object"},
{".setpay", "application/set-payment-initiation"},
{".setreg", "application/set-registration-initiation"},
{".sfd-hdstx", "application/vnd.hydrostatix.sof-data"},
{".sfs", "application/vnd.spotfire.sfs"},
{".sfv", "text/x-sfv"},
{".sgi", "image/sgi"},
{".sgl", "application/vnd.stardivision.writer-global"},
{".sgm", "text/sgml"},
{".sgml", "text/sgml"},
{".sh", "application/x-sh"},
{".shar", "application/x-shar"},
{".shf", "application/shf+xml"},
{".sid", "image/x-mrsid-image"},
{".sig", "application/pgp-signature"},
{".sil", "audio/silk"},
{".silo", "model/mesh"},
{".sis", "application/vnd.symbian.install"},
{".sisx", "application/vnd.symbian.install"},
{".sit", "application/x-stuffit"},
{".sitx", "application/x-stuffitx"},
{".skd", "application/vnd.koan"},
{".skm", "application/vnd.koan"},
{".skp", "application/vnd.koan"},
{".skt", "application/vnd.koan"},
{".sldm", "application/vnd.ms-powerpoint.slide.macroenabled.12"},
{".sldx", "application/vnd.openxmlformats-officedocument.presentationml.slide"},
{".slt", "application/vnd.epson.salt"},
{".sm", "application/vnd.stepmania.stepchart"},
{".smf", "application/vnd.stardivision.math"},
{".smi", "application/smil+xml"},
{".smil", "application/smil+xml"},
{".smv", "video/x-smv"},
{".smzip", "application/vnd.stepmania.package"},
{".snd", "audio/basic"},
{".snf", "application/x-font-snf"},
{".so", "application/octet-stream"},
{".spc", "application/x-pkcs7-certificates"},
{".spf", "application/vnd.yamaha.smaf-phrase"},
{".spl", "application/x-futuresplash"},
{".spot", "text/vnd.in3d.spot"},
{".spp", "application/scvp-vp-response"},
{".spq", "application/scvp-vp-request"},
{".spx", "audio/ogg"},
{".sql", "application/x-sql"},
{".src", "application/x-wais-source"},
{".srt", "application/x-subrip"},
{".sru", "application/sru+xml"},
{".srx", "application/sparql-results+xml"},
{".ssdl", "application/ssdl+xml"},
{".sse", "application/vnd.kodak-descriptor"},
{".ssf", "application/vnd.epson.ssf"},
{".ssml", "application/ssml+xml"},
{".st", "application/vnd.sailingtracker.track"},
{".stc", "application/vnd.sun.xml.calc.template"},
{".std", "application/vnd.sun.xml.draw.template"},
{".stf", "application/vnd.wt.stf"},
{".sti", "application/vnd.sun.xml.impress.template"},
{".stk", "application/hyperstudio"},
{".stl", "application/vnd.ms-pki.stl"},
{".str", "application/vnd.pg.format"},
{".stw", "application/vnd.sun.xml.writer.template"},
{".sub", "text/vnd.dvb.subtitle"},
{".sus", "application/vnd.sus-calendar"},
{".susp", "application/vnd.sus-calendar"},
{".sv4cpio", "application/x-sv4cpio"},
{".sv4crc", "application/x-sv4crc"},
{".svc", "application/vnd.dvb.service"},
{".svd", "application/vnd.svd"},
{".svg", "image/svg+xml"},
{".svgz", "image/svg+xml"},
{".swa", "application/x-director"},
{".swf", "application/x-shockwave-flash"},
{".swi", "application/vnd.aristanetworks.swi"},
{".sxc", "application/vnd.sun.xml.calc"},
{".sxd", "application/vnd.sun.xml.draw"},
{".sxg", "application/vnd.sun.xml.writer.global"},
{".sxi", "application/vnd.sun.xml.impress"},
{".sxm", "application/vnd.sun.xml.math"},
{".sxw", "application/vnd.sun.xml.writer"},
{".t", "text/troff"},
{".t3", "application/x-t3vm-image"},
{".taglet", "application/vnd.mynfc"},
{".tao", "application/vnd.tao.intent-module-archive"},
{".tar", "application/x-tar"},
{".tcap", "application/vnd.3gpp2.tcap"},
{".tcl", "application/x-tcl"},
{".teacher", "application/vnd.smart.teacher"},
{".tei", "application/tei+xml"},
{".teicorpus", "application/tei+xml"},
{".tex", "application/x-tex"},
{".texi", "application/x-texinfo"},
{".texinfo", "application/x-texinfo"},
{".text", "text/plain"},
{".tfi", "application/thraud+xml"},
{".tfm", "application/x-tex-tfm"},
{".tga", "image/x-tga"},
{".thmx", "application/vnd.ms-officetheme"},
{".tif", "image/tiff"},
{".tiff", "image/tiff"},
{".tmo", "application/vnd.tmobile-livetv"},
{".torrent", "application/x-bittorrent"},
{".tpl", "application/vnd.groove-tool-template"},
{".tpt", "application/vnd.trid.tpt"},
{".tr", "text/troff"},
{".tra", "application/vnd.trueapp"},
{".trm", "application/x-msterminal"},
{".tsd", "application/timestamped-data"},
{".tsv", "text/tab-separated-values"},
{".ttc", "application/x-font-ttf"},
{".ttf", "application/x-font-ttf"},
{".ttl", "text/turtle"},
{".twd", "application/vnd.simtech-mindmapper"},
{".twds", "application/vnd.simtech-mindmapper"},
{".txd", "application/vnd.genomatix.tuxedo"},
{".txf", "application/vnd.mobius.txf"},
{".u32", "application/x-authorware-bin"},
{".udeb", "application/x-debian-package"},
{".ufd", "application/vnd.ufdl"},
{".ufdl", "application/vnd.ufdl"},
{".ulx", "application/x-glulx"},
{".umj", "application/vnd.umajin"},
{".unityweb", "application/vnd.unity"},
{".uoml", "application/vnd.uoml+xml"},
{".uri", "text/uri-list"},
{".uris", "text/uri-list"},
{".urls", "text/uri-list"},
{".ustar", "application/x-ustar"},
{".utz", "application/vnd.uiq.theme"},
{".uu", "text/x-uuencode"},
{".uva", "audio/vnd.dece.audio"},
{".uvd", "application/vnd.dece.data"},
{".uvf", "application/vnd.dece.data"},
{".uvg", "image/vnd.dece.graphic"},
{".uvh", "video/vnd.dece.hd"},
{".uvi", "image/vnd.dece.graphic"},
{".uvm", "video/vnd.dece.mobile"},
{".uvp", "video/vnd.dece.pd"},
{".uvs", "video/vnd.dece.sd"},
{".uvt", "application/vnd.dece.ttml+xml"},
{".uvu", "video/vnd.uvvu.mp4"},
{".uvv", "video/vnd.dece.video"},
{".uvva", "audio/vnd.dece.audio"},
{".uvvd", "application/vnd.dece.data"},
{".uvvf", "application/vnd.dece.data"},
{".uvvg", "image/vnd.dece.graphic"},
{".uvvh", "video/vnd.dece.hd"},
{".uvvi", "image/vnd.dece.graphic"},
{".uvvm", "video/vnd.dece.mobile"},
{".uvvp", "video/vnd.dece.pd"},
{".uvvs", "video/vnd.dece.sd"},
{".uvvt", "application/vnd.dece.ttml+xml"},
{".uvvu", "video/vnd.uvvu.mp4"},
{".uvvv", "video/vnd.dece.video"},
{".uvvx", "application/vnd.dece.unspecified"},
{".uvvz", "application/vnd.dece.zip"},
{".uvx", "application/vnd.dece.unspecified"},
{".uvz", "application/vnd.dece.zip"},
{".vcard", "text/vcard"},
{".vcd", "application/x-cdlink"},
{".vcf", "text/x-vcard"},
{".vcg", "application/vnd.groove-vcard"},
{".vcs", "text/x-vcalendar"},
{".vcx", "application/vnd.vcx"},
{".vis", "application/vnd.visionary"},
{".viv", "video/vnd.vivo"},
{".vob", "video/x-ms-vob"},
{".vor", "application/vnd.stardivision.writer"},
{".vox", "application/x-authorware-bin"},
{".vrml", "model/vrml"},
{".vsd", "application/vnd.visio"},
{".vsf", "application/vnd.vsf"},
{".vss", "application/vnd.visio"},
{".vst", "application/vnd.visio"},
{".vsw", "application/vnd.visio"},
{".vtu", "model/vnd.vtu"},
{".vxml", "application/voicexml+xml"},
{".w3d", "application/x-director"},
{".wad", "application/x-doom"},
{".wav", "audio/x-wav"},
{".wax", "audio/x-ms-wax"},
{".wbmp", "image/vnd.wap.wbmp"},
{".wbs", "application/vnd.criticaltools.wbs+xml"},
{".wbxml", "application/vnd.wap.wbxml"},
{".wcm", "application/vnd.ms-works"},
{".wdb", "application/vnd.ms-works"},
{".wdp", "image/vnd.ms-photo"},
{".weba", "audio/webm"},
{".webm", "video/webm"},
{".webp", "image/webp"},
{".wg", "application/vnd.pmi.widget"},
{".wgt", "application/widget"},
{".wks", "application/vnd.ms-works"},
{".wm", "video/x-ms-wm"},
{".wma", "audio/x-ms-wma"},
{".wmd", "application/x-ms-wmd"},
{".wmf", "application/x-msmetafile"},
{".wml", "text/vnd.wap.wml"},
{".wmlc", "application/vnd.wap.wmlc"},
{".wmls", "text/vnd.wap.wmlscript"},
{".wmlsc", "application/vnd.wap.wmlscriptc"},
{".wmv", "video/x-ms-wmv"},
{".wmx", "video/x-ms-wmx"},
{".wmz", "application/x-msmetafile"},
{".woff", "application/font-woff"},
{".wpd", "application/vnd.wordperfect"},
{".wpl", "application/vnd.ms-wpl"},
{".wps", "application/vnd.ms-works"},
{".wqd", "application/vnd.wqd"},
{".wri", "application/x-mswrite"},
{".wrl", "model/vrml"},
{".wsdl", "application/wsdl+xml"},
{".wspolicy", "application/wspolicy+xml"},
{".wtb", "application/vnd.webturbo"},
{".wvx", "video/x-ms-wvx"},
{".x32", "application/x-authorware-bin"},
{".x3d", "model/x3d+xml"},
{".x3db", "model/x3d+binary"},
{".x3dbz", "model/x3d+binary"},
{".x3dv", "model/x3d+vrml"},
{".x3dvz", "model/x3d+vrml"},
{".x3dz", "model/x3d+xml"},
{".xaml", "application/xaml+xml"},
{".xap", "application/x-silverlight-app"},
{".xar", "application/vnd.xara"},
{".xbap", "application/x-ms-xbap"},
{".xbd", "application/vnd.fujixerox.docuworks.binder"},
{".xbm", "image/x-xbitmap"},
{".xdf", "application/xcap-diff+xml"},
{".xdm", "application/vnd.syncml.dm+xml"},
{".xdp", "application/vnd.adobe.xdp+xml"},
{".xdssc", "application/dssc+xml"},
{".xdw", "application/vnd.fujixerox.docuworks"},
{".xenc", "application/xenc+xml"},
{".xer", "application/patch-ops-error+xml"},
{".xfdf", "application/vnd.adobe.xfdf"},
{".xfdl", "application/vnd.xfdl"},
{".xht", "application/xhtml+xml"},
{".xhtml", "application/xhtml+xml"},
{".xhvml", "application/xv+xml"},
{".xif", "image/vnd.xiff"},
{".xla", "application/vnd.ms-excel"},
{".xlam", "application/vnd.ms-excel.addin.macroenabled.12"},
{".xlc", "application/vnd.ms-excel"},
{".xlf", "application/x-xliff+xml"},
{".xlm", "application/vnd.ms-excel"},
{".xlsb", "application/vnd.ms-excel.sheet.binary.macroenabled.12"},
{".xlsm", "application/vnd.ms-excel.sheet.macroenabled.12"},
{".xlt", "application/vnd.ms-excel"},
{".xltm", "application/vnd.ms-excel.template.macroenabled.12"},
{".xltx", "application/vnd.openxmlformats-officedocument.spreadsheetml.template"},
{".xlw", "application/vnd.ms-excel"},
{".xm", "audio/xm"},
{".xml", "application/xml"},
{".xo", "application/vnd.olpc-sugar"},
{".xop", "application/xop+xml"},
{".xpi", "application/x-xpinstall"},
{".xpl", "application/xproc+xml"},
{".xpm", "image/x-xpixmap"},
{".xpr", "application/vnd.is-xpr"},
{".xps", "application/vnd.ms-xpsdocument"},
{".xpw", "application/vnd.intercon.formnet"},
{".xpx", "application/vnd.intercon.formnet"},
{".xsl", "application/xml"},
{".xslt", "application/xslt+xml"},
{".xsm", "application/vnd.syncml+xml"},
{".xspf", "application/xspf+xml"},
{".xul", "application/vnd.mozilla.xul+xml"},
{".xvm", "application/xv+xml"},
{".xvml", "application/xv+xml"},
{".xwd", "image/x-xwindowdump"},
{".xyz", "chemical/x-xyz"},
{".xz", "application/x-xz"},
{".yang", "application/yang"},
{".yin", "application/yin+xml"},
{".z1", "application/x-zmachine"},
{".z2", "application/x-zmachine"},
{".z3", "application/x-zmachine"},
{".z4", "application/x-zmachine"},
{".z5", "application/x-zmachine"},
{".z6", "application/x-zmachine"},
{".z7", "application/x-zmachine"},
{".z8", "application/x-zmachine"},
{".zaz", "application/vnd.zzazz.deck+xml"},
{".zir", "application/vnd.zul"},
{".zirz", "application/vnd.zul"},
                };
    }
}