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
        /// 链接栏目
        /// </summary>
        [Display(Name = "链接栏目")]
        Link = 3
    }
}
