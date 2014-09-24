using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nestor.Models.Entities
{
    [MetadataType(typeof(ArticleMetadataSource))]
    public partial class Article
    {
    }

    public class ArticleMetadataSource
    {
        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        [Display(Name = "标题")]
        public string Title { get; set; }

        /// <summary>
        /// 所属栏目ID
        /// </summary>
        [Required]
        [UIHint("ColumnCascadeList")]
        [Display(Name = "所属栏目")]
        public int ColumnId { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        [Display(Name = "作者")]
        public string Author { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        [DataType(DataType.MultilineText)]
        [Display(Name = "摘要")]
        public string Summary { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Display(Name = "内容")]
        public string MainContent { get; set; }

        /// <summary>
        /// 发布日期
        /// </summary>
        [DataType(DataType.Date)]
        [Display(Name = "发布日期")]
        public System.DateTime PublishDate { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        [Display(Name = "添加时间")]
        public System.DateTime AddTime { get; set; }
    }
}
