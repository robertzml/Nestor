using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nestor.Models.Entities
{
    [MetadataType(typeof(UserMetadataSource))]
    public partial class User
    {
    }

    public class UserMetadataSource
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        [Display(Name = "用户名")]
        public string UserName { get; set; }
        
        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [Display(Name = "密码")]
        public string Password { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        [Required]
        [Display(Name = "用户类型")]
        public int UserType { get; set; }
    }
}
