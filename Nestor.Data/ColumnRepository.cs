using Nestor.Models;
using Nestor.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nestor.Data
{
    /// <summary>
    /// 栏目Repository
    /// </summary>
    public class ColumnRepository
    {
        #region Field
        /// <summary>
        /// 数据库连接
        /// </summary>
        private NestorEntities context;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 栏目Repository
        /// </summary>
        public ColumnRepository()
        {
            this.context = new NestorEntities();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取所有栏目
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Column> Get()
        {
            return this.context.Columns;
        }

        /// <summary>
        /// 获取栏目
        /// </summary>
        /// <param name="id">栏目ID</param>
        /// <returns></returns>
        public Column Get(int id)
        {
            return this.context.Columns.SingleOrDefault(r => r.Id == id);
        }

        /// <summary>
        /// 添加栏目
        /// </summary>
        /// <param name="data">栏目对象</param>
        /// <returns></returns>
        public ErrorCode Create(Column data)
        {
            try
            {
                Column result = context.Columns.Add(data);
                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception e)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 编辑栏目
        /// </summary>
        /// <param name="data">栏目对象</param>
        /// <returns></returns>
        public ErrorCode Update(Column data)
        {
            try
            {
                this.context.Entry(data).State = EntityState.Modified;
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
