using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Common.Json
{
    /// <summary>
    /// Json实体类转换
    /// </summary>
    public class ClassJson
    {
        /// <summary>
        /// 把实体类转换成Json
        /// </summary>
        /// <param name="classInfo">待转换对象</param>
        /// <returns></returns>
        public static string ClassToJson(object classInfo)
        {
            return JsonConvert.SerializeObject(classInfo); 
        }

        /// <summary>
        /// 把Json转换成Class
        /// </summary>
        /// <param name="stringBuilder"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Object JsonToClasObj(string stringBuilder, Type t)
        {
            return JsonConvert.DeserializeObject(stringBuilder, t); 
        }



        /// <summary>
        /// 把Json转换成动态对象
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static dynamic JsonToDynamic(string str)
        {
            try
            {

                JObject obj = JsonConvert.DeserializeObject(str) as JObject;
                dynamic d = obj;
                return d;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
