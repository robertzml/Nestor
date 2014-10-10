using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace Nestor.UI.HtmlHelpers
{
    public static class ContentHelper
    {
        /// <summary>
        /// 去除HTML标签
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="strhtml"></param>
        /// <returns></returns>
        public static string StripHtml(this HtmlHelper helper, string strhtml)
        {
            string stroutput = strhtml;
            Regex regex = new Regex(@"<[^>]+>|</[^>]+>");

            stroutput = regex.Replace(stroutput, "");
            return stroutput;
        }
    }
}