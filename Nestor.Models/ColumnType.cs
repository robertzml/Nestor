using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nestor.Models
{
    /// <summary>
    /// 栏目类型
    /// </summary>
    public enum ColumnType
    {
        /// <summary>
        /// 常规栏目
        /// </summary>
        [Display(Name = "常规栏目")]
        General = 1,

        /// <summary>
        /// 父栏目
        /// </summary>
        /// <remarks>
        /// 父栏目下不能发文章
        /// </remarks>
        [Display(Name = "父栏目")]
        Parent = 2,

        /// <summary>
        /// 内部链接
        /// </summary>
        [Display(Name = "内部链接")]
        Link = 3,

        /// <summary>
        /// 外部链接
        /// </summary>
        [Display(Name = "外部链接")]
        Outter = 4
    }
}
