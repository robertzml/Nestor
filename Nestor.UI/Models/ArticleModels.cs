using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nestor.Models.Entities;

namespace Nestor.UI.Models
{
    /// <summary>
    /// 文章页面模型
    /// </summary>
    public class ArticleModel
    {
        /// <summary>
        /// 文章对象
        /// </summary>
        public Article Article { get; set; }

        /// <summary>
        /// 近期文章
        /// </summary>
        public List<Article> Recents { get; set; }

        /// <summary>
        /// 推荐文章
        /// </summary>
        public List<Article> Recommends { get; set; }
    }
}