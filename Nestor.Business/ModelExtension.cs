using Nestor.Common;
using Nestor.Models;
using Nestor.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nestor.Business
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class ModelExtension
    {
        #region Method
        #region User Method
        /// <summary>
        /// 用户组名称
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns></returns>
        public static string UserTypeName(this User user)
        {
            var type = (UserType)user.UserType;
            return type.ToString();
        }

        /// <summary>
        /// 用户组显示名称
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns></returns>
        public static string UserTypeTitle(this User user)
        {
            var type = (UserType)user.UserType;
            return type.DisplayName();
        }
        #endregion //User Method
        #endregion //Method
    }
}
