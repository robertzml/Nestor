using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nestor.Business;
using Nestor.Models;
using Nestor.Models.Entities;
using Nestor.Common;

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
        /// <summary>
        /// 栏目列表
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            var data = this.columnBusiness.Get();
            return View(data);
        }

        /// <summary>
        /// 栏目信息
        /// </summary>
        /// <param name="id">栏目ID</param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var data = this.columnBusiness.Get(id);
            return View(data);
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
                if (string.IsNullOrEmpty(model.Remark))
                    model.Remark = "";
                model.Status = 0;

                ErrorCode result = this.columnBusiness.Create(model);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "添加栏目成功";
                    return RedirectToAction("List");
                }
                else
                {
                    ModelState.AddModelError("", "添加栏目失败, " + result.DisplayName());
                }
            }

            return View(model);
        }

        /// <summary>
        /// 编辑栏目
        /// </summary>
        /// <param name="id">栏目ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {            
            var data = this.columnBusiness.Get(id);
            if (data == null)
            {
                return HttpNotFound();
            }

            return View(data);
        }

        /// <summary>
        /// 编辑栏目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Column model)
        {
            if (ModelState.IsValid)
            {
                ErrorCode result = this.columnBusiness.Update(model);

                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "编辑栏目成功";
                    return RedirectToAction("List");
                }
                else
                {
                    ModelState.AddModelError("", "编辑栏目失败, " + result.DisplayName());
                }
            }

            return View(model);
        }
        #endregion //Action
    }
}