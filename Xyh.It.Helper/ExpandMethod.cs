using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Xyh.It.Helper
{
    /// <summary>
    ///     扩展方法类
    /// </summary>
    public static class ExpandMethod
    {
        #region 各类数据类型的扩展方法

        public static string ToChar16(this Guid guid)
        {
            long i = guid.ToByteArray().Aggregate<byte, long>(1, (current, b) => current * ((int)b + 1));
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }

        /// <summary>
        ///     将时间转换为yyyy-MM-dd HH:mm:ss.fff格式的字符串
        /// </summary>
        /// <param name="dt">时间</param>
        /// <param name="DateLenth">长度</param>
        /// <returns>yyyy-MM-dd HH:mm:ss.fff格式的字符串</returns>
        public static string ToStringBit23(this DateTime dt, int DateLenth = 23)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss.fff").Substring(0, (DateLenth == 0 ? 23 : DateLenth));
        }/// <summary>
        ///     将时间转换为yyyy-MM-dd HH:mm:ss.fff格式的字符串
        /// </summary>
        /// <param name="dt">时间</param>
        /// <param name="DateLenth">长度</param>
        /// <returns>yyyy-MM-dd HH:mm:ss.fff格式的字符串</returns>
        public static string ToStringBit20(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss.fff").Substring(0, 19);
        }

        public static string ToStringBit10(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss.fff").Substring(0, 10);
        }

        /// <summary>  
        /// 得到本周第一天(以星期天为第一天)  
        /// </summary>  
        /// <param name="datetime"></param>  
        /// <returns></returns>  
        public static DateTime GetWeekFirstDaySun(this DateTime datetime)
        {
            //星期天为第一天  
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            int daydiff = (-1) * weeknow;

            //本周第一天  
            string FirstDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(FirstDay);
        }

        /// <summary>  
        /// 得到本周第一天(以星期一为第一天)  
        /// </summary>  
        /// <param name="datetime"></param>  
        /// <returns></returns>  
        public static DateTime GetWeekFirstDayMon(this DateTime datetime)
        {
            //星期一为第一天  
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);

            //因为是以星期一为第一天，所以要判断weeknow等于0时，要向前推6天。  
            weeknow = (weeknow == 0 ? (7 - 1) : (weeknow - 1));
            int daydiff = (-1) * weeknow;

            //本周第一天  
            string FirstDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(FirstDay);
        }

        /// <summary>  
        /// 得到本周最后一天(以星期六为最后一天)  
        /// </summary>  
        /// <param name="datetime"></param>  
        /// <returns></returns>  
        public static DateTime GetWeekLastDaySat(this DateTime datetime)
        {
            //星期六为最后一天  
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            int daydiff = (7 - weeknow) - 1;

            //本周最后一天  
            string LastDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(LastDay);
        }

        /// <summary>  
        /// 得到本周最后一天(以星期天为最后一天)  
        /// </summary>  
        /// <param name="datetime"></param>  
        /// <returns></returns>  
        public static DateTime GetWeekLastDaySun(this DateTime datetime)
        {
            //星期天为最后一天  
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            weeknow = (weeknow == 0 ? 7 : weeknow);
            int daydiff = (7 - weeknow);

            //本周最后一天  
            string LastDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
            return Convert.ToDateTime(LastDay);
        }

        /// <summary>
        /// 计算两个日期之间的差距
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="diffType"></param>
        /// <returns></returns>
        public static int DateDiff(this DateTime min, DateTime max, DateDiffType diffType)
        {
            int value = 0;
            switch (diffType)
            {
                case DateDiffType.Y:
                    value = max.Year - min.Year;
                    break;
                case DateDiffType.M:
                    value = (max.Year - min.Year) * 12 + max.Month - min.Month;
                    break;
            }

            return value;
        }

        public enum DateDiffType
        {
            Y = 0,
            M = 1
        }

        /// <summary>
        ///     如果decimal类型为null或空
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this decimal? obj)
        {
            if (obj != null && !obj.Equals(""))
            {
                return Convert.ToDecimal(obj.ToString());
            }
            return 0.00m;
        }

        /// <summary>
        ///     decimal 类型四舍五入取整
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static decimal SiSheWuRuForInt(this decimal num)
        {
            return decimal.Truncate(num + 0.5m);
        }

        /// <summary>
        ///     string  转 decimal
        /// </summary>
        /// <param name="MoneyObj"></param>
        /// <returns></returns>
        public static string ToStringDecimal(this object MoneyObj)
        {
            var newMoney = 0.00m;
            if (MoneyObj != null && MoneyObj.ToString() != "")
            {
                decimal.TryParse(MoneyObj.ToString(), out newMoney);
            }
            return newMoney.ToString("0.00");
        }

        /// <summary>
        ///     判断列表是否为空
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="t">数据</param>
        /// <returns>true:不为空，false:空</returns>
        public static bool IsNotNull<T>(this List<T> t)
        {
            if (t != null && t.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     判断列表是否为空
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="t">数据</param>
        /// <returns>true:不为空，false:空</returns>
        public static bool IsNotNull<T>(this IList<T> t)
        {
            if (t != null && t.Count > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     如果集合不为空并且包含元素则执行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="action"></param>
        public static void NotNullAndAny<T>(this List<T> t, Action<List<T>> action)
        {
            if (t != null && t.Any())
            {
                action(t);
            }
        }

        /// <summary>
        ///     如果集合不为空并且包含元素则执行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="action"></param>
        public static void NotNullAndAny<T>(this List<T> t, Action action)
        {
            if (t != null && t.Any())
            {
                action();
            }
        }

        /// <summary>
        ///     泛型转ArrayList
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="tList">泛型</param>
        /// <returns>ArrayList</returns>
        public static ArrayList ToArrayList<T>(this List<T> tList)
        {
            var al = new ArrayList();
            foreach (var item in tList)
            {
                al.Add(item);
            }
            return al;
        }

        /// <summary>
        ///     IList泛型转JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        /// <returns></returns>
        public static string ToJson<T>(this IList<T> tList)
        {
            if (tList != null)
            {
                return JsonHelper.SerializeObject(tList);
            }
            return "";
        }

        /// <summary>
        ///     对象转JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string ToJson<T>(this T t)
        {
            if (t != null) return JsonHelper.SerializeObject(t);
            return "";
        }

        /// <summary>
        ///     字符串不是null或者空的情况下执行
        /// </summary>
        /// <param name="str"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static void NotNullOrEmpty(this string str, Action action)
        {
            if (!string.IsNullOrEmpty(str))
            {
                action();
            }
        }

        /// <summary>
        ///     字符串不是null或者空的情况下执行
        /// </summary>
        /// <param name="str"></param>
        /// <param name="action"></param>
        public static void NotNullOrEmpty(this string str, Action<string> action)
        {
            if (!string.IsNullOrEmpty(str))
            {
                action(str);
            }
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        ///     如果是true执行的扩展方法
        /// </summary>
        /// <param name="isTrue"></param>
        /// <param name="action"></param>
        public static void IsTrue(this bool isTrue, Action action)
        {
            if (isTrue)
            {
                action();
            }
        }

        /// <summary>
        ///     False时执行的扩展方法
        /// </summary>
        /// <param name="isFalse"></param>
        /// <param name="action"></param>
        public static void IsFalse(this bool isFalse, Action action)
        {
            (!isFalse).IsTrue(action);
        }

        /// <summary>
        ///     xml属性扩展方法
        /// </summary>
        /// <param name="attr"></param>
        /// <param name="action"></param>
        public static void NotNull(this XmlAttribute attr, Action<XmlAttribute> action)
        {
            if (attr != null)
            {
                action(attr);
            }
        }

        #endregion
    }
}