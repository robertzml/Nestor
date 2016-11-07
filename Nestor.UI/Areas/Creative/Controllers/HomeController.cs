using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nestor.Business;

namespace Nestor.UI.Areas.Creative.Controllers
{
    /// <summary>
    /// 大学生创新实践基地
    /// </summary>
    public class HomeController : Controller
    {
        #region Action
        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 主页最新
        /// </summary>
        /// <param name="columnId"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult HomeRecent(int columnId, int count)
        {
            ColumnBusiness columnBusiness = new ColumnBusiness();
            var column = columnBusiness.Get(columnId);

            ViewBag.Title = column.Title;

            ArticleBusiness articleBusiness = new ArticleBusiness();

            var data = articleBusiness.GetRecent(columnId, count);
            return View(data);
        }
        #endregion //Action
    }
}