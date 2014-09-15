using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nestor.Business;
using Nestor.Models.Entities;

namespace Nestor.UI.Areas.Admin.Controllers
{
    /// <summary>
    /// 栏目管理控制器
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
        // GET: Admin/Column
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 添加栏目
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 添加栏目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Column model)
        {
            if (ModelState.IsValid)
            {
                model.Status = 0;

                Column column = this.columnBusiness.Create(model);


            }

            return View(model);
        }
        #endregion //Action
    }
}