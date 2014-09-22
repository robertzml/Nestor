using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nestor.Models
{
    public enum UserType
    {
        /// <summary>
        /// 超级管理员
        /// </summary>
        [Display(Name = "超级管理员")]
        Root = 1,

        /// <summary>
        /// 管理员
        /// </summary>
        [Display(Name = "管理员")]
        Administrator = 2,

        /// <summary>
        /// 用户
        /// </summary>
        [Display(Name = "用户")]
        User = 3
    }
}
