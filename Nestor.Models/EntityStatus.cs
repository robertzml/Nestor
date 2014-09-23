using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nestor.Models
{
    /// <summary>
    /// 实体类 Stauts 属性
    /// </summary>
    public enum EntityStatus
    {
        /// <summary>
        /// 0:正常
        /// </summary>
        [Display(Name = "正常")]
        Normal = 0,

        /// <summary>
        /// 1:已删除
        /// </summary>
        [Display(Name = "已删除")]
        Deleted = 1,

        /// <summary>
        /// 用户类
        /// 11:已禁用
        /// </summary>
        [Display(Name = "已禁用")]
        UserDisable = 11
    }
}
