using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nestor.Common;
using Nestor.Data;
using Nestor.Models;
using Nestor.Models.Entities;

namespace Nestor.Business
{
    /// <summary>
    /// 用户业务类
    /// </summary>
    public class UserBusiness
    {
        #region Field
        /// <summary>
        /// 用户Repository
        /// </summary>
        private UserRepository userRepository;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 用户业务类
        /// </summary>
        public UserBusiness()
        {
            this.userRepository = new UserRepository();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <param name="isRoot">是否Root</param>
        /// <returns></returns>
        public IEnumerable<User> GetList(int userType)
        {
            if (userType == (int)UserType.Root)
            {
                return this.userRepository.Get();
            }
            else
            {
                return this.userRepository.Get().Where(r => r.UserType != (int)UserType.Root);
            }
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public User Get(int id)
        {
            return this.userRepository.Get(id);
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public User Get(string userName)
        {
            return this.userRepository.Get(userName);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns></returns>
        public ErrorCode Create(User user)
        {
            return this.userRepository.Create(user);
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns></returns>
        public ErrorCode Update(User user)
        {
            User current = this.userRepository.Get(user.Id);

            if (!string.IsNullOrEmpty(user.Password))
                current.Password = Hasher.SHA1Encrypt(user.Password);
                        
            current.Name = user.Name;
            current.UserType = user.UserType;

            return this.userRepository.Update(current);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public ErrorCode Login(string userName, string password)
        {
            var user = this.userRepository.Get(userName);
            if (user == null)
                return ErrorCode.UserNotExist;

            if (user.Status == (int)EntityStatus.UserDisable)
                return ErrorCode.UserDisabled;

            if (user.Password != Hasher.SHA1Encrypt(password))
                return ErrorCode.WrongPassword;

            return ErrorCode.Success;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="oldPassword">原密码</param>
        /// <param name="newPassword">新密码</param>
        /// <returns></returns>
        public ErrorCode ChangePassword(string userName, string oldPassword, string newPassword)
        {
            var user = this.userRepository.Get(userName);
            if (user == null)
                return ErrorCode.UserNotExist;

            if (user.Password != Hasher.SHA1Encrypt(oldPassword))
                return ErrorCode.WrongPassword;

            user.Password = Hasher.SHA1Encrypt(newPassword);

            return this.userRepository.Update(user);
        }
        #endregion //Method
    }
}
