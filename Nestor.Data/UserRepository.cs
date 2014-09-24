using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nestor.Models;
using Nestor.Models.Entities;

namespace Nestor.Data
{
    /// <summary>
    /// 用户Repository
    /// </summary>
    public class UserRepository
    {
        #region Field
        /// <summary>
        /// 数据库连接
        /// </summary>
        private NestorEntities context;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 文章Repository
        /// </summary>
        public UserRepository()
        {
            this.context = new NestorEntities();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> Get()
        {
            return this.context.Users;
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public User Get(int id)
        {
            return this.context.Users.SingleOrDefault(r => r.Id == id);
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public User Get(string userName)
        {
            return this.context.Users.SingleOrDefault(r => r.UserName == userName);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="data">用户对象</param>
        /// <returns></returns>
        public ErrorCode Create(User data)
        {
            try
            {
                if (this.context.Users.Any(r => r.UserName == data.UserName))
                    return ErrorCode.DuplicateUserName;

                this.context.Users.Add(data);
                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="data">用户对象</param>
        /// <returns></returns>
        public ErrorCode Update(User data)
        {
            try
            {
                this.context.Entry(data).State = EntityState.Modified;
                this.context.SaveChanges();
                return ErrorCode.Success;
            }
            catch (Exception e)
            {
                return ErrorCode.Exception;
            }
        }
        #endregion //Method
    }
}
