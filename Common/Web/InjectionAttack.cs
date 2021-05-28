using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Common.Web
{
    /// <summary>
    /// 防止注入式攻击
    /// </summary>
    public class InjectionAttack
    {
        #region 防止sql注入式攻击(可用于UI层控制）        ///

        /// 判断字符串中是否有SQL攻击代码，by fangbo.yu 2008.07.18
        /// 
        /// 传入用户提交数据
        /// true-安全；false-有注入攻击现有；
        public static bool ProcessSqlStr(string inputString)
        {
            string SqlStr = @"and|or|exec|execute|insert|select|delete|update|alter|create|drop|count|\*|chr|char|asc|mid|substring|master|truncate|declare|xp_cmdshell|restore|backup|net +user|net +localgroup +administrators";
            try
            {
                if ((inputString != null) && (inputString != String.Empty))
                {
                    string str_Regex = @"\b(" + SqlStr + @")\b";
                    Regex Regex = new Regex(str_Regex, RegexOptions.IgnoreCase);
                    //string s = Regex.Match(inputString).Value; 
                    if (true == Regex.IsMatch(inputString))
                        return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

    
        #endregion


        #region 转换sql代码（也防止sql注入式攻击，可以用于业务逻辑层，但要求UI层输入数据时候进行解码）
        /// 
        /// 提取字符固定长度， 
        /// 
        /// 
        /// 
        /// 
        public static string CheckStringLength(string inputString, Int32 maxLength)
        {
            if ((inputString != null) && (inputString != String.Empty))
            {
                inputString = inputString.Trim();
                if (inputString.Length > maxLength)
                    inputString = inputString.Substring(0, maxLength);
            }
            return inputString;
        }
        /// 
        /// 将输入字符串中的sql敏感字，替换成"[敏感字]"，要求输出时，替换回来， 
        /// 
        /// 
        /// 
        public static string MyEncodeInputString(string inputString)
        {
            //要替换的敏感字
            string SqlStr = @"information_schema|concat|union|and|or|exec|execute|insert|select|delete|update|alter|create|script|drop|count|\*|chr|char|asc|mid|substring|master|truncate|declare|xp_cmdshell|restore|backup|net +user|net +localgroup +administrators";
            try
            {
                if ((inputString != null) && (inputString != String.Empty))
                {

                    inputString = inputString.Replace("'", "‘");
                    inputString = inputString.Replace("\"", "“");
                    string str_Regex = @"\b(" + SqlStr + @")\b";

                    Regex Regex = new Regex(str_Regex, RegexOptions.IgnoreCase);
                    //string s = Regex.Match(inputString).Value; 
                    MatchCollection matches = Regex.Matches(inputString);
                    for (int i = 0; i < matches.Count; i++)
                        inputString = inputString.Replace(matches[i].Value, "[" + matches[i].Value + "]");

                }
            }
            catch
            {
                return "";
            }
            if (inputString == null) return inputString;
             #region 对字段进行处理（防止sqlserver不支持utf8编码）
            //byte[] buffer = Encoding.UTF8.GetBytes(inputString); 
            //string strDest = Encoding.GetEncoding("GB2312").GetString(buffer);
            #endregion
            return inputString;
        }
        /// 
        /// 将已经替换成的"[敏感字]"，转换回来为"敏感字"， 
        /// 
        /// 
        /// 
        public static string MyDecodeOutputString(string outputstring)
        {
            //要替换的敏感字
            string SqlStr = @"information_schema|concat|union|and|or|exec|execute|insert|select|delete|update|alter|create|script|drop|count|\*|chr|char|asc|mid|substring|master|truncate|declare|xp_cmdshell|restore|backup|net +user|net +localgroup +administrators";
            try
            {
                if ((outputstring != null) && (outputstring != String.Empty))
                {
                    outputstring = outputstring.Replace("‘", "'");
                    outputstring = outputstring.Replace("“", "\"");
                    string str_Regex = @"\[\b(" + SqlStr + @")\b\]";
                    Regex Regex = new Regex(str_Regex, RegexOptions.IgnoreCase);
                    MatchCollection matches = Regex.Matches(outputstring);
                    for (int i = 0; i < matches.Count; i++)
                        outputstring = outputstring.Replace(matches[i].Value, matches[i].Value.Substring(1, matches[i].Value.Length - 2));

                }
            }
            catch
            {
                return "";
            }
            return outputstring;
        }
        #endregion
	
	 

    }
}
 