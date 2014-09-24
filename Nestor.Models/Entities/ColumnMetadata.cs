using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nestor.Models.Entities
{
    [MetadataType(typeof(ColumnMetadataSource))]
    public partial class Column
    {
    }

    public class ColumnMetadataSource
    {
        /// <summary>
        /// 栏目标题
        /// </summary>
        [Required]
        [Display(Name = "栏目标题")]
        public string Title { get; set; }

        /// <summary>
        /// 栏目类型
        /// </summary>
        [Required]
        [UIHint("ColumnTypeList")]
        [Display(Name = "栏目类型")]
        public int Type { get; set; }

        /// <summary>
        /// 是否在菜单显示
        /// </summary>
        [Display(Name = "是否在菜单显示")]
        public bool ShowTop { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Display(Name = "排序")]
        public int Sort { get; set; }

        /// <summary>
        /// 父级栏目ID
        /// </summary>
        [UIHint("TopColumnList")]
        [Display(Name = "父级栏目")]
        public int ParentId { get; set; }

        /// <summary>
        /// 外部链接
        /// </summary>
        [Display(Name = "外部链接")]
        public string Link { get; set; }

        /// <summary>
        /// 栏目描述
        /// </summary>
        [DataType(DataType.MultilineText)]
        [Display(Name = "栏目描述")]
        public string Remark { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public int Status { get; set; }
    }
}
