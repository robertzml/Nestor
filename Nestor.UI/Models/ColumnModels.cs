using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nestor.Models.Entities;

namespace Nestor.UI.Models
{
    /// <summary>
    /// 顶级栏目模型
    /// </summary>
    /// <remarks>
    /// 包含子栏目
    /// </remarks>
    public class TopColumnModel
    {
        /// <summary>
        /// 栏目对象
        /// </summary>
        public Column Column { get; set; }

        /// <summary>
        /// 子栏目
        /// </summary>
        public List<Column> Children { get; set; }
    }

    /// <summary>
    /// 普通栏目模型
    /// </summary>
    /// <remarks>
    /// 不包含子栏目
    /// </remarks>
    public class GeneralColumnModel
    {
        /// <summary>
        /// 栏目对象
        /// </summary>
        public Column Column { get; set; }

        /// <summary>
        /// 父级栏目
        /// </summary>
        public Column Parent { get; set; }

        /// <summary>
        /// 同级栏目
        /// </summary>
        public List<Column> Sibling { get; set; }

        /// <summary>
        /// 文章列表
        /// </summary>
        public List<Article> Articles { get; set; }
    }
}