using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nestor.Business;
using Nestor.Models;
using Nestor.Models.Entities;
using Nestor.UI.Models;

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
            ArticleModel data = new ArticleModel();
            var article = this.articleBusiness.Get(id);
            if (article == null)
                return HttpNotFound();

            this.articleBusiness.IncreaseReadCount(id);
            article.MainContent = HttpUtility.HtmlDecode(article.MainContent);

            data.Article = article;

            return View(data);
        }

        /// <summary>
        /// 近期新闻
        /// </summary>
        /// <param name="count">文章数量</param>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult Recent(int count)
        {
            var data = this.articleBusiness.GetRecent(count).ToList();
            return View(data);
        }

        /// <summary>
        /// 推荐新闻
        /// </summary>
        /// <param name="count">文章数量</param>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult Recommend(int count)
        {
            var data = this.articleBusiness.GetRecommend(count).ToList();
            return View(data);
        }
        #endregion //Action
    }
}