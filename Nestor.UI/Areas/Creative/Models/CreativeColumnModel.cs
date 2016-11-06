using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nestor.Models.Entities;

namespace Nestor.UI.Areas.Creative.Models
{
    /// <summary>
    /// 大创栏目模型
    /// </summary>
    public class CreativeColumnModel
    {
        /// <summary>
        /// 栏目对象
        /// </summary>
        public Column Column { get; set; }

        /// <summary>
        /// 同级栏目
        /// </summary>
        public List<Column> Sibling { get; set; }

        /// <summary>
        /// 文章列表
        /// </summary>
        public List<Article> Articles { get; set; }

        /// <summary>
        /// 当前页数
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage { get; set; }

        /// <summary>
        /// 文章总数
        /// </summary>
        public int TotalCount { get; set; }
    }
}