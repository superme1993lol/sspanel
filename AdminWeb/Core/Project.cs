using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

 
using System.Web;
using System.Web.Mvc;
using Common.Web;
using Model;
using Model.admin;
using Model.client ;

namespace AdminWeb.core
{
    public class Project
    {
        public static string LoginKey = "AdminLoginKey";


        /// <summary>
        /// 获取默认的值
        /// </summary>
        /// <param name="o"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetDefaultVal(object o, string key)
        {
            if (!ReqPara(key).IsNullOrEmpty()) return ReqPara(key);
            else if (o != null) return o.GetType().GetProperty(key).GetValue(o, null);
            else return "";
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        public static bool Submit(DbContext dbc )
        {
            try
            {
                int num = dbc.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 获取请求的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [ValidateInput(false)]
        public static string ReqPara(string key)
        {
            string val = HttpContext.Current.Request.Query[key];
            if (val == null) return null;
            val = System.Net.WebUtility.UrlDecode(val);//获取提交过来的数据，并解码
            val = Common.Web.InjectionAttack.MyEncodeInputString(val);//对关键字符进行过滤
            return val;
        }

        /// <summary>
        /// 反射取值
        /// </summary>
        /// <param name="o"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static dynamic GetVal(dynamic o, string key)
        {
            var a = o.GetType().GetProperty(key);
            return a == null ? null : a.GetValue(o, null);
        }




        #region 国家信息
        private static List<VPNCountry> AllCountry;
        /// <summary>
        /// 获取目前在编的地区信息
        /// </summary>
        /// <returns></returns>
        public static List<VPNCountry> GetAllCountry()
        {
            if (AllCountry == null)
            {
                List<VPNCountry> lst = new List<VPNCountry>();
                lst.Add(new VPNCountry() { CnName = "中国", EnName = "China", Id = "cn", SCode = "🇨🇳", Emoji = "\\ud83c\\udde8\\ud83c\\uddf3" });
                lst.Add(new VPNCountry() { CnName = "香港", EnName = "HongKong", Id = "hk", SCode = "🇭🇰", Emoji = "\\ud83c\\udded\\ud83c\\uddf0" });
                lst.Add(new VPNCountry() { CnName = "日本", EnName = "Japan", Id = "jp", SCode = "🇯🇵", Emoji = "\\ud83c\\uddef\\ud83c\\uddf5" });
                lst.Add(new VPNCountry() { CnName = "新加坡", EnName = "Singapore", Id = "sg", SCode = "🇸🇬", Emoji = "\\ud83c\\uddf8\\ud83c\\uddec" });
                lst.Add(new VPNCountry() { CnName = "韩国", EnName = "Korea", Id = "kr", SCode = "🇰🇷", Emoji = "\\ud83c\\uddf0\\ud83c\\uddf7" });
                lst.Add(new VPNCountry() { CnName = "美国", EnName = "USA", Id = "us", SCode = "🇺🇸", Emoji = "\\ud83c\\uddfa\\ud83c\\uddf8" });
                lst.Add(new VPNCountry() { CnName = "台湾", EnName = "TW", Id = "tw", SCode = "🇨🇳", Emoji = "\\ud83c\\udde8\\ud83c\\uddf3" });
                lst.Add(new VPNCountry() { CnName = "澳大利亚", EnName = "AUSTRALIA", Id = "au", SCode = "🇦🇺", Emoji = "\\ud83c\\udde6\\ud83c\\uddfa" });
                lst.Add(new VPNCountry() { CnName = "英国", EnName = "UNITED KINGDOM", Id = "gb", SCode = "🇬🇧", Emoji = "\\ud83c\\uddec\\ud83c\\udde7" });
                lst.Add(new VPNCountry() { CnName = "德国", EnName = "Germany", Id = "de", SCode = "🇩🇪", Emoji = "\\ud83c\\udde9\\ud83c\\uddea" });
                lst.Add(new VPNCountry() { CnName = "泰国", EnName = "THAILAND", Id = "th", SCode = "🇹🇭", Emoji = "\\ud83c\\uddf9\\ud83c\\udded" });
                lst.Add(new VPNCountry() { CnName = "马来西亚", EnName = "MALAYSIA", Id = "my", SCode = "🇲🇾", Emoji = "\\ud83c\\uddf2\\ud83c\\uddfe" });

                lst.Add(new VPNCountry() { CnName = "奥地利", EnName = "Austria", Id = "at", SCode = "🇦🇹", Emoji = "\\ud83c\\udde6\\ud83c\\uddf9" });
                lst.Add(new VPNCountry() { CnName = "加拿大", EnName = "Canada", Id = "ca", SCode = "🇨🇦", Emoji = "\\ud83c\\udde8\\ud83c\\udde6" });
                lst.Add(new VPNCountry() { CnName = "新西兰", EnName = "New Zealand", Id = "nz", SCode = "🇳🇿", Emoji = "\\ud83c\\uddf3\\ud83c\\uddff" });
                lst.Add(new VPNCountry() { CnName = "俄罗斯", EnName = "Russia", Id = "ru", SCode = "🇷🇺", Emoji = "\\ud83c\\uddf7\\ud83c\\uddfa" });
                lst.Add(new VPNCountry() { CnName = "法国", EnName = "France", Id = "fr", SCode = "🇫🇷", Emoji = "\\ud83c\\uddeb\\ud83c\\uddf7" });
                lst.Add(new VPNCountry() { CnName = "荷兰", EnName = "Netherlands", Id = "nl", SCode = "🇳🇱", Emoji = "\\ud83c\\uddf3\\ud83c\\uddf1" });


                lst.Add(new VPNCountry() { CnName = "印度", EnName = "India", Id = "in", SCode = "🇮🇳", Emoji = "\\ud83c\\uddee\\ud83c\\uddf3" });
                lst.Add(new VPNCountry() { CnName = "菲律宾", EnName = "Philippines", Id = "ph", SCode = "🇵🇭", Emoji = "\\ud83c\\uddf5\\ud83c\\udded" });


                lst.Add(new VPNCountry() { CnName = "瑞典", EnName = "Sweden", Id = "se", SCode = "🇸🇪", Emoji = "\\ud83c\\uddf8\\ud83c\\uddea" });

                lst.Add(new VPNCountry() { CnName = "土耳其", EnName = "Turkey", Id = "tr", SCode = "🇹🇷", Emoji = "\\ud83c\\uddf9\\ud83c\\uddf7" });
                lst.Add(new VPNCountry() { CnName = "爱尔兰", EnName = "Ireland", Id = "ie", SCode = "🇮🇪", Emoji = "\\ud83c\\uddee\\ud83c\\uddea" });
                lst.Add(new VPNCountry() { CnName = "印度尼西亚", EnName = "Indonesia", Id = "id", SCode = "🇮🇩", Emoji = "\\ud83c\\uddee\\ud83c\\udde9" });
                lst.Add(new VPNCountry() { CnName = "南非", EnName = "South Africa", Id = "za", SCode = "🇿🇦", Emoji = "\\ud83c\\uddff\\ud83c\\udde6" });
                lst.Add(new VPNCountry() { CnName = "巴西", EnName = "Brazil", Id = "br", SCode = "🇧🇷", Emoji = "\\ud83c\\udde7\\ud83c\\uddf7" });
                lst.Add(new VPNCountry() { CnName = "阿联酋", EnName = "Arab Emirates", Id = "ae", SCode = "🇦🇪", Emoji = "\\ud83c\\udde6\\ud83c\\uddea" });

                lst.Add(new VPNCountry() { CnName = "匈牙利", EnName = "Hungary", Id = "hu", SCode = "🇭🇺", Emoji = "\\ud83c\\udded\\ud83c\\uddfa" });

                lst.Add(new VPNCountry() { CnName = "保加利亚", EnName = "Bulgaria", Id = "bg", SCode = "🇧🇬", Emoji = "\\ud83c\\udde7\\ud83c\\uddec" });


                lst.Add(new VPNCountry() { CnName = "拉脱维亚", EnName = "Latvia", Id = "lv", SCode = "🇱🇻", Emoji = "\\ud83c\\uddf1\\ud83c\\uddfb" });

                lst.Add(new VPNCountry() { CnName = "瑞士", EnName = "Switzerland", Id = "ch", SCode = "🇨🇭", Emoji = "\\ud83c\\udde8\\ud83c\\udded" });

                lst.Add(new VPNCountry() { CnName = "挪威", EnName = "Norway", Id = "no", SCode = "🇳🇴", Emoji = "\\ud83c\\uddf3\\ud83c\\uddf4" });


                lst.Add(new VPNCountry() { CnName = "丹麦", EnName = "Denmark", Id = "dk", SCode = "🇩🇰", Emoji = "\\ud83c\\udde9\\ud83c\\uddf0" });
                lst.Add(new VPNCountry() { CnName = "冰岛", EnName = "Iceland", Id = "is", SCode = "🇮🇸", Emoji = "\\ud83c\\uddee\\ud83c\\uddf8" });
                lst.Add(new VPNCountry() { CnName = "意大利", EnName = "Italy", Id = "it", SCode = "🇮🇹", Emoji = "\\ud83c\\uddee\\ud83c\\uddf9" });
                lst.Add(new VPNCountry() { CnName = "波兰", EnName = "Poland", Id = "pl", SCode = "🇵🇱", Emoji = "\\ud83c\\uddf5\\ud83c\\uddf1" });
                lst.Add(new VPNCountry() { CnName = "捷克", EnName = "Czechia", Id = "cz", SCode = "🇨🇿", Emoji = "\\ud83c\\udde8\\ud83c\\uddff" });
                AllCountry = lst;
            }

            return AllCountry;
        }

        public static string GetCountryName(string cnid)
        {
            var clst = Project.GetAllCountry();
            var c = clst.Where(p => p.Id == cnid).FirstOrDefault();

            if (c == null)
            {
                return "未知";
            }
            else
            {
                return c.CnName;
            }
        }

        public class VPNCountry
        {
            public string CnName { get; set; }

            public string EnName { get; set; }

            public string SCode { get; set; }

            public string Id { get; set; }

            public string Emoji { get; set; }
        } 
        #endregion
    }
}
