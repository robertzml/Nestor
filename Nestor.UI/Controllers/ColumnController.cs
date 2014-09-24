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
    /// 栏目控制器
    /// </summary>
    public class ColumnController : Controller
    {
        #region Field
        /// <summary>
        /// 栏目业务
        /// </summary>
        private ColumnBusiness columnBusiness;
        #endregion //Field

        #region Constructor
        public ColumnController()
        {
            this.columnBusiness = new ColumnBusiness();
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 栏目页面
        /// </summary>
        /// <param name="id">栏目ID</param>
        /// <returns></returns>
        public ActionResult Index(int id)
        {
            var data = this.columnBusiness.Get(id);
            if (data == null)
                return new HttpNotFoundResult();

            return View(data);
        }
        #endregion //Action
    }
}