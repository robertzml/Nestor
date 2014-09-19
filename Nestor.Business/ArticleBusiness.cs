using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nestor.Data;
using Nestor.Models;
using Nestor.Models.Entities;

namespace Nestor.Business
{
    /// <summary>
    /// 文章业务类
    /// </summary>
    public class ArticleBusiness
    {
        #region Field
        /// <summary>
        /// 文章Repository
        /// </summary>
        private ArticleRepository articleRepository;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 文章业务类
        /// </summary>
        public ArticleBusiness()
        {
            this.articleRepository = new ArticleRepository();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取所有文章
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Article> Get()
        {
            return this.articleRepository.Get().OrderByDescending(r => r.PublishDate);
        }

        /// <summary>
        /// 按栏目获取文章
        /// </summary>
        /// <param name="columnId">栏目ID</param>
        /// <returns></returns>
        public IEnumerable<Article> GetByColumn(int columnId)
        {
            return this.articleRepository.GetByColumn(columnId);
        }

        /// <summary>
        /// 获取文章
        /// </summary>
        /// <param name="id">文章ID</param>
        /// <returns></returns>
        public Article Get(int id)
        {
            return this.articleRepository.Get(id);
        }

        /// <summary>
        /// 添加文章
        /// </summary>
        /// <param name="data">文章对象</param>
        /// <returns></returns>
        public ErrorCode Create(Article data)
        {
            return this.articleRepository.Create(data);
        }

        /// <summary>
        /// 编辑文章
        /// </summary>
        /// <param name="data">文章对象</param>
        /// <returns></returns>
        public ErrorCode Update(Article data)
        {
            return this.articleRepository.Update(data);
        }
        #endregion //Method
    }
}
