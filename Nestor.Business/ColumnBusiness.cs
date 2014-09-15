using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nestor.Models;
using Nestor.Models.Concrete;
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
        public Column Create(Column data)
        {
            return this.columnRepository.Create(data);
        }
        #endregion //Method

    }
}
