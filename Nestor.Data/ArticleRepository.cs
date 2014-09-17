using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nestor.Models;
using Nestor.Models.Entities;

namespace Nestor.Data
{
    /// <summary>
    /// 文章Repository
    /// </summary>
    public class ArticleRepository
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
        public ArticleRepository()
        {
            this.context = new NestorEntities();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取所有文章
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Article> Get()
        {
            return this.context.Articles;
        }

        /// <summary>
        /// 按栏目获取文章
        /// </summary>
        /// <param name="columnId">栏目ID</param>
        /// <returns></returns>
        public IEnumerable<Article> GetByColumn(int columnId)
        {
            return this.context.Articles.Where(r => r.ColumnId == columnId);
        }

        /// <summary>
        /// 获取文章
        /// </summary>
        /// <param name="id">文章ID</param>
        /// <returns></returns>
        public Article Get(int id)
        {
            return this.context.Articles.SingleOrDefault(r => r.Id == id);
        }

        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="data">文章对象</param>
        /// <returns></returns>
        public ErrorCode Create(Article data)
        {
            try
            {
                this.context.Articles.Add(data);
                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch(Exception)
            {
                return ErrorCode.Exception;
            }
        }
        #endregion //Method
    }
}
