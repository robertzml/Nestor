using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nestor.UI.Filters;

namespace Nestor.UI.Areas.Admin.Controllers
{
    /// <summary>
    /// 后台主页控制器
    /// </summary>
    [EnhancedAuthorize]
    public class HomeController : Controller
    {
        #region Action
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 菜单
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult Menu()
        {
            return View();
        }
        #endregion //Action
    }
}