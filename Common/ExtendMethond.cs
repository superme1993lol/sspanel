using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace System
{
    public static class ExtendMethond
    {

        #region decimal扩展
        /// <summary>
        /// 将小写数字转换成中文大写
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string CmycurD(this decimal num)
        {
            string str1 = "零壹贰叁肆伍陆柒捌玖";               //0-9所对应的汉字
            string str2 = "万仟佰拾亿仟佰拾万仟佰拾元角分";     //数字位所对应的汉字
            string str3 = "";                                   //从原num值中取出的值
            string str4 = "";                                   //数字的字符串形式
            string str5 = "";                                   //人民币大写金额形式
            int j;                                              //num的值乘以100的字符串长度
            string ch1 = "";                                    //数字的汉语读法
            string ch2 = "";                                    //数字位的汉字读法
            int nzero = 0;                                      //用来计算连续的零值是几个
            int temp;                                           //从原num值中取出的值


            num = Math.Round(Math.Abs(num), 2);                 //将num取绝对值并四舍五入取2位小数
            str4 = ((long)(num * 100)).ToString();              //将num乘100并转换成字符串形式
            j = str4.Length;                                    //找出最高位
            if (j > 15)
            {
                return "溢出";
            }
            str2 = str2.Substring(15 - j);                      //取出对应位数的str2的值。如：200.55,j为5所以str2=佰拾元角分


            //循环取出每一位需要转换的值
            for (int i = 0; i < j; i++)
            {
                str3 = str4.Substring(i, 1);                    //取出需转换的某一位的值
                temp = Convert.ToInt32(str3);                   //转换为数字         
                if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
                {
                    //当所取位数不为元、万、亿、万亿上的数字时
                    if (str3 == "0")
                    {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    }
                    else
                    {
                        if (str3 != "0" && nzero != 0)
                        {
                            ch1 = "零" + str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                    }
                }
                else
                {
                    //该位是万亿，亿，万，元位等关键位
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 != "0" && nzero == 0)
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            if (str3 == "0" && nzero >= 3)
                            {
                                ch1 = "";
                                ch2 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                if (j >= 11)
                                {
                                    ch1 = "";
                                    nzero = nzero + 1;
                                }
                                else
                                {
                                    ch1 = "";
                                    ch2 = str2.Substring(i, 1);
                                    nzero = nzero + 1;
                                }
                            }
                        }
                    }
                }
                if (i == (j - 11) || i == (j - 3))
                {
                    //如果该位是亿位或元位，则必须写上
                    ch2 = str2.Substring(i, 1);
                }
                str5 = str5 + ch1 + ch2;
                if (i == j - 1 && str3 == "0")
                {
                    //最后一位（分）为0时，加上“整”
                    str5 = str5 + '整';
                }
            }
            if (num == 0)
            {
                str5 = "零元整";
            }
            return str5;
        }

       

        /// <summary>
        /// 将小写数字转换成中文大写
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string CmycurD(this double num)
        {
            string str1 = "零壹贰叁肆伍陆柒捌玖";               //0-9所对应的汉字
            string str2 = "万仟佰拾亿仟佰拾万仟佰拾元角分";     //数字位所对应的汉字
            string str3 = "";                                   //从原num值中取出的值
            string str4 = "";                                   //数字的字符串形式
            string str5 = "";                                   //人民币大写金额形式
            int j;                                              //num的值乘以100的字符串长度
            string ch1 = "";                                    //数字的汉语读法
            string ch2 = "";                                    //数字位的汉字读法
            int nzero = 0;                                      //用来计算连续的零值是几个
            int temp;                                           //从原num值中取出的值


            num = Math.Round(Math.Abs(num), 2);                 //将num取绝对值并四舍五入取2位小数
            str4 = ((long)(num * 100)).ToString();              //将num乘100并转换成字符串形式
            j = str4.Length;                                    //找出最高位
            if (j > 15)
            {
                return "溢出";
            }
            str2 = str2.Substring(15 - j);                      //取出对应位数的str2的值。如：200.55,j为5所以str2=佰拾元角分


            //循环取出每一位需要转换的值
            for (int i = 0; i < j; i++)
            {
                str3 = str4.Substring(i, 1);                    //取出需转换的某一位的值
                temp = Convert.ToInt32(str3);                   //转换为数字         
                if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
                {
                    //当所取位数不为元、万、亿、万亿上的数字时
                    if (str3 == "0")
                    {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    }
                    else
                    {
                        if (str3 != "0" && nzero != 0)
                        {
                            ch1 = "零" + str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                    }
                }
                else
                {
                    //该位是万亿，亿，万，元位等关键位
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 != "0" && nzero == 0)
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            if (str3 == "0" && nzero >= 3)
                            {
                                ch1 = "";
                                ch2 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                if (j >= 11)
                                {
                                    ch1 = "";
                                    nzero = nzero + 1;
                                }
                                else
                                {
                                    ch1 = "";
                                    ch2 = str2.Substring(i, 1);
                                    nzero = nzero + 1;
                                }
                            }
                        }
                    }
                }
                if (i == (j - 11) || i == (j - 3))
                {
                    //如果该位是亿位或元位，则必须写上
                    ch2 = str2.Substring(i, 1);
                }
                str5 = str5 + ch1 + ch2;
                if (i == j - 1 && str3 == "0")
                {
                    //最后一位（分）为0时，加上“整”
                    str5 = str5 + '整';
                }
            }
            if (num == 0)
            {
                str5 = "零元整";
            }
            return str5;
        }


        /// <summary>
        /// 将小写数字转换成中文大写
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string CmycurD(this int num)
        {
            string str1 = "零壹贰叁肆伍陆柒捌玖";

            return str1[num].ToString();
        }
        #endregion

        #region Int扩展

        /// <summary>
        /// 将0/1 转换成false/true
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool? IntToBool(this int num)
        {
            if (num == 0) return false;
            else if (num == 1) return true;
            else return null;
        }
        #endregion

        #region String扩展
        /// <summary>
        /// 干掉所有的html标签
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string NoHtml(this string str)
        {
            return Common.Str.HtmlDeal.NoHTML(str);
        }


        public static short?  ToShort(this string inString)
        {
            try
            {
                return ((short?)Convert.ToUInt16(inString, 16));
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MyEncode(this string str)
        {
            return Common.Web.InjectionAttack.MyEncodeInputString(str);
        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MyDecode(this string str)
        {
            return Common.Web.InjectionAttack.MyDecodeOutputString(str);
        }

        /// <summary>
        /// 判断是否int型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt(this string str)
        {
            int n = 0;
            return int.TryParse(str, out n);
        }

        /// <summary>
        /// 判断是否int型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt64(this string str)
        {
            Int64 n = 0;
            return Int64.TryParse(str, out n);
        }


        /// <summary>
        /// 判断是否float型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsFloat(this string str)
        {
            float n = 0;
            return float.TryParse(str, out n);
        }

        /// <summary>
        /// 判断是否double型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDouble(this string str)
        {
            double n = 0;
            return double.TryParse(str, out n);
        }

        /// <summary>
        /// 检测是否邮箱
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsEmail(this string email)
        {
            //正则表达式字符串
            string emailStr =
            @"([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,5})+";
            //邮箱正则表达式对象
            Regex emailReg = new Regex(emailStr);
            if (emailReg.IsMatch(email.Trim()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据头和尾截取字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="start">头</param>
        /// <param name="end">尾</param>
        /// <returns></returns>
        public static string MySubstr(this string str,string start,string end)
        {
            if(str.IndexOf(start)>=0)
            {
                str = Regex.Split(str, start)[1];
            }
            if (str.IndexOf(end) >= 0)
            {
                str = Regex.Split(str, end)[0];
            }
            return str;
        }

        /// <summary>
        /// 扩展的字段截取
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="start">起始位置</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string MySubstr(this string str, int start, int length)
        {
            if (start < 0) start = Math.Abs(start);
            if (length < 0) length = Math.Abs(length);
            if (str.IsNullOrEmpty()) return str;
            if (str.Length < start) return "";
            if (str.Length < start + length)
            {
                return str.Substring(start, str.Length - start);
            }
            return str.Substring(start, length);
        }

        /// <summary>
        /// 将0/1 转换成false/true
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool? NumToBool(this string str)
        {
            if (str == "1") return true;
            else if (str == "0") return false;
            else return null;
        }

        /// <summary>
        /// 转换成double
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double? ToDouble(this string str)
        {
            double n1 = 0;
            if (double.TryParse(str, out n1))
            {
                return n1;
            }
            else return null;
        }

        /// <summary>
        /// 转换成float
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static float? ToFloat(this string str)
        {
            float n1 = 0;
            if (float.TryParse(str, out n1))
            {
                return n1;
            }
            else return null;
        }



        /// <summary>
        /// 字符串转换成时间
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="model">格式</param>
        /// <returns></returns>
        static public DateTime? ToDateTime(this string str, string model = "yyyyMMddHHmmss")
        {
            if (str.IsNullOrEmpty()) return null;

            IFormatProvider US_Format = new System.Globalization.CultureInfo("en-US", true);

            DateTime dt = DateTime.ParseExact(str, model, US_Format);
            return dt;
        }


        /// <summary>
        /// 是否时间格式
        /// </summary>
        /// <param name="str"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        static public bool IsDateTime(this string str, string model = "yyyyMMddHHmmss")
        {
            try
            {
                IFormatProvider US_Format = new System.Globalization.CultureInfo("en-US", true);

                DateTime dt = DateTime.ParseExact(str, model, US_Format);
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// 转换为int型，如果失败则返回null
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int? ToInt(this string str)
        {
            int num = 0;
            if (int.TryParse(str, out num))
            {
                return num;
            }
            else return null;
        }


        /// <summary>
        /// 使用字符将字符串补满maxlength位
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="maxlength">最大长度</param>
        /// <param name="c">补充字符</param>
        /// <returns></returns>
        public static string FillChar(this string str, int maxlength, char c)
        {
            if (str == null) str = "";
            if (str.Length >= maxlength) return str;
            for (; str.Length < maxlength; )
            {
                str += c.ToString();
            }
            return str;
        }
        #endregion

        #region bool扩展
        /// <summary>
        /// 将true/false转换成1/0
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string BoolToString(this bool b)
        {
            if (b) return "1";
            else return "0";
        } 

        #endregion

        #region DateTime扩展
        public static string ToStr(this DateTime dt, string model = "yyyy-MM-dd HH:mm:ss")
        {
            return dt.ToString(model);
        }

        #endregion

        #region object扩展
        /// <summary>
        /// 转换成string型
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ToStr(this object o)
        {
            if (o == null) return null;
            else return o.ToString();
        }

        /// <summary>
        /// 判断是否为空
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool IsEmpty(this object o)
        {
            if (o == null) return true;
            if (o.ToStr().IsNullOrEmpty()) return true;
            return false;
        }

        /// <summary>
        /// 判断是否为空
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool ToBool(this object o)
        {
            if (o == null) return false;
            return Convert.ToBoolean(o);
        }

        /// <summary>
        /// 转换为double
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static double? ToDouble(this object o)
        {
            if (o == null) return null;
            return Convert.ToDouble(o);
        }

        /// <summary>
        /// 转换为int型
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int? ToInt(this object o)
        {
            if (o == null) return null;
            return Convert.ToInt32(o);
        }


        /// <summary>
        /// 转换为long型
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static long? ToLong(this object o)
        {
            if (o == null) return null;
            return Convert.ToInt64(o);
        }
        #endregion
    }
}
