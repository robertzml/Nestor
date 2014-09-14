using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nestor.UI.Areas.Admin.Controllers
{
    /// <summary>
    /// 栏目管理控制器
    /// </summary>
    public class ColumnController : Controller
    {
        #region Action
        // GET: Admin/Column
        public ActionResult Index()
        {
            return View();
        }
        #endregion //Action
    }
}