using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nestor.Business;
using Nestor.Models;
using Nestor.Models.Entities;
using Nestor.UI.Areas.Creative.Models;

namespace Nestor.UI.Areas.Creative.Controllers
{
    /// <summary>
    /// 大创文章控制器
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
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Index(int id)
        {
            CreativeArticleModel data = new CreativeArticleModel();
            var article = this.articleBusiness.Get(id);
            if (article == null)
                return HttpNotFound();

            this.articleBusiness.IncreaseReadCount(id);
            article.MainContent = HttpUtility.HtmlDecode(article.MainContent);

            data.Article = article;

            return View(data);
        }
        #endregion //Action
    }
}