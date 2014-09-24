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
    /// 栏目业务类
    /// </summary>
    public class ColumnBusiness
    {
        #region Field
        /// <summary>
        /// 栏目Repository
        /// </summary>
        private ColumnRepository columnRepository;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 栏目业务类
        /// </summary>
        public ColumnBusiness()
        {
            this.columnRepository = new ColumnRepository();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取所有栏目
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Column> Get()
        {
            return this.columnRepository.Get();
        }

        /// <summary>
        /// 获取顶级栏目
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Column> GetTop()
        {
            var data = this.columnRepository.Get().Where(r => r.ParentColumn == null);
            return data;
        }

        /// <summary>
        /// 获取栏目
        /// </summary>
        /// <param name="id">栏目ID</param>
        /// <returns></returns>
        public Column Get(int id)
        {
            return this.columnRepository.Get(id);
        }

        /// <summary>
        /// 添加栏目
        /// </summary>
        /// <param name="data">栏目对象</param>
        /// <returns></returns>
        public ErrorCode Create(Column data)
        {
            return this.columnRepository.Create(data);
        }

        /// <summary>
        /// 编辑栏目
        /// </summary>
        /// <param name="data">栏目对象</param>
        /// <returns></returns>
        public ErrorCode Update(Column data)
        {
            return this.columnRepository.Update(data);
        }
        #endregion //Method

    }
}
