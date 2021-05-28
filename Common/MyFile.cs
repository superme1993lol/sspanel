using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common
{
    public class MyFile
    {

        /// <summary>
        /// 读取文档内容
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static string GetFileString(string path)
        {
            StreamReader sr = new StreamReader(Stream.Null);
            try
            {
                sr = new StreamReader(path, Encoding.Default);
                string s = sr.ReadToEnd();
                sr.Close();
                return s;
            }
            catch
            {
                return "";
            }
            finally
            {
                sr.Close();
                sr.Dispose();
            }
        }


        /// <summary>
        /// 写入文档
        /// </summary>
        /// <param name="filepath">路径</param>
        /// <param name="words">文字</param>
        public static void WriteToFileString(string filepath, string words, Encoding encoding = null)
        {
            StreamWriter sw = new StreamWriter(Stream.Null);
            try
            {
                string dirpath = Path.GetDirectoryName(filepath);
                if (!Directory.Exists(dirpath)) Directory.CreateDirectory(dirpath);
                if (!File.Exists(filepath))
                {
                    using (File.Create(filepath))
                    {

                    }
                }
                if (encoding == null) encoding = Encoding.UTF8;
                sw = new StreamWriter(filepath, false, encoding);
                sw.Write(words);
                sw.Close();//写入
                sw.Dispose();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                sw.Close();
                sw.Dispose();
            }

        }

        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        /// <param name="strPath">指定的路径</param>
        /// <returns>绝对路径</returns>
        public static string GetMapPath(string strPath)
        {
            strPath = strPath.Replace("/", "\\");
            if (strPath.StartsWith("\\"))
            {
                //注意路径格式一定要全部转换  例子：F:\\web\\root\\update 或者 F:\\web\\root\\update\\test.img这种格式
                strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
            }
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
        } 
    }
}
