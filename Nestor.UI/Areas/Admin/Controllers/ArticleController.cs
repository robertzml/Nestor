using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nestor.Business;
using Nestor.Common;
using Nestor.Models;
using Nestor.Models.Entities;

namespace Nestor.UI.Areas.Admin.Controllers
{
    /// <summary>
    /// 文章控制器
    /// </summary>
    public class ArticleController : Controller
    {
        #region Field
        /// <summary>
        /// 文章业务
        /// </summary>
        private ArticleBusiness articleBusiness;
        #endregion //Field

        #region Constructor
        public ArticleController()
        {
            this.articleBusiness = new ArticleBusiness();
        }
        #endregion //Constructor

        #region Field
        /// <summary>
        /// 文章列表
        /// </summary>
        /// <param name="id">所属栏目ID</param>
        /// <returns></returns>
        public ActionResult List(int? id)
        {
            if (id == null)
            {
                var data = this.articleBusiness.Get();
                return View(data);
            }
            else
            {
                var data = this.articleBusiness.GetByColumn(id.Value);
                return View(data);
            }
        }

        /// <summary>
        /// 添加文章
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Article model)
        {
            if (ModelState.IsValid)
            {
                //model.MainContent = 
                model.Status = 0;

                ErrorCode result = this.articleBusiness.Create(model);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "添加文章成功";
                    return RedirectToAction("List");
                }
                else
                {
                    ModelState.AddModelError("", "添加文章失败, " + result.DisplayName());
                }
            }

            return View(model);
        }
        #endregion //Field
    }
}