using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        #endregion //Action
    }
}