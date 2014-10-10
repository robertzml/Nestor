using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nestor.Business;
using Nestor.Models.Entities;

namespace Nestor.UI.Controllers
{
    /// <summary>
    /// 搜索控制器
    /// </summary>
    public class SearchController : Controller
    {
         #region Field
        /// <summary>
        /// 栏目业务
        /// </summary>
        private SearchBusiness searchBusiness;
        #endregion //Field

        #region Constructor
        public SearchController()
        {
            this.searchBusiness = new SearchBusiness();
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="t">标题文本</param>
        /// <returns></returns>
        public ActionResult Index(string t)
        {
            if (string.IsNullOrEmpty(t))
                return RedirectToAction("Index", "Home");

            string text = HttpUtility.HtmlEncode(t);
            var data = this.searchBusiness.SearchByTitle(text);

            foreach(var item in data)
            {
                item.MainContent = HttpUtility.HtmlDecode(item.MainContent);
            }

            ViewBag.Text = t;
            return View(data);
        }
        #endregion //Action
    }
}