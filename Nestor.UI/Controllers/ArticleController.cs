using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nestor.Business;
using Nestor.Models;
using Nestor.Models.Entities;

namespace Nestor.UI.Controllers
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

        #region Action
        /// <summary>
        /// 文章页面
        /// </summary>
        /// <param name="id">文章ID</param>
        /// <returns></returns>
        public ActionResult Index(int id)
        {
            var data = this.articleBusiness.Get(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }
        #endregion //Action
    }
}